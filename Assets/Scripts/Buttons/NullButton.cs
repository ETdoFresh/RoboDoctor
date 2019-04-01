using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class NullButton : MonoBehaviour
{
    private void Update()
    {
        foreach (var control in FindObjectsOfType<Controls>())
            if (control.input.x == 0
                && !Input.GetButtonDown("Jump")
                && !Input.GetButtonDown("Fire2"))
                GetComponent<Button>().Select();
    }
}