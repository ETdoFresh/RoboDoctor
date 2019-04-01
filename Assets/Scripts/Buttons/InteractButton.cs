using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class InteractButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private void Update()
    {
        foreach (var control in FindObjectsOfType<Controls>())
            if (Input.GetButtonDown("Fire2"))
                GetComponent<Button>().Select();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        foreach (var control in FindObjectsOfType<Controls>())
            control.OnInteractDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }
}