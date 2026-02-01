using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
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
        //if (velocity.x > velocity.y)
        //{
        //    animator.SetFloat("VelocityY", 0);
        //}

        //else if (velocity.y > velocity.x)
        //{
        //    animator.SetFloat("VelocityX", 0);
           
        //}



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
