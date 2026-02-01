using UnityEngine;
using System.Collections;
using System;

public class PlayerHealth : Health
{
    private HealthBar healthBar;
    [SerializeField] private Transform respawnPoint;
    private bool isDead = false;
    private Renderer playerRenderer;
    private playerMovement playerMovement;
    private bool isRespawning = false;
    [SerializeField] private GameObject playerPrefab;
    public event Action OnRespawn; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {

        base.Start();

        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();

        healthBar.setMaxHealth(maxHealth);
        healthBar.setHealth(currentHealth);

        playerRenderer = GetComponent<Renderer>();
        playerMovement = GetComponent<playerMovement>();


        if (respawnPoint == null)
        {
            respawnPoint = GameObject.FindWithTag("RespawnPoint").transform;
        }

        StartCoroutine(HealthDepleting());
    }


    private IEnumerator HealthDepleting()
    {
        while (currentHealth > 0 && !isDead)
        {
            TakeDamage(1);
            healthBar.setHealth(currentHealth);

            yield return new WaitForSeconds(1f);
        }

    }

    protected override void Die()
    {
        base.Die();

        isDead = true;
        isRespawning = true;
        //gameObject.SetActive(false);

        Debug.Log("Player died: respawn = " + isRespawning);

        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
       
        //yield return new WaitForSeconds(1f);

        //gameObject.SetActive(false);
        if (playerRenderer != null)
        {
            playerRenderer.enabled = false;
        }
        

        playerMovement.enabled = false;


        yield return new WaitForSeconds(1f);

        
        
        currentHealth = maxHealth;
        healthBar.setHealth(currentHealth);
        transform.position = respawnPoint.position;

       
       


        if (respawnPoint != null)
        {
            transform.position = respawnPoint.position;
            //Debug.Log("Player has been respawned.");
        }
        else
        {
            //Debug.LogWarning("No respawn point assigned! Can't respawn player.");
        }

        if (playerRenderer != null)
        {
            playerRenderer.enabled = true;
        }

        playerMovement.enabled = true;

        isDead = false;
        isRespawning = false;
        OnRespawn?.Invoke();

        StartCoroutine(HealthDepleting());
    }
    public void AddHealth(int value)
    {
        currentHealth += value;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (healthBar != null)
        {
            healthBar.setHealth(currentHealth);
        }

    }

    public bool IsRespawning()
    {
        return isRespawning;
    }


    
}
