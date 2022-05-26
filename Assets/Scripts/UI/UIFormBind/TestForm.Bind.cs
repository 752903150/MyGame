using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameFrameWork;
using UnityEngine.UI;

//CreateTime：2022/5/26 15:55:01
public partial class TestForm
{
	private AutoBind autoBind;
	private Button m_btnTest1;
	private Text m_txtTest1;
	private Button m_btnTest2;
	private Text m_txtTest2;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_btnTest1 = autoBind.itemList[0].obj.GetComponent<Button>();
		m_txtTest1 = autoBind.itemList[1].obj.GetComponent<Text>();
		m_btnTest2 = autoBind.itemList[2].obj.GetComponent<Button>();
		m_txtTest2 = autoBind.itemList[3].obj.GetComponent<Text>();
	}
	private void AddLua()
	{
		scriptEnv.Set("m_btnTest1", m_btnTest1); 
		scriptEnv.Set("m_txtTest1", m_txtTest1); 
		scriptEnv.Set("m_btnTest2", m_btnTest2); 
		scriptEnv.Set("m_txtTest2", m_txtTest2); 
	}
}

