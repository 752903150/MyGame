using System.Collections;
using System.Collections.Generic;
//自动生成时间：123
namespace DataCs
{
    public struct Data_Test_Struct
    {
        public string key;
        public int ID;
        public int user;
        public string password;

        public Data_Test_Struct(string _key, int _ID,int _user,string _password)
        {
            key = _key;
            ID = _ID;
            user = _user;
            password = _password;
        }
    }

    public static class Data_Test
    {
        public static Dictionary<string, Data_Test_Struct> Dic = new Dictionary<string, Data_Test_Struct>()
        {
            {"zkw",new Data_Test_Struct("zkw",1,2,"3")},
            {"whr",new Data_Test_Struct("whr",2,3,"5")},
        };

        public static string key_zkw = "zkw";
        public static string key_whr = "whr";
    }
}

