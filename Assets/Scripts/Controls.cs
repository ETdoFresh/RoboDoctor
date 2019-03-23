using UnityEngine;

public class Controls : MonoBehaviour
{
    public float force = 1;
    public float jumpForce = 10;
    private Vector2 input;
    private bool jump;

    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        jump = Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0) ? true : jump;

        if (input.x != 0)
            GetComponent<RigidBodyModifiers>().enableXDrag = false;
        else
            GetComponent<RigidBodyModifiers>().enableXDrag = true;
    }

    private void FixedUpdate()
    {
        input.y = 0;
        GetComponent<Rigidbody>().AddForce(input * force);

        if (jump)
        {
            jump = false;
            GetComponent<Rigidbody>().AddForce(Vector3.up * (jumpForce - GetComponent<Rigidbody>().velocity.y), ForceMode.VelocityChange);
        }
    }
}
