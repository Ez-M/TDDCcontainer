using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MouseInputHandler : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        GameObject clickedObject = pointerEventData.pointerPress;
        Debug.Log(name + "Game Object Clicked!");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse entered UI element!");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exited UI element!");
    }
}