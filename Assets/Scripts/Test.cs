using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using XLua;

public class Test : MonoBehaviour
{
    void Start()
    {
        LuaEnv luaenv = new LuaEnv();
        luaenv.DoString("CS.UnityEngine.Debug.Log('hello world')");
        luaenv.Dispose();
    }

    private void Update()
    {
        /*if (Input.GetButtonDown("Submit"))
        {
            Debug.Log("AAAAAAAAAA");
        }*/
    }
}
