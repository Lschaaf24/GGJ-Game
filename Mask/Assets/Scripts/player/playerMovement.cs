using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 3f; //Movement speed of player
    private Rigidbody2D rb;

    private Vector2 movement;
    public bool spriteFlip = false;
    public bool knockedBack = false;
    private bool Dead = false;

    private PlayerHealth health;
    private HealthBar healthBar;

    public bool isDodging = false;
    private bool canDodge = true;

    [SerializeField]
    private float dodgeSpeed = 10f;
    [SerializeField]
    private float dodgeDuration = 0.2f;
    [SerializeField]
    private float dodgeCooldown = 1f;
    [SerializeField]
    private int dodgeDamage = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        health = gameObject.GetComponent<PlayerHealth>();
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();

    }
    // Update is called once per frame
    void Update()
    {
        if (Dead || isDodging) return;

        rb.linearVelocity = movement * moveSpeed;

    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        movement = ctx.ReadValue<Vector2>();
    }

    public void OnDodge(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;
        if (!canDodge || Dead) return;
        StartCoroutine(Dodge());
    }


    public void Die()
    {
        Debug.Log("Player has died");
        rb.linearVelocity = Vector2.zero;
        Dead = true;
    }   

    private IEnumerator Dodge()
    {
        canDodge = false;
        isDodging = true;


        Vector2 dodgeDirection = movement.normalized;

        float elapsedTime = 0f;
        while (elapsedTime < dodgeDuration)
        {
            rb.linearVelocity = dodgeDirection * dodgeSpeed;
            elapsedTime += Time.deltaTime;
            yield return null;
        }


        isDodging = false;
        rb.linearVelocity = Vector2.zero;

        health.TakeDamage(dodgeDamage);
        healthBar.setHealth(health.currentHealth);

        yield return new WaitForSeconds(dodgeCooldown);
        canDodge = true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDodging)
        {
            if (collision.collider.CompareTag("Enemy"))
            {
                Health enemyHealth = collision.collider.GetComponent<Health>();
                enemyHealth.TakeDamage(10);

            }
        }
    }
}
       


