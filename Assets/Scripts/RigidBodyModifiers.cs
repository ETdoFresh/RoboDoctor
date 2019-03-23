using UnityEngine;

public class RigidBodyModifiers : MonoBehaviour
{
    public float gravityMultiplier = 1;
    public float xDrag = 0;
    public float yDrag = 0;
    public float maxVelocityX = 50;
    public float maxVelocityY = 50;
    public bool enableGravityMultiplier = true;
    public bool enableXDrag = true;
    public bool enableYDrag = true;
    public bool enableMaxVelocityX = true;
    public bool enableMaxVelocityY = true;

    private void FixedUpdate()
    {
        var additionalGravity = Physics.gravity * gravityMultiplier - Physics.gravity;
        if (enableGravityMultiplier) GetComponent<Rigidbody>()?.AddForce(additionalGravity);

        var velocity = GetComponent<Rigidbody>().velocity;

        var deltaX = -velocity.x * xDrag;
        if (enableXDrag) GetComponent<Rigidbody>()?.AddForce(deltaX, 0, 0);

        var deltaY = -velocity.y * yDrag;
        if (enableYDrag) GetComponent<Rigidbody>()?.AddForce(0, deltaY, 0);

        deltaX = Mathf.Sign(velocity.x) * (maxVelocityX - Mathf.Abs(velocity.x));
        if (enableMaxVelocityX && Mathf.Abs(velocity.x) > maxVelocityX)
            GetComponent<Rigidbody>().AddForce(deltaX, 0, 0, ForceMode.VelocityChange);

        deltaY = Mathf.Sign(velocity.y) * (maxVelocityY - Mathf.Abs(velocity.y));
        if (enableMaxVelocityY && Mathf.Abs(velocity.y) > maxVelocityY)
            GetComponent<Rigidbody>().AddForce(0, deltaY, 0, ForceMode.VelocityChange);
    }
}
