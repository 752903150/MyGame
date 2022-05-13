using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//CreateTime：2022/5/13 13:18:11
public partial class MainHeadItem : UIItem
{
	string des;
	int rank;
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
		m_btnMainHead.onClick.AddListener(OnBtnMainHead);
	}

	private void ReleaseEvent()
	{
		m_btnMainHead.onClick.RemoveListener(OnBtnMainHead);
	}

	private void OnBtnMainHead()
	{
		
	}

	/// <summary>
	/// 设置描述和排序
	/// </summary>
	/// <param name="_des"></param>
	/// <param name="_rank"></param>
	public void SetData(string _des,int _rank)
    {
		des = _des;
		rank = _rank;

		RefreahData();

	}

	private void RefreahData()
    {
		m_txtMainHead.text = des;
    }

}

