using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float cooldown = 0.25f;
    private float cooldowntimer;
    [SerializeField] private float shootRange = 5.0f;

    [Header("Shotgun settings")]
    [SerializeField] private bool isShotgun = false;
    [SerializeField] private int pelletcount = 4;
    [SerializeField] private float spreadAngle = 30f;

    [Header("Timer Settings")]
    [SerializeField] private float windUpTime = 3f;
    private bool isShooting = false;

    [Header("Ref")]
    [SerializeField] private GameObject bulletprefab;
    [SerializeField] private Transform playerPos;
    [SerializeField] private GameObject firepoint;

    private PlayerHealth playerHealth;
    

    private void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player")?.transform;
        playerHealth = playerPos?.GetComponent<PlayerHealth>();

    }

    private void Update()
    {
        cooldowntimer += Time.deltaTime;
        EnemyAwarenessController enemyAwarenessController = this.GetComponent<EnemyAwarenessController>();

        if(enemyAwarenessController.AwareOfPlayer && enemyAwarenessController.getPlayerAwarenessDistance() <= shootRange && cooldowntimer >= cooldown && !isShooting)
        {
            if(playerHealth != null && playerHealth.IsRespawning())
            {
                Debug.Log("player is respawning");
                return;
            }

            StartCoroutine(ShootRoutine());
        }
        


    }

    private IEnumerator ShootRoutine()
    {
        isShooting = true;

        windUpTime = UnityEngine.Random.Range(1f, 3f);
        yield return new WaitForSeconds(windUpTime);

        Shoot();

        yield return new WaitForSeconds(cooldown);

        isShooting = false;

    }

    private void Shoot()
    {
        cooldown = 0;

        if (isShotgun)
        {
            ShotgunShot();
        }
        else
        {
            SingleShot();
        }
    }

    private void SingleShot()
    {
        GameObject bullet = Instantiate(bulletprefab, firepoint.transform.position, firepoint.transform.rotation, null);
        bullet.GetComponent<Projectile>().ShootBullets(firepoint.transform);
        Projectile projectile = bullet.GetComponent<Projectile>();
        projectile.SetOwner(Projectile.OwnerType.Enemy);
    }

    private void ShotgunShot()
    {
        float anglestep = spreadAngle / (pelletcount - 1);
        float startangle = -spreadAngle / 2f;

        for (int i = 0; i < pelletcount; i++)
        {

            float angleOffset = startangle + anglestep * i;

            Quaternion pelletRotation = firepoint.transform.rotation * Quaternion.Euler(0f, 0f, angleOffset);

            GameObject bullet = Instantiate(
                bulletprefab,
                firepoint.transform.position,
                pelletRotation
            );


            Projectile projectile = bullet.GetComponent<Projectile>();
            projectile.SetOwner(Projectile.OwnerType.Enemy);
            projectile.ShootBullets(bullet.transform);
        }

    }


}
