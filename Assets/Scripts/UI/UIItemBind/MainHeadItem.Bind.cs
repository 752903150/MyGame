using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//CreateTime：2022/5/13 13:18:11
public partial class MainHeadItem
{
	private AutoBind autoBind;
	private Button m_btnMainHead;
	private Text m_txtMainHead;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_btnMainHead = autoBind.itemList[0].obj.GetComponent<Button>();
		m_txtMainHead = autoBind.itemList[1].obj.GetComponent<Text>();
	}
}

