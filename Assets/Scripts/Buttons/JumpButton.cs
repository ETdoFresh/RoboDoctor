using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private void Update()
    {
        foreach (var control in FindObjectsOfType<Controls>())
            if (Input.GetButtonDown("Jump"))
                GetComponent<Button>().Select();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        foreach (var control in FindObjectsOfType<Controls>())
            control.OnJumpDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }
}