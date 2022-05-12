using System.Collections;
using System.Collections.Generic;

//CreateTime：2022/5/12 14:48:41
namespace DataCs
{
	public struct Data_UIItemID_Struct
	{
		public string key;
		public int ID;
		public string path;

		public Data_UIItemID_Struct(string _key, int _ID, string _path)
		{
			key = _key;
			ID = _ID;
			path = _path;
		}
	}

	public static class Data_UIItemID
	{
		public static Dictionary<string, Data_UIItemID_Struct> Dic = new Dictionary<string, Data_UIItemID_Struct>()
		{
			{"LeftGameItem",new Data_UIItemID_Struct("LeftGameItem",2000,"UI/UIItem/LeftGameItem")},
		};
		public static string key_LeftGameItem = "LeftGameItem";
	}
}

