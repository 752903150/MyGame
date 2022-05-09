using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCs;

public class StartState : ISceneState
{
    bool isLogin;
    public StartState(SceneStateC c) : base(c)
    {
        this.StateName = "StartState";
    }

    public override void StateBegin(System.Object obj)
    {
        UISystem.Instance.OpenUIForm(Data_UIFormID.key_LoginForm);
        isLogin = false;
        EventManagerSystem.Instance.Add2(Data_EventName.OnLoginSucceed_str, LoginSucceed);
    }

    public override void StateUpdate()
    {
        if(isLogin)//��¼�ɹ���ת
        {
            m_Contorller.SetState(Data_StateName.MainState_name);
        }
    }

    public override void StateEnd()
    {
        
    }

    private void LoginSucceed(IEventArgs eventArgs)
    {
        LoginSucceedEventArgs loginSucceedEventArgs = eventArgs as LoginSucceedEventArgs;
        isLogin = true;
        Debug.LogError(loginSucceedEventArgs.username);
    }
}
