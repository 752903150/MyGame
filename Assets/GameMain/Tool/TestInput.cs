using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataCs;

public class TestInput : MonoBehaviour
{
    
    
    private void Start()
    {
        
    }

    private async void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TestObj t = await NetSystem.Instance.LoadDataSimple<TestObj>(Data_WebRequest.TestObjUrl_name) as TestObj;

            if (t!=null)
            {
                Debug.LogError(t.ToString());
            }
            else
            {
                Debug.LogError("Error!");
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            WWWForm www = new WWWForm();
            www.AddField(Data_WebRequest.TestObj2Param1_name,"zhukaiwen");
            www.AddField(Data_WebRequest.TestObj2Param2_name, "123456798");
            TestObj2 t = await NetSystem.Instance.LoadData<TestObj2>(
                Data_WebRequest.TestObj2Url_name,
                www,
                (res) =>
                {
                    Debug.LogError("成功");
                },
                ()=>
                {
                    Debug.LogError("失败");
                }
            ) as TestObj2;

            if (t != null)
            {
                Debug.LogError(t.ToString());
            }
            else
            {
                Debug.LogError("Error!");
            }
        }
    }
}
