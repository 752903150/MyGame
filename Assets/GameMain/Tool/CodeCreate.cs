using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using System.IO;
using System.Text.RegularExpressions;

public static class CodeCreate
{
    static Dictionary<string, int> NormalTypeDic = new Dictionary<string, int>()
    {
        {"int",0},
        {"string",1},
        {"char",2},
        {"float",3},
        {"double",4},
        {"bool",5},
    };



    /// <summary>
    /// �����޹���������
    /// </summary>
    /// <param name="arr_type_list">����</param>
    /// <param name="arr_name_list">��������</param>
    /// <param name="temp_lists">ֵ��</param>
    /// <param name="name">�ļ�����</param>
    /// <returns></returns>
    public static string NoLineGenertion(string[] arr_type_list, string[] arr_name_list, List<string[]> temp_lists, string name)
    {
        if (arr_type_list == null || arr_name_list == null || temp_lists == null)
        {
            return "!���ܴ��ڿ�������";
        }
        if (arr_type_list.Length == 0 || arr_name_list.Length == 0 || temp_lists.Count == 0)
        {
            return "!���ܴ��ڿ���";
        }
        if (arr_type_list.Length != arr_name_list.Length)
        {
            return "!���������г��Ȳ�һ��";
        }
        for (int i = 0; i < temp_lists.Count; i++)
        {
            if (temp_lists[i].Length != arr_type_list.Length)
            {
                return "!����key: " + temp_lists[i][0] + "�����г��������Գ��Ȳ�һ��";
            }
        }
        if (arr_type_list[0] == " " || (arr_type_list[0][0] != '!' && arr_type_list[0][0] != '@') ||
           arr_name_list[0] == " " || (arr_name_list[0][0] != '!' && arr_name_list[0][0] != '@'))
        {
            return "!���������ʶ������ȷ";
        }
        if (arr_name_list[0][0] != arr_type_list[0][0])
        {
            return "!���������ʶ����ƥ��";
        }
        for (int i = 1; i < arr_type_list.Length; i++)
        {
            if (!NormalTypeDic.ContainsKey(arr_type_list[i]))
            {
                return "!�������Ͳ�׼ȷ";
            }
        }
        for (int i = 1; i < arr_name_list.Length; i++)
        {
            if (!isVaileName(arr_name_list[i]))
            {
                return "!����������׼ȷ";
            }
        }

        StringBuilder sb = new StringBuilder(400);

        sb.Append("using System.Collections;\nusing System.Collections.Generic;\n\n");
        sb.Append("//CreateTime��" + DateTime.Now.ToString() + "\n");
        sb.Append("namespace DataCs\n{\n\tpublic static class Data_" + name + "\n\t{\n");

        for (int i = 0; i < temp_lists.Count; i++)
        {
            for (int j = 1; j < temp_lists[i].Length; j++)
            {
                if (arr_type_list[j] == "string")
                {
                    sb.Append("\t\tpublic static " + arr_type_list[j]
                    + " " + temp_lists[i][0]
                    + "_" + arr_name_list[j]
                    + " = \"" + temp_lists[i][j]
                    + "\";\n");
                }
                else if (arr_type_list[j] == "char")
                {
                    sb.Append("\t\tpublic static " + arr_type_list[j]
                    + " " + temp_lists[i][0]
                    + "_" + arr_name_list[j]
                    + " = \'" + temp_lists[i][j]
                    + "\';\n");
                }
                else
                {
                    sb.Append("\t\tpublic static " + arr_type_list[j]
                    + " " + temp_lists[i][0]
                    + "_" + arr_name_list[j]
                    + " = " + temp_lists[i][j]
                    + ";\n");
                }
            }
            sb.Append("\n");
        }
        sb.Append("\t}\n}\n");
        return sb.ToString();
    }

