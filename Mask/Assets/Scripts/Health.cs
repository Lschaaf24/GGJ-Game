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
    public Animator animator;
    public GameObject bloodParticle;
    private FollowPlayer cameraShake;
    private Rigidbody2D rb;
    public bool isKnockedBack = false;
    public float knockbackDuration = 0.2f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        if (stats != null)
        {
            maxHealth = stats.maxHealth;
            currentHealth = stats.maxHealth;
        }

        cameraShake = Camera.main.GetComponent<FollowPlayer>();
    }

    public void TakeDamage(int damage, Transform attacker)
    {
        currentHealth -= damage;

        if (attacker != null)
        {
            ApplyKnockback(attacker);
        }
        if (currentHealth <= 0)
        {
            Die();
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

    private void Die()
    {
        animator.SetTrigger("Death");

        if (onDeath != null)
        {
            onDeath.Invoke();
        }

        Destroy(gameObject);
    }
}


