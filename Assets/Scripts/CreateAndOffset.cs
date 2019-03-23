using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CreateAndOffset : MonoBehaviour
{
    public GameObject tree;
    public Vector3 offset = new Vector3(3, 0, 0);
    public int amount = 50;
    public bool addNegative = true;

    void Start()
    {
        if (transform.childCount < 5)
        {
            for(int i = 1; i <= 50; i++)
            {
                Instantiate(tree, transform.position + offset * i, transform.rotation, transform);
                if (addNegative)
                    Instantiate(tree, transform.position + offset * -i, transform.rotation, transform);
            }
        }
    }
}
