using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCs;

public partial class LoginFom
{
	private async void Login()
	{
		WWWForm www = new WWWForm();
		www.AddField(Data_WebRequest.Login_Scuec_Param1_name, m_inputUsername.text);
		www.AddField(Data_WebRequest.Login_Scuec_Param2_name, m_inputPassword.text);
		bool isflag = false;
		Login_Scuec t = await NetSystem.Instance.LoadData<Login_Scuec>(
			Data_WebRequest.Login_Scuec_Url_name,
			www,
			null,
			() =>
			{
				LoginFail();
				isflag = true;
				Debug.LogError("ÍøÂç´íÎó");
			}
		) as Login_Scuec;

		if (isflag)
		{

			return;
		}

		if (t == null || t.login == 0)
		{
			Debug.LogError("µÇÂ¼´íÎó");
			if (t != null)
			{
				Debug.LogError(t.ToString());
			}
			LoginFail();
			return;
		}

		LoginSucceed();//µÇÂ¼³É¹¦
	}
}
