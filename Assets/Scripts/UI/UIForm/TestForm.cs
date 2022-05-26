using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;
using XLua;
using System;

//CreateTime：2022/5/26 15:55:01
[LuaCallCSharp]
public partial class TestForm : UIForm
{
	public TextAsset luaScript;
	internal static LuaEnv luaEnv = new LuaEnv();
	internal static float lastGCTime = 0;
	internal const float GCInterval = 1;
	private Action<System.Object> luaOnOpen;
	private Action luaUpdate;
	private Action luaOnClose;
	private LuaTable scriptEnv;
	public override void Awake()
	{
		base.Awake();
		InitComponent(); 
		if(luaScript == null)
        {
			Debug.LogError("请绑定热更脚本代码");
			return;
        }
		scriptEnv = luaEnv.NewTable();
		LuaTable meta = luaEnv.NewTable();
		meta.Set("__index", luaEnv.Global);
		scriptEnv.SetMetaTable(meta);
		meta.Dispose();
		AddLua();
		luaEnv.DoString(luaScript.text, "TestForm", scriptEnv);
		Action luaAwake = scriptEnv.Get<Action>("Awake");
		scriptEnv.Get("OnOpen", out luaOnOpen);
		scriptEnv.Get("Update", out luaUpdate);
		scriptEnv.Get("OnClose", out luaOnClose);
		if (luaAwake != null)
		{
			luaAwake();
		}
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		RegisterEvent(); 
		if (luaOnOpen != null)
		{
			luaOnOpen(obj);
		}
	}

	public override void OnClose()
	{
		base.OnClose();
		ReleaseEvent(); 
		if (luaOnClose != null)
		{
			luaOnClose();
		}
	}

	public override void Update()
	{
		base.Update();
		if (luaUpdate != null)
		{
			luaUpdate();
		}
		if (Time.time - lastGCTime > GCInterval)
		{
			luaEnv.Tick();
			lastGCTime = Time.time;
		}
	}
	private void RegisterEvent()
	{
		
	}

	private void ReleaseEvent()
	{
		
	}

}

