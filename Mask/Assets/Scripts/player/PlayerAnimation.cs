using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Debug.Log(animator.enabled);

        // Set the animator parameters
        UpdateAnimation(rb.linearVelocity);
    }

    void UpdateAnimation(Vector2 velocity)
    {
        animator.SetFloat("VelocityX", velocity.x);
        animator.SetFloat("VelocityY", velocity.y);
      
        if (velocity.magnitude == 0)
        {
            animator.SetBool("IsMoving", false);
        }
        else
        {
            animator.SetBool("IsMoving", true);
        }
     
    }
}
