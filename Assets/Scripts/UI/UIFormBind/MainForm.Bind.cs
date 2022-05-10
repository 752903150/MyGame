using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//CreateTime：2022/5/10 15:41:04
public partial class MainForm
{
	private AutoBind autoBind;
	private Button m_btnSetting;
	private Button m_btnMin;
	private Button m_btnClose;
	private Button m_btnMainPanel;
	private Image m_imgMainPanel_on;
	private Image m_imgMainPanel_off;
	private Button m_btnTestPanel;
	private Image m_imgTestPanel_on;
	private Image m_imgTestPanel_off;
	private RectTransform m_rectMainPanel;
	private Image m_imgLeftChooseList;
	private Button m_btnLeftMin;
	private RectTransform m_rectContent;
	private Button m_btnLeftListMax;
	private RectTransform m_rectmaxposition;
	private RectTransform m_rectminposition;
	private RectTransform m_rectTestPanel;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_btnSetting = autoBind.itemList[0].obj.GetComponent<Button>();
		m_btnMin = autoBind.itemList[1].obj.GetComponent<Button>();
		m_btnClose = autoBind.itemList[2].obj.GetComponent<Button>();
		m_btnMainPanel = autoBind.itemList[3].obj.GetComponent<Button>();
		m_imgMainPanel_on = autoBind.itemList[4].obj.GetComponent<Image>();
		m_imgMainPanel_off = autoBind.itemList[5].obj.GetComponent<Image>();
		m_btnTestPanel = autoBind.itemList[6].obj.GetComponent<Button>();
		m_imgTestPanel_on = autoBind.itemList[7].obj.GetComponent<Image>();
		m_imgTestPanel_off = autoBind.itemList[8].obj.GetComponent<Image>();
		m_rectMainPanel = autoBind.itemList[9].obj.GetComponent<RectTransform>();
		m_imgLeftChooseList = autoBind.itemList[10].obj.GetComponent<Image>();
		m_btnLeftMin = autoBind.itemList[11].obj.GetComponent<Button>();
		m_rectContent = autoBind.itemList[12].obj.GetComponent<RectTransform>();
		m_btnLeftListMax = autoBind.itemList[13].obj.GetComponent<Button>();
		m_rectmaxposition = autoBind.itemList[14].obj.GetComponent<RectTransform>();
		m_rectminposition = autoBind.itemList[15].obj.GetComponent<RectTransform>();
		m_rectTestPanel = autoBind.itemList[16].obj.GetComponent<RectTransform>();
	}
}

