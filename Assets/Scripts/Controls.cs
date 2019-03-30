using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    public float force = 1;
    public float jumpForce = 10;
    private Vector2 input;
    private bool jump;

    private Vector2 buttonInput;

    public InputButton leftButton;
    public InputButton rightButton;
    public InputButton jumpButton;

    private void OnEnable()
    {
        leftButton.onPointerDown.AddListener(OnLeftDown);
        leftButton.onPointerUp.AddListener(OnLeftUp);
        rightButton.onPointerDown.AddListener(OnRightDown);
        rightButton.onPointerUp.AddListener(OnRightUp);
        jumpButton.onPointerDown.AddListener(OnJumpDown);
    }

    private void OnDisable()
    {
        leftButton.onPointerDown.RemoveListener(OnLeftDown);
        leftButton.onPointerUp.RemoveListener(OnLeftUp);
        rightButton.onPointerDown.RemoveListener(OnRightDown);
        rightButton.onPointerUp.RemoveListener(OnRightUp);
        jumpButton.onPointerDown.RemoveListener(OnJumpDown);
    }

    private void OnLeftDown() => buttonInput.x = -1;
    private void OnLeftUp() => buttonInput.x = 0;
    private void OnRightDown() => buttonInput.x = 1;
    private void OnRightUp() => buttonInput.x = 0;
    private void OnJumpDown() => jump = true;

    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (input.x == 0) input.x = buttonInput.x;
        jump = Input.GetButtonDown("Jump") ? true : jump;

        if (input.x != 0)
            GetComponent<RigidBodyModifiers>().enableXDrag = false;
        else
            GetComponent<RigidBodyModifiers>().enableXDrag = true;
    }

    private void FixedUpdate()
    {
        input.y = 0;
        GetComponent<Rigidbody2D>().AddForce(input * force);

        if (jump)
        {
            jump = false;
            GetComponent<Rigidbody2D>().velocity += Vector2.up * (jumpForce - GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}
