using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public BoxCollider boxCollider;

    void OnValidate()
    {
        boxCollider = boxCollider ?? GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = Vector3.zero;
    }
}
