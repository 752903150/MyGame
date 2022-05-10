using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//CreateTime：2022/5/10 15:10:26
public partial class LeftGameItem : UIItem
{
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

	private void OnBtnMyGame()
	{
		
	}

}

