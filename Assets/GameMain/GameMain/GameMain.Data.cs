using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCs;

public partial class GameMain
{
    public SceneStateC sceneStateC;

    public StartState StartState;
    public MainState MainState;

    public void StateInit()
    {
        sceneStateC = new SceneStateC();

        StartState = new StartState(sceneStateC);
        MainState = new MainState(sceneStateC);

        sceneStateC.AddState(Data_StateName.StartState_name, StartState);
        sceneStateC.AddState(Data_StateName.MainState_name, MainState);
    }
}
