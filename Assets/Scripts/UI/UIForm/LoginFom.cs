using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataCs;
using DG.Tweening;
using LitJson;


//CreateTime：2022/5/9 13:13:51
public partial class LoginFom : UIForm
{
	private Sequence sequence;
	private LoginUserInfo loginUserInfo;//用户登录信息
	public override void Awake()
	{
		base.Awake();
		InitComponent();
		InitSetData();
	}

	public override void OnOpen(System.Object obj)
	{
		base.OnOpen(obj);
		RegisterEvent();
		ReSetData();
	}

	public override void OnClose()
	{
		base.OnClose();
		ReleaseEvent(); 
	}

	private void ReSetData()
    {
		m_inputPassword.contentType = InputField.ContentType.Password;
		m_rectLogin.gameObject.SetActive(true);
		m_rectLogining.gameObject.SetActive(false);
		m_rectFail.gameObject.SetActive(false);
	}

	private void InitSetData()
    {
		ReadUserInfo();
	}

	private void RegisterEvent()
	{
		m_btnMin.onClick.AddListener(OnBtnMin);
		m_btnClose.onClick.AddListener(OnBtnClose);
		m_btnLogin.onClick.AddListener(OnBtnLogin);
		m_btnReLogin.onClick.AddListener(OnBtnReLogin);
		m_btnExit.onClick.AddListener(OnBtnExit);
	}

	private void ReleaseEvent()
	{
		m_btnMin.onClick.RemoveListener(OnBtnMin);
		m_btnClose.onClick.RemoveListener(OnBtnClose);
		m_btnLogin.onClick.RemoveListener(OnBtnLogin);
		m_btnReLogin.onClick.RemoveListener(OnBtnReLogin);
		m_btnExit.onClick.RemoveListener(OnBtnExit);
	}

	private void OnBtnMin()
	{
		WindowMaxAndMin.OnClickMinimize();
	}
	private void OnBtnClose()
	{
		ExitGame();
	}
	private void OnBtnLogin()
	{
		Logining();
	}
	private void OnBtnReLogin()
	{
		ReLogin();
	}
	private void OnBtnExit()
	{
		ExitGame();
	}

	//读入用户登录信息
	private void ReadUserInfo()
    {
		loginUserInfo = LocalFileSystem.Instance.GetLocalFileFormPath<LoginUserInfo>(Data_LocalFile.key_LoginUserInfo) as LoginUserInfo;
		if(loginUserInfo == null)//第一次登录，或者未保存密码
        {
			m_inputUsername.text = "";
			m_inputPassword.text = "";
			m_toggleRemeber.isOn = false;
			m_toggleAutoLogin.isOn = false;
        }
		else
        {
			if(loginUserInfo.Remeber == 1)//记住账号密码
			{
				m_inputUsername.text = loginUserInfo.Username;
				m_inputPassword.text = loginUserInfo.Password;
			}
			else//未记住账号密码
			{
				m_inputUsername.text = "";
				m_inputPassword.text = "";
			}

			if(loginUserInfo.AutoLogin == 1)//一秒之后自动登录
            {
				sequence = DOTween.Sequence();
				sequence.AppendInterval(1f);
				sequence.AppendCallback(() =>
				{
					Logining();
				});
			}

			
			m_toggleRemeber.isOn = loginUserInfo.Remeber==1?true:false;
			m_toggleAutoLogin.isOn = loginUserInfo.AutoLogin == 1 ? true : false;
		}
    }

	

	private void Logining()//登录中
    {
		m_rectLogining.gameObject.SetActive(true);
		m_rectLogin.gameObject.SetActive(false);
		sequence = DOTween.Sequence();
		sequence.AppendInterval(1f);
		sequence.AppendCallback(() =>
		{
			m_txtLoginAnimation.text = "。";
		});
		sequence = DOTween.Sequence();
		sequence.AppendInterval(2f);
		sequence.AppendCallback(() =>
		{
			m_txtLoginAnimation.text = "。。";
		});
		sequence = DOTween.Sequence();
		sequence.AppendInterval(3f);
		sequence.AppendCallback(() =>
		{
			m_txtLoginAnimation.text = "。。。";
		});
		Login();
	}

	private void LoginFail()//登录失败
    {
		m_inputPassword.text = "";
		m_rectLogining.gameObject.SetActive(false);
		m_rectLogin.gameObject.SetActive(false);
		m_rectFail.gameObject.SetActive(true);

		if(loginUserInfo != null && loginUserInfo.AutoLogin ==1)//如果自动登录失败，则改写自动登录和记住密码的标志
        {
			loginUserInfo.Remeber = 0;
			loginUserInfo.AutoLogin = 0;
			SaveFile();
		}
	}

	private void ReLogin()//重新登录
    {
		m_rectLogining.gameObject.SetActive(false);
		m_rectLogin.gameObject.SetActive(true);
		m_rectFail.gameObject.SetActive(false);
	}

	private void LoginSucceed()//登录成功
    {
		SaveFile();
		Debug.LogError("登录成功");
		EventManagerSystem.Instance.Invoke2(
			Data_EventName.OnLoginSucceed_str, 
			new LoginSucceedEventArgs(m_inputUsername.text, m_inputPassword.text)
			);
		UISystem.Instance.CloseUIForm(Data_UIFormID.key_LoginForm,this);
	}

	private void SaveFile()
	{
		if(loginUserInfo==null)
        {
			loginUserInfo = new LoginUserInfo();
			
		}

		loginUserInfo.Username = m_inputUsername.text;
		loginUserInfo.Password = m_inputPassword.text;
		loginUserInfo.Remeber = m_toggleRemeber.isOn ? 1 : 0;
		loginUserInfo.AutoLogin = m_toggleAutoLogin.isOn ? 1 : 0;

		CodeCreate.CreateORwriteConfigFile(Application.persistentDataPath, Data_LocalFile.key_LoginUserInfo + ".json", JsonMapper.ToJson(loginUserInfo), 0);
	}

	private void ExitGame()
    {
		#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
		#else
				Application.Quit();
		#endif
	}
}

