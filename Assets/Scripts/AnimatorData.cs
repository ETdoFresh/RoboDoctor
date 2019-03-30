using UnityEngine;

public class AnimatorData : MonoBehaviour
{
    public Animator animator;
    public new Rigidbody2D rigidbody2D;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Mathf.Abs(rigidbody2D.velocity.x) > 0.1f)
        {
            var scale = transform.localScale;
            scale.x = Mathf.Sign(rigidbody2D.velocity.x) * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }

        animator.SetFloat("VelocityX", Mathf.Abs(rigidbody2D.velocity.x));
    }
}