    /// <summary>
    /// �����޹���������
    /// </summary>
    /// <param name="arr_type_list">����</param>
    /// <param name="arr_name_list">��������</param>
    /// <param name="temp_lists">ֵ��</param>
    /// <param name="name">�ļ�����</param>
    /// <returns></returns>
    public static string LineGenertion(string[] arr_type_list, string[] arr_name_list, List<string[]> temp_lists, string name)
    {
        if (arr_type_list == null || arr_name_list == null || temp_lists == null)
        {
            return "!���ܴ��ڿ�������";
        }
        if (arr_type_list.Length == 0 || arr_name_list.Length == 0 || temp_lists.Count == 0)
        {
            return "!���ܴ��ڿ�������";
        }
        if (arr_type_list.Length != arr_name_list.Length)
        {
            return "!���������г��Ȳ�һ��";
        }
        for(int i=0;i<temp_lists.Count;i++)
        {
            if (temp_lists[i].Length != arr_type_list.Length)
            {
                return "!����Key:"+ temp_lists[i][0]+ "�����г��������Գ��Ȳ�һ��";
            }
        }
        
        if (arr_type_list[0] == " " || (arr_type_list[0][0] != '!' && arr_type_list[0][0] != '@') ||
           arr_name_list[0] == " " || (arr_name_list[0][0] != '!' && arr_name_list[0][0] != '@'))
        {
            return "!���������ʶ������ȷ";
        }
        if (arr_name_list[0][0] != arr_type_list[0][0])
        {
            return "!���������ʶ����ƥ��";
        }
        for (int i = 1; i < arr_type_list.Length; i++)
        {
            if (!NormalTypeDic.ContainsKey(arr_type_list[i]))
            {
                return "!�������Ͳ�׼ȷ";
            }
        }
        for (int i = 1; i < arr_name_list.Length; i++)
        {
            if (!isVaileName(arr_name_list[i]))
            {
                return "!����"+ arr_name_list[i] + "������׼ȷ";
            }
        }


        StringBuilder sb = new StringBuilder(400);

        sb.Append("using System.Collections;\n");
        sb.Append("using System.Collections.Generic;\n\n");
        sb.Append("//CreateTime��" + DateTime.Now.ToString() + "\n");
        sb.Append("namespace DataCs\n{\n");
        sb.Append("\tpublic struct Data_" + name + "_Struct\n");
        sb.Append("\t{\n");
        sb.Append("\t\tpublic string key;\n");

        for (int i = 1; i < arr_type_list.Length; i++)
        {
            sb.Append("\t\tpublic " + arr_type_list[i] + " " + arr_name_list[i] + ";\n");
        }

        sb.Append("\n");
        sb.Append("\t\tpublic Data_" + name + "_Struct(string _key");


        for (int i = 1; i < arr_type_list.Length; i++)
        {
            sb.Append(", " + arr_type_list[i] + " _" + arr_name_list[i]);
        }
        sb.Append(")\n");
        sb.Append("\t\t{\n");
        sb.Append("\t\t\tkey = _key;\n");

        for (int i = 1; i < arr_name_list.Length; i++)
        {
            sb.Append("\t\t\t" + arr_name_list[i] + " = _" + arr_name_list[i] + ";\n");
        }

        sb.Append("\t\t}\n");
        sb.Append("\t}\n\n");

        sb.Append("\tpublic static class Data_" + name + "\n");
        sb.Append("\t{\n");
        sb.Append("\t\tpublic static Dictionary<string, Data_");
        sb.Append(name);
        sb.Append("_Struct> Dic = new Dictionary<string, Data_" + name + "_Struct>()\n");
        sb.Append("\t\t{\n");

        for (int i = 0; i < temp_lists.Count; i++)
        {
            sb.Append("\t\t\t{\"" + temp_lists[i][0] + "\",new Data_" + name + "_Struct(\"" + temp_lists[i][0] + "\"");
            for (int j = 1; j < temp_lists[i].Length; j++)
            {
               // Debug.LogError(j);
                if (arr_type_list[j] == "string")
                {
                    sb.Append(",\"" + temp_lists[i][j] + "\"");
                }
                else if (arr_type_list[j] == "char")
                {
                    sb.Append(",\'" + temp_lists[i][j] + "\'");
                }
                else
                {
                    sb.Append("," + temp_lists[i][j]);
                }
            }
            sb.Append(")},\n");
        }

        sb.Append("\t\t};");
        sb.Append("\n");

        for (int i = 0; i < temp_lists.Count; i++)
        {
            sb.Append("\t\tpublic static string key_");
            sb.Append(temp_lists[i][0]);
            sb.Append(" = \"");
            sb.Append(temp_lists[i][0]);
            sb.Append("\";\n");
        }

        sb.Append("\t}\n}\n");
        return sb.ToString();

    }

