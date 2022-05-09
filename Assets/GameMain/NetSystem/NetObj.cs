using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface NetObj 
{

}

public class TestObj : NetObj
{
    public int id;
    public string name;

    public override string ToString()
    {
        return id.ToString() + " " + name;
    }
}

public class TestObj2 : NetObj
{
    public string username;
    public string password;

    public override string ToString()
    {
        return string.Format("username:{0},password{1}",username,password);
    }
}

public class Login_Scuec:NetObj
{
    public int login;//0表示登录未通过,1表示登录通过

    public override string ToString()
    {
        return string.Format("login:{0}", login);
    }
}
