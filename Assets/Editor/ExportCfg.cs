using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using static Test;

public static class ExportCfg
{
    [DoNotGen]
    public static Dictionary<Type, List<string>> dontGenDic = new Dictionary<Type, List<string>>
    {
        [typeof(TestDontGen)] = new List<string> { "a2" },
    };

    [BlackList]
    public static List<List<string>> BlackList = new List<List<string>>()
    {
        new List<string>(){ "TestBlackList", "a2"},
        new List<string>(){ "TestBlackList", "Test"}
    };

    [AdditionalProperties]
    public static Dictionary<Type, List<string>> AdditionalProperties = new Dictionary<Type, List<string>>
    {
        //[typeof(TestGCOptimizeValue)] = new List<string> { "F" },
        
    };

    [LuaCallCSharp]
    public static List<Type> luaCallCsharp = new List<Type>
    {
        typeof(TestObj),
        typeof(WaitForSeconds),
    };

    [CSharpCallLua]
    public static List<Type> CsharpCallLua = new List<Type> { 
       typeof(IPlayerPosition),
       typeof(AddMethod),
       typeof(addAc),
       typeof(test1),
       typeof(test2),
    };
   
}