    /// <summary>
    /// ����UI����������
    /// </summary>
    /// <param name="button_list"></param>
    /// <param name="class_name"></param>
    /// <returns></returns>
    public static string UIFormGenertion(List<string> button_list,string class_name)
    {
        if (class_name == "")
        {
            return "!����Ϊ��";
        }

        StringBuilder sb = new StringBuilder(400);

        sb.Append("using System.Collections;\n");
        sb.Append("using System.Collections.Generic;\n");
        sb.Append("using UnityEngine;\n");
        sb.Append("using UnityEngine.UI;\n\n");
        sb.Append("//CreateTime��" + DateTime.Now.ToString() + "\n");

        sb.Append("public partial class ");
        sb.Append(class_name);
        sb.Append(" : UIForm\n");
        sb.Append("{\n");

        sb.Append("\tpublic override void Awake()\n");
        sb.Append("\t{\n");
        sb.Append("\t\tbase.Awake();\n");
        sb.Append("\t\tInitComponent(); \n");
        sb.Append("\t}\n\n");

        sb.Append("\tpublic override void OnOpen(System.Object obj)\n");
        sb.Append("\t{\n");
        sb.Append("\t\tbase.OnOpen(obj);\n");
        sb.Append("\t\tRegisterEvent(); \n");
        sb.Append("\t}\n\n");

        sb.Append("\tpublic override void OnClose()\n");
        sb.Append("\t{\n");
        sb.Append("\t\tbase.OnClose();\n");
        sb.Append("\t\tReleaseEvent(); \n");
        sb.Append("\t}\n\n");


        sb.Append("\tprivate void RegisterEvent()\n");
        sb.Append("\t{\n");
        if(button_list!=null && button_list.Count !=0)
        {
            for(int i=0;i<button_list.Count;i++)
            {
                sb.Append("\t\t");
                sb.Append(button_list[i]);
                sb.Append(".onClick.AddListener(OnBtn");
                sb.Append(button_list[i].Substring(5));
                sb.Append(");\n");
            }
        }
        else
        {
            sb.Append("\t\t\n");
        }
        sb.Append("\t}\n\n");

        sb.Append("\tprivate void ReleaseEvent()\n");
        sb.Append("\t{\n");
        if (button_list != null && button_list.Count != 0)
        {
            for (int i = 0; i < button_list.Count; i++)
            {
                sb.Append("\t\t");
                sb.Append(button_list[i]);
                sb.Append(".onClick.RemoveListener(OnBtn");
                sb.Append(button_list[i].Substring(5));
                sb.Append(");\n");
            }
        }
        else
        {
            sb.Append("\t\t\n");
        }
        sb.Append("\t}\n\n");

        if (button_list != null && button_list.Count != 0)
        {
            for (int i = 0; i < button_list.Count; i++)
            {
                sb.Append("\tprivate void OnBtn");
                sb.Append(button_list[i].Substring(5));
                sb.Append("()\n");
                sb.Append("\t{\n");
                sb.Append("\t\t\n");
                sb.Append("\t}\n");
            }
        }

        sb.Append("\n}\n");

        return sb.ToString();
    }

    /// <summary>
    /// ����UI����󶨴���
    /// </summary>
    /// <param name="name_list"></param>
    /// <param name="type_list"></param>
    /// <param name="class_name"></param>
    /// <returns></returns>
    public static string UIFormBindGenertion(List<string> name_list,List<string> type_list,string class_name)
    {
        if(name_list == null || type_list == null)
        {
            return "!�б�Ϊnull";
        }
        if (name_list.Count == 0 || type_list.Count == 0)
        {
            return "!�б�Ϊ��";
        }
        if(class_name == "")
        {
            return "!����Ϊ��";
        }

        StringBuilder sb = new StringBuilder(400);

        sb.Append("using System.Collections;\n");
        sb.Append("using System.Collections.Generic;\n");
        sb.Append("using UnityEngine;\n");
        sb.Append("using UnityEngine.UI;\n\n");
        sb.Append("//CreateTime��" + DateTime.Now.ToString() + "\n");

        sb.Append("public partial class " + class_name + "\n");
        sb.Append("{\n");
        sb.Append("\tprivate AutoBind autoBind;\n");
        for(int i=0;i<name_list.Count;i++)
        {
            sb.Append("\tprivate " + type_list[i] + " " + name_list[i] + ";\n");
        }

        sb.Append("\n\tprivate void InitComponent()\n");
        sb.Append("\t{\n");
        sb.Append("\t\tautoBind = GetComponent<AutoBind>();\n");
        for (int i = 0; i < name_list.Count; i++)
        {
            sb.Append("\t\t"+name_list[i] + " = autoBind.itemList[");
            sb.Append(i.ToString());
            sb.Append("].obj.GetComponent<");
            sb.Append(type_list[i]);
            sb.Append(">();\n");
        }

        sb.Append("\t}\n}\n");
        return sb.ToString();
    }

