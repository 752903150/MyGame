using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//CreateTime：2022/5/9 13:13:51
public partial class LoginFom
{
	private AutoBind autoBind;
	private Button m_btnMin;
	private Button m_btnClose;
	private RectTransform m_rectLogin;
	private Button m_btnLogin;
	private InputField m_inputUsername;
	private InputField m_inputPassword;
	private Toggle m_toggleRemeber;
	private Toggle m_toggleAutoLogin;
	private RectTransform m_rectFail;
	private Button m_btnReLogin;
	private Button m_btnExit;
	private RectTransform m_rectLogining;
	private Text m_txtLoginAnimation;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_btnMin = autoBind.itemList[0].obj.GetComponent<Button>();
		m_btnClose = autoBind.itemList[1].obj.GetComponent<Button>();
		m_rectLogin = autoBind.itemList[2].obj.GetComponent<RectTransform>();
		m_btnLogin = autoBind.itemList[3].obj.GetComponent<Button>();
		m_inputUsername = autoBind.itemList[4].obj.GetComponent<InputField>();
		m_inputPassword = autoBind.itemList[5].obj.GetComponent<InputField>();
		m_toggleRemeber = autoBind.itemList[6].obj.GetComponent<Toggle>();
		m_toggleAutoLogin = autoBind.itemList[7].obj.GetComponent<Toggle>();
		m_rectFail = autoBind.itemList[8].obj.GetComponent<RectTransform>();
		m_btnReLogin = autoBind.itemList[9].obj.GetComponent<Button>();
		m_btnExit = autoBind.itemList[10].obj.GetComponent<Button>();
		m_rectLogining = autoBind.itemList[11].obj.GetComponent<RectTransform>();
		m_txtLoginAnimation = autoBind.itemList[12].obj.GetComponent<Text>();
	}
}

