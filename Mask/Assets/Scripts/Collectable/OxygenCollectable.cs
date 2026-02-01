using System.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class OxygenCollectable : MonoBehaviour
{
    [SerializeField] private int healthAdded = 50;
    [SerializeField] private GameObject oxygenPrefab;
    [SerializeField] private Transform respawnPoint;
    private bool isDead = false;
   
    private PlayerHealth health;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<PlayerHealth>();
       
        if(health != null)
        {
            health.OnRespawn += RespawnOxygen;
        }
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        AudioManager.instance.PlaySFX(AudioManager.instance.OxygenRefillSFX);

        PlayerHealth health = collision.GetComponent<PlayerHealth>();
        health.AddHealth(healthAdded);

        isDead = true;

        Destroy(gameObject);
       // Debug.Log(health.currentHealth);
    }

    void Update()
    {
       
    }

    private void RespawnOxygen()
    {
        if (oxygenPrefab != null && respawnPoint != null)
        {
            Instantiate(oxygenPrefab, respawnPoint.position, Quaternion.identity);
            Debug.Log("Oxygen respawned");

        }
    }
   




}
