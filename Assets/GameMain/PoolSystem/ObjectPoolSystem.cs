using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolSystem 
{
    //单例模式
    private static ObjectPoolSystem instance = new ObjectPoolSystem();
    public static ObjectPoolSystem Instance
    {
        get { return instance; }
    }

    static Dictionary<int, Queue<GameObject>> GameObjectPool = new Dictionary<int, Queue<GameObject>>();//对象池字典

    static Dictionary<int, Queue<UIForm>> UIFormPool = new Dictionary<int, Queue<UIForm>>();//UIFORM池字典

    static Dictionary<int, Queue<AudioClip>> AudioClipPool = new Dictionary<int, Queue<AudioClip>>();//AudioClip池字典

    public bool ReBackGameObjectPool(int id, GameObject obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (!GameObjectPool.ContainsKey(id))
        {
            GameObjectPool.Add(id, new Queue<GameObject>());
        }
        obj.SetActive(false);
        GameObjectPool[id].Enqueue(obj);

        return true;
    }

    public bool ReBackUIFormPool(int id, UIForm uIForm)
    {
        if(uIForm == null)
        {
            return false;
        }

        if (!UIFormPool.ContainsKey(id))
        {
            UIFormPool.Add(id, new Queue<UIForm>());
        }
        uIForm.gameObject.SetActive(false);
        UIFormPool[id].Enqueue(uIForm);
        return true;
    }

    public bool ReBackAudioClipPool(int id, AudioClip audioClip)
    {
        if (audioClip == null)
        {
            return false;
        }

        if (!AudioClipPool.ContainsKey(id))
        {
            AudioClipPool.Add(id, new Queue<AudioClip>());
        }
        AudioClipPool[id].Enqueue(audioClip);
        return true;
    }

    public GameObject GetGameObjectFormPool(int id)
    {
        if (GameObjectPool.ContainsKey(id) && GameObjectPool[id].Count != 0)//取池
        {
            GameObject temp = GameObjectPool[id].Dequeue();
            return temp;
        }
        return null;
    }

    public UIForm GetUIFormFormPool(int id)
    {
        if (UIFormPool.ContainsKey(id) && UIFormPool[id].Count != 0)//取池
        {
            UIForm temp = UIFormPool[id].Dequeue();
            temp.gameObject.SetActive(true);
            return temp;
        }
        return null;
    }

    public AudioClip GetAudioClipFormPool(int id)
    {
        if (AudioClipPool.ContainsKey(id) && AudioClipPool[id].Count != 0)//取池
        {
            AudioClip temp = AudioClipPool[id].Dequeue();
            return temp;
        }
        return null;
    }

    public bool TestGameObjectPool(int id)
    {
        if (GameObjectPool.ContainsKey(id) && GameObjectPool[id].Count != 0)//取池
        {
            return true;
        }
        return false;
    }

    public bool TestUIFormPool(int id)
    {
        if (UIFormPool.ContainsKey(id) && UIFormPool[id].Count != 0)//取池
        {
            return true;
        }
        return false;
    }

    public bool TestAudioClipPool(int id)
    {
        if (AudioClipPool.ContainsKey(id) && AudioClipPool[id].Count != 0)//取池
        {
            return true;
        }
        return false;
    }
}
