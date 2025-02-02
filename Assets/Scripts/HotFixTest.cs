using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using XLua;

public class HotFixTest : MonoBehaviour
{
    LuaEnv luaenv = null;

    Action onDestroy = null;

    [CSharpCallLua]
    [Hotfix]
    public delegate Action testAction(TestGCOptimizeValue[] x,string aaa,bool b,int d);

    [GCOptimize]
    TestGCOptimizeValue[,] a = new TestGCOptimizeValue[3, 4];
    [GCOptimize]
    TestGCOptimizeValue[] c = new TestGCOptimizeValue[4];

    testAction ta;

    [CSharpCallLua]
    Action<LuaTable> onTest = null;

    TestGCOptimizeValue ts;

    void Start()
    {
        TestHotFix testHotFix = new TestHotFix();
        //TestHotFixClass testHotFixClass = new TestHotFixClass();
        luaenv = new LuaEnv();
        luaenv.AddLoader(customLoader);
        //testHotFix.TestPrint();
        //testHotFixClass.TestProperty = 10;
        //Debug.Log($"before get {testHotFixClass.TestProperty}");
        //Debug.Log(testHotFixClass[1]);
        //Debug.Log(testHotFixClass["cc"]);
        //System.GC.Collect();
        //System.GC.WaitForPendingFinalizers();
        //TestGeneric<int> testGeneric = new TestGeneric<int>();
        //TestGeneric<float> testGeneric1 = new TestGeneric<float>();
        //new GameObject().AddComponent<HotFixCoroutine>();
        //HotFixOtherOperator ho1 = new HotFixOtherOperator();
        //HotFixOtherOperator ho2 = new HotFixOtherOperator();
        //int a = ho1 + ho2;
        luaenv.DoString("require 'main'");
        //new GameObject().AddComponent<HotFixCoroutine>();
        //TestGeneric<float> testGeneric3 = new TestGeneric<float>();
        //TestGeneric<double> testGeneric2 = new TestGeneric<double>();
        //TestHotFixClass testHotFixClass1 = new TestHotFixClass();
        //luaenv.FullGc();
        //System.GC.Collect();
        //System.GC.WaitForPendingFinalizers();
        //TestHotFixClass testHotFixClass = new TestHotFixClass();
        //testHotFixClass.myEvent += TestHotfixEvent;
        //testHotFixClass.myEvent -= TestHotfixEvent;

        //Debug.Log(testHotFixClass[1]);
        //Debug.Log(testHotFixClass["cc"]);
        //Debug.Log($"after get {testHotFixClass.TestProperty}");
        //testHotFixClass.TestProperty = 100;
        //Debug.Log($"set after get {testHotFixClass.TestProperty}");
        //TestHotFixClass testHotFixClass = new TestHotFixClass();
        //TestHotFixClass testHotFixClass1 = new TestHotFixClass(10, 20);
        onDestroy = luaenv.Global.Get<Action>("OnDestroy");
        ta = luaenv.Global.Get<testAction>("testAction");
        onTest = luaenv.Global.Get<Action<LuaTable>>("testAction");
        //testHotFix.TestPrint();
        onDestroy.Invoke();
        onDestroy = null;
        ts = new TestGCOptimizeValue();
        ts.a = 1;
        ts.b = 2;
        
    }

    void TestHotfixEvent()
    {
        Debug.Log("aaaaaaa");
    }

    private void Update()
    {
        if (Application.isPlaying)
        {
            //ta?.Invoke(ts);
        }
    }

    public byte[] customLoader(ref string filepath)
    {
        /*加载Lua代码*/
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

[Hotfix]
[LuaCallCSharp]
public class TestHotFixClass
{
    public TestHotFixClass()
    {
        //Debug.Log("c# .ctor");
    }

    public TestHotFixClass(int p, int c)
    {
        //Debug.Log($"C# .ctor {p} , {c}");
    }

    private int testProperty;

    public int TestProperty
    {
        get
        {
            return testProperty;
        }
        set
        {
            testProperty = value;
            Debug.Log($"c# set {testProperty}");
        }
    }

    public int this[string field]
    {
        get { return 1; }
        set { }
    }

    public string this[int index]
    {
        get { return "aaabbbb"; }
        set { }
    }

    public void EventCall()
    {
        Debug.Log("EventCall");
    }

    public void EventCall(int a)
    {
        Debug.Log("EventCall a");
    }

    public event Action myEvent;

    ~TestHotFixClass()
    {
        Debug.Log("执行析构函数");
    }
}

public class TestGeneric<T>
{
    public TestGeneric()
    {
        Debug.Log($"c#,{typeof(T)}");
    }

    public int testProperty {  get; set; }
}
[Hotfix]
public class HotFixSubClass : MonoBehaviour
{
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            Debug.Log("Wait for 3 seconds");
        }
    }
}

[Hotfix]
[LuaCallCSharp]
public class HotFixOtherOperator
{
    public static int operator +(HotFixOtherOperator a, HotFixOtherOperator b)
    {
        Debug.Log("C# op_add");
        return 0;
    }
}


[Hotfix(HotfixFlag.IntKey)]
public class TestHotFixInkey
{
    public int A;
    public bool B; 
    public string C;

    public int this[string field]
    {
        get { return 1; }
        set { }
    }

    public void EventCall()
    {
        Debug.Log("EventCall");
    }

    public void EventCall(int a)
    {
        Debug.Log("EventCall a");
    }

    public void test()
    {
        Debug.Log("cccccccccc");
    }
}