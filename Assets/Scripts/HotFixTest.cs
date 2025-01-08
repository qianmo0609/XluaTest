using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using XLua;

public class HotFixTest : MonoBehaviour
{
    LuaEnv luaenv = null;

    Action onDestroy = null;

    [CSharpCallLua]
    public delegate Action testAction(TestGCOptimizeValue x);

    testAction ta;

    [CSharpCallLua]
    Action<LuaTable> onTest = null;

    TestGCOptimizeValue ts;

    void Start()
    {
        TestHotFix testHotFix = new TestHotFix();
        luaenv = new LuaEnv();
        luaenv.AddLoader(customLoader);
        testHotFix.TestPrint();
        luaenv.DoString("require 'main'");
        onDestroy = luaenv.Global.Get<Action>("OnDestroy");
        ta = luaenv.Global.Get<testAction>("testAction");
        onTest = luaenv.Global.Get<Action<LuaTable>>("testAction");
        testHotFix.TestPrint();
        onDestroy.Invoke();
        onDestroy = null;
        ts = new TestGCOptimizeValue();
        ts.a = 1;
        ts.b = 2;
    }

    private void Update()
    {
        if (Application.isPlaying)
        {
            ta?.Invoke(ts);
        }
    }

    public byte[] customLoader(ref string filepath)
    {
        /*¼ÓÔØLua´úÂë*/
#if UNITY_EDITOR
        return AssetDatabase.LoadAssetAtPath<TextAsset>($"Assets/Lua/{filepath}.lua.txt").bytes;
#endif
        return null;
    }

    private void OnDestroy()
    {
        onDestroy = null;
        ta = null;
        onTest = null;
        luaenv.Dispose();
    }

}

[Hotfix]
public class TestHotFix
{
    public void TestPrint()
    {
        Debug.Log("Before Hotfix");
    }
}

[GCOptimize]
public struct TestGCOptimizeValue
{
    public int a;
    public int b;
    private float f;
    //[AdditionalProperties]
    public float F { get => f; set => f = value; }
}
