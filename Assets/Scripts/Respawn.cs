using UnityEngine;

public class Respawn : MonoBehaviour
{
    public BoxCollider2D boxCollider;

    void OnValidate()
    {
        boxCollider = boxCollider ?? GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = Vector3.zero;
    }
}
