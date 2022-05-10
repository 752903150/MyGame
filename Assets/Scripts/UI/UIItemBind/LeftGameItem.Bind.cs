using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//CreateTime：2022/5/10 15:10:26
public partial class LeftGameItem
{
	private AutoBind autoBind;
	private Button m_btnMyGame;
	private RawImage m_rawimgHead;
	private Text m_txtGame;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_btnMyGame = autoBind.itemList[0].obj.GetComponent<Button>();
		m_rawimgHead = autoBind.itemList[1].obj.GetComponent<RawImage>();
		m_txtGame = autoBind.itemList[2].obj.GetComponent<Text>();
	}
}

