using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorData : MonoBehaviour
{
    public Animator animator;
    public new Rigidbody rigidbody;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var scale = transform.localScale;
        scale.z = Mathf.Sign(rigidbody.velocity.x) * Mathf.Abs(scale.z);
        transform.localScale = scale;

        animator.SetFloat("VelocityX", Mathf.Abs(rigidbody.velocity.x));
    }
}
