using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool previousGroundCheck;
    public bool groundCheck;
    public Vector3 startPoint = Vector2.up * 0.25f;
    public Vector3 endPoint = Vector2.down * 0.25f;

    public UnityEventGameObject onEnterGround;
    public UnityEventGameObject onExitGround;
    public Normal normal;

    private void OnValidate()
    {
        normal = normal ?? GetComponent<Normal>();
    }

    private void Update()
    {
        if (previousGroundCheck != groundCheck)
        {
            if (groundCheck) onEnterGround.Invoke(gameObject);
            else onExitGround.Invoke(gameObject);

            previousGroundCheck = groundCheck;
        }
    }

    private void FixedUpdate()
    {
        endPoint = normal.up * -.25f;
        startPoint = normal.up * .25f;
        groundCheck = Physics2D.Raycast(transform.position, endPoint, (endPoint - startPoint).magnitude);
    }
}