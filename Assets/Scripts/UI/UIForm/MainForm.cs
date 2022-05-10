using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using DataCs;

//CreateTime：2022/5/10 15:15:49
public partial class MainForm : UIForm
{

	List<LeftGameItem> leftGameItems;

	public override void Awake()
	{
		base.Awake();
		InitComponent(); 
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		RegisterEvent();
		ReSetData();
		OnBtnMainPanel();
	}

	public override void OnClose()
	{
		base.OnClose();
		ReleaseEvent(); 
	}

	private void ReSetData()
    {
		leftGameItems = new List<LeftGameItem>();
		for (int i = 0; i < 10; i++)
		{
			leftGameItems.Add(UISystem.Instance.OpenUIItem(Data_UIItemID.key_LeftGameItem, this) as LeftGameItem);
		}
	}

	private void RegisterEvent()
	{
		m_btnSetting.onClick.AddListener(OnBtnSetting);
		m_btnMin.onClick.AddListener(OnBtnMin);
		m_btnClose.onClick.AddListener(OnBtnClose);
		m_btnMainPanel.onClick.AddListener(OnBtnMainPanel);
		m_btnTestPanel.onClick.AddListener(OnBtnTestPanel);
		m_btnLeftMin.onClick.AddListener(OnBtnLeftMin);
		m_btnLeftListMax.onClick.AddListener(OnBtnLeftListMax);
	}

	private void ReleaseEvent()
	{
		m_btnSetting.onClick.RemoveListener(OnBtnSetting);
		m_btnMin.onClick.RemoveListener(OnBtnMin);
		m_btnClose.onClick.RemoveListener(OnBtnClose);
		m_btnMainPanel.onClick.RemoveListener(OnBtnMainPanel);
		m_btnTestPanel.onClick.RemoveListener(OnBtnTestPanel);
		m_btnLeftMin.onClick.RemoveListener(OnBtnLeftMin);
		m_btnLeftListMax.onClick.RemoveListener(OnBtnLeftListMax);
	}

	private void OnBtnSetting()
	{
		
	}
	private void OnBtnMin()
	{
		
	}
	private void OnBtnClose()
	{
		
	}
	private void OnBtnMainPanel()
	{
		m_imgMainPanel_off.gameObject.SetActive(false);
		m_imgMainPanel_on.gameObject.SetActive(true);
		m_imgTestPanel_off.gameObject.SetActive(true);
		m_imgTestPanel_on.gameObject.SetActive(false);

		m_rectTestPanel.gameObject.SetActive(false);
		m_rectMainPanel.gameObject.SetActive(true);
		RefreshMainPanel();
	}
	private void OnBtnTestPanel()
	{
		m_imgMainPanel_off.gameObject.SetActive(true);
		m_imgMainPanel_on.gameObject.SetActive(false);
		m_imgTestPanel_off.gameObject.SetActive(false);
		m_imgTestPanel_on.gameObject.SetActive(true);

		m_rectTestPanel.gameObject.SetActive(true);
		m_rectMainPanel.gameObject.SetActive(false);
		RefreshTestPanel();
	}
	private void OnBtnLeftMin()
	{
		m_imgLeftChooseList.GetComponent<RectTransform>().DOMoveX(-240f, 1f);
		m_btnLeftListMax.gameObject.SetActive(true);
	}
	private void OnBtnLeftListMax()
	{
		m_imgLeftChooseList.GetComponent<RectTransform>().DOMoveX(120f, 1f);
		m_btnLeftListMax.gameObject.SetActive(false);
	}

	private void RefreshMainPanel()
    {
		

		for(int i=0;i<leftGameItems.Count;i++)
        {
			leftGameItems[i].gameObject.transform.SetParent(m_rectContent.transform,false);
        }
    }

	private void RefreshTestPanel()
	{

	}

}

