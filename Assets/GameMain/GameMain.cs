using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCs;

public partial class GameMain : MonoBehaviour
{
    private void Awake()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
        
    }
    void Start()
    {
        Debug.Log("GameMainStart");

        StateInit();//×´Ì¬³õÊ¼»¯

        sceneStateC.SetState(Data_StateName.StartState_name);
    }

    // Update is called once per frame
    void Update()
    {
        sceneStateC.Update();
    }
}
