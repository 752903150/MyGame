using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataCs;
using MyGameFrameWork;

//CreateTime：2022/5/10 15:10:26
public partial class LeftGameItem : UIItem
{
	private int gameid;
	private string gamename;
	private string gameicon;
	private string localpath;
	public override void Awake()
	{
		base.Awake();
		InitComponent(); 
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		RegisterEvent(); 
	}

	public override void OnClose()
	{
		base.OnClose();
		ReleaseEvent(); 
	}

	private void RegisterEvent()
	{
		m_btnMyGame.onClick.AddListener(OnBtnMyGame);
	}

	private void ReleaseEvent()
	{
		m_btnMyGame.onClick.RemoveListener(OnBtnMyGame);
	}

	private async void OnBtnMyGame()
	{
		((MainForm)uiForm).ShowGameContent(gameid.ToString(),m_rawimgHead.texture);
		
	}

	public void SetData(Get_User_Game_Item item)
	{
		if(item==null)
        {
			Debug.LogError("类型为空！");
			return;
        }
		gameid = item.gameid;
		gamename = item.gamename;
		gameicon = item.gameicon;
		localpath = item.localpath;

		ReFresh();
	}

	public void SetData(int _gameid, string _gamename, string _gameicon,string _localpath)
    {
		gameid = _gameid;
		gamename = _gamename;
		gameicon = _gameicon;	
		localpath = _localpath;

		ReFresh();
	}

	public async void ReFresh()
    {
		m_txtGame.text = gamename;
		m_rawimgHead.texture = await NetSystem.Instance.LoadImg(gameicon);
    }

	
}

