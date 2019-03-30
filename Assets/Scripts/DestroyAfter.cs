using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float seconds = 1;

    private void Start()
    {
        Destroy(gameObject, seconds);
    }
}
