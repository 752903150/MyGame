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

	private async void RefreshMainPanel()
    {
		WWWForm www = new WWWForm();
		www.AddField(Data_WebRequest.Get_User_Game_Param1_name, "201921098271");
		bool flag = false;
		Get_User_Game t = await NetSystem.Instance.LoadData<Get_User_Game>(
			Data_WebRequest.Get_User_GameUrl_name,
			www,
            (res) =>
            {
				Get_User_Game temp = res as Get_User_Game;
				if(temp==null|| temp.get_User_Game_Items==null)
                {
					Debug.LogError("类型为空！");
                }
				else
                {
					int add_num = temp.get_User_Game_Items.Count - leftGameItems.Count;
					if(add_num<0)
                    {
						for (int i = 0; i < add_num; i++)
						{
							UISystem.Instance.CloseUIItem(Data_UIItemID.key_LeftGameItem, leftGameItems[0]);
							leftGameItems.RemoveAt(0);
						}
					}
					else
                    {
						for (int i = 0; i < add_num; i++)
						{
							leftGameItems.Add(UISystem.Instance.OpenUIItem(Data_UIItemID.key_LeftGameItem, this) as LeftGameItem);
						}
					}
					
					for(int i=0;i< leftGameItems.Count;i++)
                    {
						leftGameItems[i].transform.SetParent(m_rectContent.transform);
						leftGameItems[i].SetData(temp.get_User_Game_Items[i]);
					}
				}
				
			},
			() =>
			{
				Debug.LogError("网络错误");
				flag = true;
			}
		) as Get_User_Game;
		if(flag)
        {
			return;
        }
		
    }

	private void RefreshTestPanel()
	{

	}

}

