using UnityEngine;

public class AnimatorData : MonoBehaviour
{
    public Animator animator;
    public new Rigidbody2D rigidbody2D;
    public Normal normal;

    private void OnValidate()
    {
        animator = animator ?? GetComponentInChildren<Animator>();
        rigidbody2D = rigidbody2D ?? GetComponent<Rigidbody2D>();
        normal = normal ?? GetComponent<Normal>();
    }

    private void Update()
    {
        if (Mathf.Abs(rigidbody2D.velocity.x) > 0.1f)
        {
            var scale = transform.localScale;
            scale.x = Mathf.Sign(rigidbody2D.velocity.x) * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }

        animator.SetFloat("VelocityX", Mathf.Abs(normal.forwardVelocity));
    }
}
