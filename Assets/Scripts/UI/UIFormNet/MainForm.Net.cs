using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCs;

public partial class MainForm 
{
	/// <summary>
	/// 更新主界面
	/// </summary>
	private async void RefreshMainPanel()
	{
		WWWForm www = new WWWForm();
		www.AddField(Data_WebRequest.Get_User_Game_Param1_name, username);
		bool flag = false;
		await NetSystem.Instance.LoadData<Get_User_Game>(
			Data_WebRequest.Get_User_GameUrl_name,
			www,
			(res) =>
			{
				Get_User_Game temp = res as Get_User_Game;
				if (temp == null || temp.get_User_Game_Items == null)
				{
					Debug.LogError("类型为空！");
				}
				else
				{
					int add_num = temp.get_User_Game_Items.Count - leftGameItems.Count;
					if (add_num < 0)
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

					for (int i = 0; i < leftGameItems.Count; i++)
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
		);
		if (flag)
		{
			return;
		}

	}

	/// <summary>
	/// 更新游戏内容
	/// </summary>
	/// <param name="gameid"></param>
	/// <param name="texture"></param>
	public async void ShowGameContent(string gameid, Texture texture)
	{
		WWWForm www = new WWWForm();
		www.AddField(Data_WebRequest.Get_Game_Content_Param1_name, gameid.ToString());
		bool flag = false;
		await NetSystem.Instance.LoadData<Get_Game_Content>(
			Data_WebRequest.Get_Game_Content_name,
			www,
			(res) =>
			{
				while (mainHeadItems.Count > 0)
				{
					UISystem.Instance.CloseUIItem(Data_UIItemID.key_MainHeadItem, mainHeadItems[mainHeadItems.Count - 1]);
					mainHeadItems.RemoveAt(mainHeadItems.Count - 1);
				}
				while (slideShowItems.Count > 0)
				{
					UISystem.Instance.CloseUIItem(Data_UIItemID.key_SlideShowItem, slideShowItems[slideShowItems.Count - 1]);
					slideShowItems.RemoveAt(slideShowItems.Count - 1);
				}
				Get_Game_Content temp = res as Get_Game_Content;
				if (temp == null || temp.get_Game_Content_Items == null)
				{
					Debug.LogError("类型为空！");
					return;
				}
				for (int i = 0; i < temp.get_Game_Content_Items.Count; i++)
				{
					FuncContentItem(temp.get_Game_Content_Items[i]);
				}
				m_rawimgMainHead.texture = texture;

				slide_curr_num = mainHeadItems.Count - 1;

				m_rectMainHead.gameObject.SetActive(true);
				m_rectMainMid.gameObject.SetActive(true);
			},
			() =>
			{
				Debug.LogError("网络错误");
				flag = true;
			}
		);
	}

	/// <summary>
	/// 解析游戏内容
	/// </summary>
	/// <param name="item"></param>
	public async void FuncContentItem(Get_Game_Content_Item item)
	{
		if (item == null)
		{
			return;
		}
		//Debug.LogError(item.ToString());
		if (item.contenttype == "head")
		{
			MainHeadItem mainHeadItem = UISystem.Instance.OpenUIItem(Data_UIItemID.key_MainHeadItem, this) as MainHeadItem;
			mainHeadItems.Add(mainHeadItem);
			mainHeadItem.transform.SetParent(m_rectLayoutMainHead.transform);
			mainHeadItem.SetData(item.contentdes, mainHeadItems.Count);
		}
		if (item.contenttype == "slideshow")
		{
			SlideShowItem slideShowItem = UISystem.Instance.OpenUIItem(Data_UIItemID.key_SlideShowItem, this) as SlideShowItem;
			slideShowItems.Add(slideShowItem);
			slideShowItem.transform.SetParent(m_rectSlideShow);
			slideShowItem.transform.localPosition = Vector3.zero;
			await NetSystem.Instance.LoadImg(item.contentimgpath, (res) =>
			{
				slideShowItem.SetData(res as Texture, item.contentpath, slide_shs_time);
			});
		}
	}
}
