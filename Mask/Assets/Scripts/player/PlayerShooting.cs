using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Wind-Up Timer")]
    [SerializeField] private float WindUp = 1.0f;
    private float windupTimer;

    [Header("Pellet settings")]
    [SerializeField] private int pelletcount = 4;

    [Header("Ref")]
    [SerializeField] private GameObject bulletprefab;
    [SerializeField] private Transform firepoint;

    private void Start()
    {
        windupTimer = WindUp;
    }

    void Update()
    {
        windupTimer += Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ExplosionPowerup")
        {
            StartCoroutine(Explode());
            Destroy(collision.gameObject);
        }
    }

    private void Shoot()
    {
        if (windupTimer < WindUp) return;

        windupTimer = 0;
        

    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(WindUp);

        float angleStep = 360f / pelletcount;
        float angle = 0f;

        for (int i = 0; i < pelletcount; i++)
        {

            Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

            GameObject bullet = Instantiate(
                bulletprefab,
                transform.position,
                rotation
            );


            Projectile projectile = bullet.GetComponent<Projectile>();
            projectile.SetOwner(Projectile.OwnerType.Player);
            projectile.ShootBullets(bullet.transform);

            angle += angleStep;
        }
    }
    

}