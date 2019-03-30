using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplaySpeed : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    private void Update()
    {
        textMesh.text = "Speed: " + GetComponent<Rigidbody2D>().velocity.ToString();
    }
}
