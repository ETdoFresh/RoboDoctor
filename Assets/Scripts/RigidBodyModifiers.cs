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
        var additionalGravity = Physics2D.gravity * gravityMultiplier - Physics2D.gravity;
        if (enableGravityMultiplier) GetComponent<Rigidbody2D>()?.AddForce(additionalGravity);

        var velocity = GetComponent<Rigidbody2D>().velocity;

        var deltaX = -velocity.x * xDrag;
        if (enableXDrag) GetComponent<Rigidbody2D>()?.AddForce(new Vector2(deltaX, 0));

        var deltaY = -velocity.y * yDrag;
        if (enableYDrag) GetComponent<Rigidbody2D>()?.AddForce(new Vector2(0, deltaY));

        deltaX = Mathf.Sign(velocity.x) * (maxVelocityX - Mathf.Abs(velocity.x));
        if (enableMaxVelocityX && Mathf.Abs(velocity.x) > maxVelocityX)
            GetComponent<Rigidbody2D>().velocity += new Vector2(deltaX, 0);

        deltaY = Mathf.Sign(velocity.y) * (maxVelocityY - Mathf.Abs(velocity.y));
        if (enableMaxVelocityY && Mathf.Abs(velocity.y) > maxVelocityY)
            GetComponent<Rigidbody2D>().velocity += new Vector2(0, deltaY);
    }
}
