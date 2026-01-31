using UnityEngine;
using UnityEngine.U2D;


[RequireComponent (typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float lifetime_distance;
    [SerializeField] private int damage = 1;

    private Rigidbody2D rb;
    private float lifeTimer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ShootBullets(Transform firepoint)
    {
        lifeTimer = 0;
        rb.linearVelocity = Vector3.zero;
        transform.position = firepoint.position;
        transform.rotation = firepoint.rotation;
        gameObject.SetActive(true);

        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.collider.GetComponent<Health>();

        if (health == null)
        {
            Destroy(gameObject);
            return;
        }
        

        health.TakeDamage(damage,this.transform);
        Destroy(gameObject);


    }

    private void Update()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= lifetime_distance) { Destroy(gameObject); }
    }

}
