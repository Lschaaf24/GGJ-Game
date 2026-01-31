using UnityEngine;
using System.Collections;

public class PlayerHealth : Health
{
    private HealthBar healthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {

        base.Start();

        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();

        healthBar.setMaxHealth(maxHealth);
        healthBar.setHealth(currentHealth);

        StartCoroutine(HealthDepleting());
    }


    private IEnumerator HealthDepleting()
    {
        while ( currentHealth > 0)
        {
            TakeDamage(1);
            healthBar.setHealth(currentHealth);

            yield return new WaitForSeconds(1f);
        }

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
}
