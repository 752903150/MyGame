using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using DataCs;

//CreateTime：2022/5/10 15:15:49
public partial class MainForm : UIForm
{

	string username;

	List<LeftGameItem> leftGameItems;
	List<MainHeadItem> mainHeadItems;
	List<SlideShowItem> slideShowItems;

	float slide_curr_time;//轮播图当前运行时间
	float slide_interval_time;//轮播图间隔时间
	float slide_shs_time;//轮播图显示与隐藏时间
	int slide_curr_num;//轮播图标志数

	public override void Awake()
	{
		base.Awake();
		InitComponent(); 
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);

		if(obj==null)
        {
			username = "201921098271";
		}
        else
        {
			username = obj.ToString();
		}
		

		RegisterEvent();
		ReSetData();
		OnBtnMainPanel();
	}

	public override void OnClose()
	{
		base.OnClose();
		ReleaseEvent(); 
	}

    public override void Update()
    {
        base.Update();
		slide_curr_time += Time.deltaTime;
		
		if (slide_curr_time > slide_interval_time)
        {
			slide_curr_time = 0f;
			SlideFunc();
        }

	}

    private void ReSetData()
    {

		m_rectMainHead.gameObject.SetActive(false);
		m_rectMainMid.gameObject.SetActive(false);
		leftGameItems = new List<LeftGameItem>();
		mainHeadItems = new List<MainHeadItem>();
		slideShowItems = new List<SlideShowItem>();

		slide_curr_num = 0;
		slide_curr_time = 0f;
		slide_interval_time = float.Parse(Data_StaticData.slide_interval_time_val);
		slide_shs_time = float.Parse(Data_StaticData.slide_shs_time_val);
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

	private void RefreshTestPanel()
	{

	}
	/// <summary>
	/// 轮播运行逻辑
	/// </summary>
	public void SlideFunc()
    {
		if(slideShowItems.Count<1)
        {
			return;
        }
		int num = slideShowItems.Count;
		slideShowItems[slide_curr_num % num].HideByAnimation();
		slideShowItems[(slide_curr_num + 1) % num].ShowByAnimation();
		slide_curr_num++;
	}

}

