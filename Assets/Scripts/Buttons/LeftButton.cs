﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LeftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private void Update()
    {
        foreach (var control in FindObjectsOfType<Controls>())
            if (control.input.x < 0)
                GetComponent<Button>().Select();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        foreach (var control in FindObjectsOfType<Controls>())
            control.OnLeftDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        foreach (var control in FindObjectsOfType<Controls>())
            control.OnLeftUp();
    }
}