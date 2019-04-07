using UnityEngine;

public class Controlled : MonoBehaviour
{
    public float force = 1;
    public float jumpForce = 10;

    public void Control(Vector2 input, ref bool jump)
    {
        if (input.x != 0)
            GetComponent<RigidBodyModifiers>().enableXDrag = false;
        else
            GetComponent<RigidBodyModifiers>().enableXDrag = true;

        input.y = 0;
        GetComponent<Rigidbody2D>().AddRelativeForce(input * force);

        if (jump && GetComponent<GroundCheck>() && GetComponent<GroundCheck>().groundCheck)
        {
            var velocity = new Vector2(Mathf.Cos(Mathf.Deg2Rad * (transform.eulerAngles.z + 90)), Mathf.Sin(Mathf.Deg2Rad * (transform.eulerAngles.z + 90)));
            GetComponent<Rigidbody2D>().velocity += velocity * (jumpForce - GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    public void Interact()
    {
        foreach (var interactor in GetComponents<Interactor>())
            interactor.OnInteract();
    }
}
