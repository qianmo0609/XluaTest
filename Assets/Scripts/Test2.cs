using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test2 :MonoBehaviour, IPointerClickHandler,IPointerDownHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("dddddddddd");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("aaaaaaaaaaa");
    }

    public void OnTest2Btn()
    {
        Debug.Log("CCCCCCCCCCCCCC");
    }
}
