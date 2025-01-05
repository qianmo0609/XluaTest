using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using XLua;

public class Test : MonoBehaviour
{
    LuaEnv luaenv = null;

    void Start()
    {
        luaenv = new LuaEnv();
        luaenv.AddLoader(customLoader);
        luaenv.DoString("require 'main'");
        //this.GetGlobal();
        //this.GetClassOrStruct();
        //this.GetInterface();
        //this.GetCollections();
        //this.GetLuaTable();
        this.GetLuaFuncDelegate();
        luaenv.Dispose();
    }

    public byte[] customLoader(ref string filepath)
    {
        /*加载Lua代码*/
#if UNITY_EDITOR
        return AssetDatabase.LoadAssetAtPath<TextAsset>($"Assets/Lua/{filepath}.lua.txt").bytes;
#endif
        return null;
    }

    #region C#callLua

    public void GetGlobal()
    {
        int hp = luaenv.Global.Get<int>("hp");
        bool isPlay = luaenv.Global.Get<bool>("isPlay");
        string heroName = luaenv.Global.Get<string>("heroName");
        Debug.Log($"HP:{hp},isPlay:{isPlay},heroName:{heroName}");
    }

    public class PlayerInfo
    {
        public int id;
        public string name;
        public int level;
    }

    public struct EventMsg
    {
        public int eventId;
        public string param;
    }

    public void GetClassOrStruct()
    {
        //映射到有对应字段的class，by value
        PlayerInfo info = luaenv.Global.Get<PlayerInfo>("playerInfo");
        EventMsg msg = luaenv.Global.Get<EventMsg>("eventMsg");
        Debug.Log($"PlayerInfo:{info.id},{info.name},{info.level}");
        Debug.Log($"EventMsg:{msg.eventId},{msg.param}");
    }

    [CSharpCallLua]
    public interface IPlayerPosition
    {
        int x { get; set; }
        int y { get; set; }
        int z { get; set; }

        void add(int x, int y, int z);
        void sub(int x,int y ,int z);
    }

    public void GetInterface()
    {
        //映射到interface实例，by ref，这个要求interface加到生成列表，否则会返回null，建议用法
        IPlayerPosition pPos = luaenv.Global.Get<IPlayerPosition>("playerPosition");
        Debug.Log($"{pPos.x}，{pPos.y}，{pPos.z}");
        pPos.add(10,1,23);
        Debug.Log($"{pPos.x}，{pPos.y}，{pPos.z}");
        pPos.sub(1,-1,11);
        Debug.Log($"{pPos.x}，{pPos.y}，{pPos.z}");
    }

    public void GetCollections()
    {
        //映射到Dictionary<string, double>，by value
        Dictionary<string, double> d = luaenv.Global.Get<Dictionary<string, double>>("Item");
        Debug.Log(d.Count);

        //映射到List<double>，by value
        List<double> l = luaenv.Global.Get<List<double>>("Item"); 
        Debug.Log(l.Count);
    }

    [CSharpCallLua]
    public delegate void AddMethod(LuaTable self,int x,int y, int z);

    [CSharpCallLua]
    public delegate Action addAc(LuaTable t, int x, int y, int z);


    public void GetLuaTable()
    {
        //映射到LuaTable，by ref
        LuaTable info= luaenv.Global.Get<LuaTable>("playerPosition");
        /*var LF = info.Get<LuaFunction>("add");
        LF.Call(info,1,2,3);
        Debug.Log($"playerPosition ：{info.Get<int>("x")}，{info.Get<int>("y")}，{info.Get<int>("z")}");*/

        AddMethod LD = info.Get<AddMethod>("add");
        LD(info,2, 3, 4);
        Debug.Log($"playerPosition ：{info.Get<int>("x")}，{info.Get<int>("y")}，{info.Get<int>("z")}");

        var ac = info.Get<Action<LuaTable,int,int,int>>("add");
        ac(info, 2, 3, 4);
        Debug.Log($"playerPosition ：{info.Get<int>("x")}，{info.Get<int>("y")}，{info.Get<int>("z")}");

        var aac = info.Get<addAc>("add");
        aac(info, 2, 3, 4);
        Debug.Log($"playerPosition ：{info.Get<int>("x")}，{info.Get<int>("y")}，{info.Get<int>("z")}");
    }


    [CSharpCallLua]
    public delegate void test1(int x);

    [CSharpCallLua]
    public delegate Action test2(int x);

    public void GetLuaFuncDelegate()
    {
        var lf = luaenv.Global.Get<LuaFunction>("test");
        lf.Call(10);

        /*test1 LD = luaenv.Global.Get<test1>("test");
        LD(100);

        var ac = luaenv.Global.Get<Action<int>>("test");
        ac(0);

        var aac = luaenv.Global.Get<test2>("test");
        aac(19);*/
    }

    #endregion
}
