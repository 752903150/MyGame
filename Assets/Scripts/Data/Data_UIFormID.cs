using System.Collections;
using System.Collections.Generic;

//CreateTime：2022/5/9 16:26:57
namespace DataCs
{
	public struct Data_UIFormID_Struct
	{
		public string key;
		public int ID;
		public string path;
		public int root;

		public Data_UIFormID_Struct(string _key, int _ID, string _path, int _root)
		{
			key = _key;
			ID = _ID;
			path = _path;
			root = _root;
		}
	}

	public static class Data_UIFormID
	{
		public static Dictionary<string, Data_UIFormID_Struct> Dic = new Dictionary<string, Data_UIFormID_Struct>()
		{
			{"LoginForm",new Data_UIFormID_Struct("LoginForm",1000,"UI/UIForm/LoginForm",1)},
		};
		public static string key_LoginForm = "LoginForm";
	}
}

