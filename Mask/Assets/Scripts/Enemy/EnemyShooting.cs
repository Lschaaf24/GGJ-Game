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

    [Header("Timer Settings")]
    [SerializeField] private float windUpTime = 3f;
    private bool isShooting = false;

    [Header("Ref")]
    [SerializeField] private GameObject bulletprefab;
    [SerializeField] private Transform playerPos;
    [SerializeField] private GameObject firepoint;
    

    private void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player")?.transform;

    }

    private void Update()
    {
        cooldowntimer += Time.deltaTime;
        EnemyAwarenessController enemyAwarenessController = this.GetComponent<EnemyAwarenessController>();

        if(enemyAwarenessController.AwareOfPlayer && enemyAwarenessController.getPlayerAwarenessDistance() <= shootRange && cooldowntimer >= cooldown && !isShooting)
        {
            Debug.Log("BEfore");
            StartCoroutine(ShootRoutine());
        }
        


    }

    private IEnumerator ShootRoutine()
    {
        isShooting = true;
        Debug.Log("about to ");

        windUpTime = UnityEngine.Random.Range(1f, 3f);
        yield return new WaitForSeconds(windUpTime);
        Debug.Log("shooting");

        Shoot();

        yield return new WaitForSeconds(cooldown);
        Debug.Log("done");

        isShooting = false;

    }

    private void Shoot()
    {
        cooldown = 0;

        GameObject bullet = Instantiate(bulletprefab, firepoint.transform.position, firepoint.transform.rotation, null);
        bullet.GetComponent<Projectile>().ShootBullets(firepoint.transform);
        Debug.Log("shot");

    }
}
