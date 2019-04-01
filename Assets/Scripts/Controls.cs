using UnityEngine;

public class Controls : MonoBehaviour
{
    public Vector2 buttonInput = Vector2.zero;
    public Vector2 input = Vector2.zero;
    public bool jump = false;
    public bool interact = false;

    public void OnLeftDown() => buttonInput.x = -1;
    public void OnLeftUp() => buttonInput.x = 0;
    public void OnRightDown() => buttonInput.x = 1;
    public void OnRightUp() => buttonInput.x = 0;
    public void OnJumpDown() => jump = true;
    public void OnInteractDown() => interact = true;

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        if (input.x == 0) input.x = buttonInput.x;
        jump = Input.GetButtonDown("Jump") ? true : jump;
        interact = Input.GetButtonDown("Fire2") ? true : interact;

        if (interact)
        {
            foreach (var controlled in FindObjectsOfType<Controlled>())
                controlled.Interact();
            interact = false;
        }
    }

    private void FixedUpdate()
    {
        foreach (var controlled in FindObjectsOfType<Controlled>())
            controlled.Control(input, ref jump);

        if (jump)
            jump = false;
    }
}