using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System;
using System.Threading.Tasks; //�ؼ��İ�

using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;

public class NetSystem : MonoBehaviour 
{
    private NetSystem()
    {
        instance = this;
    }
    //����ģʽ
    private static NetSystem instance;
    public static NetSystem Instance
    {
        get { return instance; }
    }

    /// <summary>
    /// �޲η��ʽӿ�
    /// </summary>
    /// <typeparam name="T">����ʵ��NetObj�ӿ�</typeparam>
    /// <param name="url">�ӿڵ�ַ</param>
    /// <returns>һ��T���͵Ľ��������null</returns>
    public async Task<NetObj> LoadDataSimple<T>(string url)where T : NetObj
    {
        var Request = UnityWebRequest.Post(url,"");
        await Request.SendWebRequest();
        var text = Request.downloadHandler.text;
        try
        {
            return JsonMapper.ToObject<T>(text);
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
            return null;
        }
        
    }

    /// <summary>
    /// �вη��ʽӿ�
    /// </summary>
    /// <typeparam name="T">����ʵ��NetObj�ӿ�</typeparam>
    /// <param name="url">�ӿڵ�ַ</param>
    /// <param name="form">������</param>
    /// <param name="succeed">�ɹ����ʺ���</param>
    /// <param name="fail">ʧ�ܷ��ʺ���</param>
    /// <returns>һ��T���͵Ľ��������null</returns>
    public async Task<NetObj> LoadData<T>(string url,WWWForm form=null,Action<System.Object> succeed=null,Action fail=null) where T : NetObj
    {
        UnityWebRequest Request = null;
        if (form != null)
        {
            Request = UnityWebRequest.Post(url, form);
        }
        else
        {
            Request = UnityWebRequest.Post(url, "");
        }
        
        await Request.SendWebRequest();
        var text = Request.downloadHandler.text;

        if (Request.result == UnityWebRequest.Result.ProtocolError || 
            Request.result == UnityWebRequest.Result.ConnectionError||
            Request.result == UnityWebRequest.Result.DataProcessingError)
        {
            if(fail!=null)
            {
                fail();
            }
            Debug.LogError("Net Error!");
            return null;
        }
        else
        {
            
            try
            {
                T obj = JsonMapper.ToObject<T>(text);
                if (succeed != null)
                {
                    succeed(obj);
                }
                return obj;
            }
            catch (Exception ex)
            {
                if (fail != null)
                {
                    fail();
                }
                Debug.LogError(ex.Message);
                return null;
            }
        }
    }

    public async Task<Texture> LoadImg(string url)
    {
        UnityWebRequest Request = null;
        Request = UnityWebRequestTexture.GetTexture(url);
        await Request.SendWebRequest();
        

        if (Request.result == UnityWebRequest.Result.ProtocolError ||
            Request.result == UnityWebRequest.Result.ConnectionError ||
            Request.result == UnityWebRequest.Result.DataProcessingError)
        {
            Debug.LogError("Net Error!");
            return null;
        }
        else
        {

            try
            {
                Texture2D download = ((DownloadHandlerTexture)Request.downloadHandler).texture; 
                //Sprite sprite = Sprite.Create(download, new Rect(0, 0, download.width, download.height), new Vector2(0, 0));
                return download;
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
                return null;
            }
        }
    }
}

public static class ExtensionMethods
{
    public static TaskAwaiter GetAwaiter(this AsyncOperation asyncOp)
    {
        var tcs = new TaskCompletionSource<object>();
        asyncOp.completed += obj => { tcs.SetResult(null); };
        return ((Task)tcs.Task).GetAwaiter();
    }
}
