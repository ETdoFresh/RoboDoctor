using UnityEngine;

public class Normal : MonoBehaviour
{
    public float forwardVelocity;
    public float upVelocity;
    public Vector2 forward;
    public Vector2 up;

    public new Rigidbody2D rigidbody2D;

    private void OnValidate()
    {
        rigidbody2D = rigidbody2D ?? GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var velocityX = rigidbody2D.velocity.x;
        var velocityY = rigidbody2D.velocity.y;
        var magnitude = rigidbody2D.velocity.magnitude;
        var angle = Vector2.SignedAngle(Vector2.right, rigidbody2D.velocity);
        var upAngle = Mathf.Sign(-transform.localScale.x) * Vector2.SignedAngle(Vector2.right, up);
        var forwardAngle = upAngle + 90;
        forward = new Vector2(Mathf.Cos(Mathf.Deg2Rad * forwardAngle), Mathf.Sin(Mathf.Deg2Rad * forwardAngle));
        forwardVelocity = Vector2.Dot(rigidbody2D.velocity, forward);
        upVelocity = Vector2.Dot(rigidbody2D.velocity, up);
    }

    private void FixedUpdate()
    {
        var endPoint = up * -.25f;
        var startPoint = up * .25f;
        var hit = Physics2D.Raycast(transform.position, endPoint, (endPoint - startPoint).magnitude);
        if (hit)
            up = hit.normal;
        else
            up = Vector2.up;
    }
}
