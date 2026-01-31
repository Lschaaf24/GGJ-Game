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


}
