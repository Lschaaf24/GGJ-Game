using UnityEngine;

public class Animation : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] private bool isEnemy = true;

    void Start()
    {
        if (isEnemy)
        {
            rb = transform.parent.GetComponent<Rigidbody2D>();
        }
        else
        {
            rb = GetComponent<Rigidbody2D>();

        }

        animator = GetComponent<Animator>();
    }

    void Update()
    {
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

    public void playDeath() 
    {
        animator.SetBool("IsDead", true);
    }
}
