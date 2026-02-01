using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public CharacterObjects stats;
    public int currentHealth;

    public int maxHealth;
    public System.Action onDeath;
    private Rigidbody2D rb;
    public bool isKnockedBack = false;
    public float knockbackDuration = 0.2f;
    public Damageflashoverlay damageflashoverlay;
    public Animation spriteAnimation;

    protected virtual void Start()
    {


        rb = gameObject.GetComponent<Rigidbody2D>();

        if (stats != null)
        {
            maxHealth = stats.maxHealth;
            currentHealth = stats.maxHealth;

        }
        if(stats == null)
        {
            Debug.Log("Stats null");
        }

    }

    public virtual void TakeDamage(int damage, Transform attacker = null)
    {

        currentHealth -= damage;


        if (attacker != null)
        {
           AudioManager.instance.PlaySFX(AudioManager.instance.PlayerDamage_1SFX);
           ApplyKnockback(attacker);


            if (damageflashoverlay != null)
            {
                if (attacker.CompareTag("Enemy") || attacker.CompareTag("Bullet"))
                    {
                    damageflashoverlay.OnDamageTaken();
                    Debug.Log("shit");
                }
             }
        }
        if (currentHealth <= 0)
        {
            spriteAnimation.playDeath();
            rb.bodyType = RigidbodyType2D.Static;
            GetComponent<BoxCollider2D>().enabled = false;

        }
    }

    private void ApplyKnockback(Transform attacker)
    {
        if (rb == null || isKnockedBack) return;

        StartCoroutine(KnockbackCoroutine(attacker));
    }

    private IEnumerator KnockbackCoroutine(Transform attacker)
    {
        isKnockedBack = true;

        Vector2 direction = (transform.position - attacker.position).normalized;

        rb.AddForce(direction * stats.knockback, ForceMode2D.Impulse);

        yield return new WaitForSeconds(knockbackDuration);


        isKnockedBack = false;
    }

    public virtual void Die()
    {

        if (onDeath != null)
        {
            onDeath.Invoke();
        }

       Destroy(gameObject);
    }


}


