using UnityEngine;

public class RotateWithSlope : MonoBehaviour
{
    public Vector3 startPoint = Vector2.up * 0.25f;
    public Vector3 endPoint = Vector2.down * 0.25f;
    public Normal normal;

    private void OnValidate()
    {
        normal = normal ?? GetComponent<Normal>();
    }

    private void Update()
    {
        var rotation = transform.eulerAngles;
        rotation.z = -Vector2.Angle(Vector2.up, normal.up);
        transform.eulerAngles = rotation;
    }
}
