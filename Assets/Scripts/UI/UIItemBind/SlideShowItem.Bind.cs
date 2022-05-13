using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//CreateTime：2022/5/13 14:10:27
public partial class SlideShowItem
{
	private AutoBind autoBind;
	private RawImage m_rawimgSlideShow;
	private Button m_btnSlideShow;

	private void InitComponent()
	{
		autoBind = GetComponent<AutoBind>();
		m_rawimgSlideShow = autoBind.itemList[0].obj.GetComponent<RawImage>();
		m_btnSlideShow = autoBind.itemList[1].obj.GetComponent<Button>();
	}
}

