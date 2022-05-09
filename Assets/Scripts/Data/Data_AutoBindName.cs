using System.Collections;
using System.Collections.Generic;

//CreateTime：2022/5/6 14:05:28
namespace DataCs
{
	public struct Data_AutoBindName_Struct
	{
		public string key;
		public int ID;
		public int user;
		public string password;

		public Data_AutoBindName_Struct(string _key, int _ID, int _user, string _password)
		{
			key = _key;
			ID = _ID;
			user = _user;
			password = _password;
		}
	}

	public static class Data_AutoBindName
	{
		public static Dictionary<string, Data_AutoBindName_Struct> Dic = new Dictionary<string, Data_AutoBindName_Struct>()
		{
			{"zkw",new Data_AutoBindName_Struct("zkw",1,2,"3")},
			{"whr",new Data_AutoBindName_Struct("whr",2,3,"5")},
		};
		public static string key_zkw = "zkw";
		public static string key_whr = "whr";
	}
}