    public static string EventArgsGenertion(List<string> name_list,List<string> type_list,string class_name)
    {
        if(name_list == null|| type_list == null)
        {
            return "!���ڿ���";
        }
        if (class_name == null)
        {
            return "!��������Ϊ�գ�";
        }
        if(!isVaileName(class_name))
        {
            return "!����������Ҫ��";
        }

        for (int i = 0; i < type_list.Count; i++)
        {
            if (!NormalTypeDic.ContainsKey(type_list[i]))
            {
                return "!�������Ͳ�׼ȷ";
            }
        }

        for (int i = 0; i < name_list.Count; i++)
        {
            if (!isVaileName(name_list[i]))
            {
                return "!���ڲ���������׼ȷ";
            }
        }

        StringBuilder sb = new StringBuilder(400);

        sb.Append("using System.Collections;\n");
        sb.Append("using System.Collections.Generic;\n");
        sb.Append("using UnityEngine;\n");
        sb.Append("//CreateTime��" + DateTime.Now.ToString() + "\n");

        sb.Append("public class ");
        sb.Append(class_name);
        sb.Append("EventArgs : IEventArgs\n");

        sb.Append("{\n");
        for(int i=0;i<name_list.Count;i++)
        {
            sb.Append("\tpublic ");
            sb.Append(type_list[i]);
            sb.Append(" ");
            sb.Append(name_list[i]);
            sb.Append(";\n");
        }

        sb.Append("\tpublic ");
        sb.Append(class_name);
        sb.Append("EventArgs(");
        for(int i=0;i<name_list.Count;i++)
        {
            sb.Append(type_list[i]);
            sb.Append(" _");
            sb.Append(name_list[i]);
            if(i < name_list.Count-1)
            {
                sb.Append(", ");
            }
        }
        sb.Append(")\n");
        sb.Append("\t{\n");
        for(int i=0;i<name_list.Count;i++)
        {
            sb.Append("\t\t");
            sb.Append(name_list[i]);
            sb.Append(" = _");
            sb.Append(name_list[i]);
            sb.Append(";\n");
        }
        sb.Append("\t}\n\n");

        sb.Append("\tpublic static ");
        sb.Append(class_name);
        sb.Append("EventArgs Create(");
        for (int i = 0; i < name_list.Count; i++)
        {
            sb.Append(type_list[i]);
            sb.Append(" ");
            sb.Append(name_list[i]);
            if (i < name_list.Count - 1)
            {
                sb.Append(", ");
            }
        }
        sb.Append(")\n");
        sb.Append("\t{\n");
        sb.Append("\t\treturn new ");
        sb.Append(class_name);
        sb.Append("EventArgs(");
        for (int i = 0; i < name_list.Count; i++)
        {
            sb.Append(name_list[i]);
            if (i < name_list.Count - 1)
            {
                sb.Append(", ");
            }
        }
        sb.Append(");\n");
        sb.Append("\t}\n");
        sb.Append("}\n");

        return sb.ToString();
    }

    /// <summary>
    /// �ж������Ƿ�淶
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private static bool isVaileName(string name)
    {
        if (name == "")
        {
            return false;
        }
        if (!((name[0] >= 'a' && name[0] <= 'z') || (name[0] >= 'A' && name[0] <= 'Z') || name[0] == '_'))
        {
            return false;
        }
        for (int i = 1; i < name.Length; i++)
        {
            if (!((name[i] >= 'a' && name[i] <= 'z') || (name[i] >= 'A' && name[i] <= 'Z') || name[i] == '_' || (name[i] > '0' && name[i] < '9')))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// ��ָ��·��д�ļ�
    /// </summary>
    /// <param name="path">����·��</param>
    /// <param name="name">�ļ�������Ҫ��׺</param>
    /// <param name="info">�ļ�����</param>
    /// <param name="model">��дģʽ��0��ʾ����д��1��ʾ�����ظ���д</param>
    public static void CreateORwriteConfigFile(string path, string name, string info, int model = 0)
    {
        if (info.Length == 0)
        {
            Debug.LogError("Create " + name + " error!");
            return;
        }
        if (info[0] == '!')
        {
            Debug.LogError("Create " + name + " error!\n" + info);
            return;
        }

        
        FileInfo t = new FileInfo(path + "//" + name);

        if(t.Exists && model == 1)
        {
            return;
        }

        StreamWriter sw;
        if (!t.Exists)
        {
            sw = t.CreateText();
        }
        else
        {
            t.Delete();
            sw = t.CreateText();
        }
        Regex reg = new Regex(@"(?i)\\[uU]([0-9a-f]{4})");
        string str = reg.Replace(info, delegate (Match m) { return ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString(); });
        sw.WriteLine(str);
        sw.Close();
        sw.Dispose();
    }

    public static bool TestFileExists(string path, string name)
    {
        FileInfo t = new FileInfo(path + "//" + name);

        if (t.Exists)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
