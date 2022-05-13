using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//CreateTime：2022/5/13 14:10:27
public partial class SlideShowItem : UIItem
{
	private float slide_shs_time;

	private string httpurl;

	//private Sequence sequence;

	private Color HideColor;
	private Color ShowColor;
	public override void Awake()
	{
		base.Awake();
		InitComponent(); 
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		RegisterEvent();

		HideColor = new Color(1f, 1f, 1f, 0f);
		ShowColor = new Color(1f, 1f, 1f, 1f);
	}

	public override void OnClose()
	{
		base.OnClose();
		ReleaseEvent(); 
	}

	private void RegisterEvent()
	{
		m_btnSlideShow.onClick.AddListener(OnBtnSlideShow);
	}

	private void ReleaseEvent()
	{
		m_btnSlideShow.onClick.RemoveListener(OnBtnSlideShow);
	}

	private void OnBtnSlideShow()
	{
		if(httpurl!=null)
		Application.OpenURL(httpurl);
	}

	public void SetData(Texture texture,string _httpurl,float _slide_shs_time)
    {
		if(texture!=null)
        {
			m_rawimgSlideShow.texture = texture;
			//m_rawimgSlideShow.color = HideColor;
		}
		else
        {
			Debug.LogError("无图片！");
        }
		httpurl = _httpurl;
		slide_shs_time= _slide_shs_time;
	}

	public void HideByAnimation()
    {
		m_btnSlideShow.gameObject.SetActive(false);
		m_rawimgSlideShow.DOColor(HideColor, slide_shs_time);
    }

	public void ShowByAnimation()
    {
		m_btnSlideShow.gameObject.SetActive(true);
		m_rawimgSlideShow.DOColor(ShowColor, slide_shs_time);
	}

	public void Hide()
	{
		m_btnSlideShow.gameObject.SetActive(false);
		m_rawimgSlideShow.color = HideColor;
	}

	public void Show()
	{
		m_btnSlideShow.gameObject.SetActive(true);
		m_rawimgSlideShow.color = ShowColor;
	}

}

