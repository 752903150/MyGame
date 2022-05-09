using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//CreateTime：2022/5/9 16:02:26
public class LoginSucceedEventArgs : IEventArgs
{
	public string username;
	public string password;
	public LoginSucceedEventArgs(string _username, string _password)
	{
		username = _username;
		password = _password;
	}

	public static LoginSucceedEventArgs Create(string username, string password)
	{
		return new LoginSucceedEventArgs(username, password);
	}
}

