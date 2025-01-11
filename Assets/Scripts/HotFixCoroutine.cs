using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[Hotfix]
public class HotFixCoroutine: MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(CoroutineStart());
    }

    IEnumerator CoroutineStart()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("c# Wait for 3 seconds");
        }
    }
}
