using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using DataCs;

[CustomEditor(typeof(AutoBind))]
public class AutoBindInspector : Editor
{
    string UIFormPath = Data_FilePath.AutoUIFormCS_Path;
    string UIFormBindPath = Data_FilePath.AutoBindUIFormCS_Path;

    AutoBind autoBind;
    GameObject Root;

    Dictionary<string,string> AutoBindTips = new Dictionary<string, string>()
    {
        {"m_txt","Text"},
        {"m_img","Image"},
        {"m_rawimg","Raw Image"},
        {"m_btn","Button"},
        {"m_toggle","Toggle"},
        {"m_slider","Slider"},
        {"m_scrollbar","Scrollbar"},
        {"m_dropdown","Dropdown"},
        {"m_input","InputField"},
        {"m_scrollview","ScrollView"},
        {"m_rect","RectTransform"},
    };
    List<string> TipsKeys = new List<string>() 
    {
        "m_txt",
        "m_img",
        "m_rawimg",
        "m_btn",
        "m_toggle",
        "m_slider",
        "m_scrollbar",
        "m_dropdown",
        "m_input",
        "m_scrollview",
        "m_rect"
    };

    SerializedProperty itemList;

    private void OnEnable()
    {
        autoBind = (AutoBind)target;
        Root = autoBind.gameObject;

        itemList = serializedObject.FindProperty("itemList");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.BeginVertical();

        if (GUILayout.Button("自动绑定"))
        {
            itemList.arraySize = 0;
            CheckOutGameObject(Root);
            serializedObject.ApplyModifiedProperties();
        }
        if (GUILayout.Button("生成绑定代码"))
        {
            CreateFile();
        }
        EditorGUILayout.Space();
        GUILayout.TextArea("AutoBindTips:");
        
        for(int i=0;i< TipsKeys.Count;i++)
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.TextArea(TipsKeys[i]);
            GUILayout.TextArea(AutoBindTips[TipsKeys[i]]);
            EditorGUILayout.EndHorizontal();
        }
        

        EditorGUILayout.EndVertical();
    }

    private void CheckOutGameObject(GameObject obj)
    {
        //Debug.LogError(obj.name);
        
        string temp_str = TestBindName(obj.name);
        if (temp_str!="")
        {
            itemList.arraySize += 1;
            SerializedProperty item = itemList.GetArrayElementAtIndex(itemList.arraySize - 1);
            item.FindPropertyRelative("name").stringValue = obj.name;
            item.FindPropertyRelative("typename").stringValue = AutoBindTips[temp_str];
            item.FindPropertyRelative("obj").objectReferenceValue = obj;
        }
        

        for (int i=0;i<obj.transform.childCount;i++)
        {
            CheckOutGameObject(obj.transform.GetChild(i).gameObject);

            //itemList.arraySize += 1;
            //SerializedProperty item2 = itemList.GetArrayElementAtIndex(itemList.arraySize - 1);
            //item2.FindPropertyRelative("name").stringValue = obj.name;
        }
    }

    private string TestBindName(string name)
    {
        for (int i = 0; i < TipsKeys.Count; i++)
        {
            if (name.Length < TipsKeys[i].Length)
            {
                continue;
            }
            bool flag = true;
            for (int j = 0; j < TipsKeys[i].Length; j++)
            {
                if (name[j] != TipsKeys[i][j])
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                return TipsKeys[i];
            } 
        }
        return "";
    }
    

    private void CreateFile()
    {
        CreateMainFile();
        CreateBindFile();
        Debug.Log("Creat File OK!");
    }

    private void CreateMainFile()
    {
        if(!CodeCreate.TestFileExists(UIFormPath,Root.name+".cs"))
        {
            List<string> button_list = new List<string>();

            for (int i = 0; i < itemList.arraySize; i++)
            {
                if(itemList.GetArrayElementAtIndex(i).FindPropertyRelative("typename").stringValue=="Button")
                {
                    button_list.Add(itemList.GetArrayElementAtIndex(i).FindPropertyRelative("name").stringValue);
                }
            }

            CodeCreate.CreateORwriteConfigFile(UIFormPath, Root.name + ".cs", CodeCreate.UIFormGenertion(button_list,Root.name), 1);
        }
    }

    private void CreateBindFile()
    {
        List<string> name_list = new List<string>();
        List<string> type_list = new List<string>();

        for(int i=0;i< itemList.arraySize;i++)
        {
            name_list.Add(itemList.GetArrayElementAtIndex(i).FindPropertyRelative("name").stringValue);
            type_list.Add(itemList.GetArrayElementAtIndex(i).FindPropertyRelative("typename").stringValue);
        }

        CodeCreate.CreateORwriteConfigFile(UIFormBindPath, Root.name + ".Bind.cs", CodeCreate.UIFormBindGenertion(name_list, type_list, Root.name), 0);
    }
}
