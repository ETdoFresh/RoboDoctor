using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool previoudGroundCheck;
    public bool groundCheck;
    public Vector3 startPoint = Vector2.up * 0.25f;
    public Vector3 endPoint = Vector2.down * 0.25f;

    public UnityEventGameObject onEnterGround;
    public UnityEventGameObject onExitGround;

    private void Update()
    {
        Debug.DrawLine(transform.position + startPoint, transform.position + endPoint);

        if (previoudGroundCheck != groundCheck)
        {
            if (groundCheck) onEnterGround.Invoke(gameObject);
            else onExitGround.Invoke(gameObject);

            previoudGroundCheck = groundCheck;
        }
    }

    private void FixedUpdate()
    {
        groundCheck = Physics2D.Raycast(transform.position, endPoint, (endPoint - startPoint).magnitude);
    }
}