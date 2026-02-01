using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float Speed;
    [SerializeField] private float RotationSpeed;

    private Rigidbody2D rigidbody;
    private EnemyAwarenessController enemyAwarenessController;
    private Vector2 TargetDirection;
    public bool CanMove { get; set; } = true;
    private GameObject player;
    private EnemyMelee enemyMelee;
    [SerializeField] private float stopBuffer = 0.1f;
    [SerializeField] private CharacterObjects enemyStats;
    private Vector3 initialPosition;
    [SerializeField] private GameObject enemyPrefab;

   [SerializeField] private GameObject sprite;

    private void Awake()
    {
       
        rigidbody = GetComponent<Rigidbody2D>();
        enemyAwarenessController = GetComponent<EnemyAwarenessController>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemyMelee = GetComponent<EnemyMelee>();

        initialPosition = transform.position;

        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();    
        if(playerHealth != null )
        {
            playerHealth.OnRespawn += RespawnEnemy;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(!CanMove)
        {
            rigidbody.linearVelocity = Vector2.zero;
            return;
        }
        if(enemyAwarenessController.AwareOfPlayer)
        {
            if(player != null)
            {

                float distance = Vector2.Distance(transform.position, player.transform.position);

                if (distance <= enemyStats.attackRange - stopBuffer)
                {
                    rigidbody.linearVelocity = Vector2.zero;
                    RotateTowardsTarget();
                    return;
                }
            }
        }

        UpdateTargetDirection();
        RotateTowardsTarget(); 
        SetVelocity();

    }

    private void UpdateTargetDirection()
    {
        if(enemyAwarenessController.AwareOfPlayer)
        {
            TargetDirection = enemyAwarenessController.DirectionToPlayer;

        }
        else
        {
            TargetDirection = Vector2.zero;
        }
    }

    private void RotateTowardsTarget()
    {
        if(TargetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, TargetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        rigidbody.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        if (TargetDirection == Vector2.zero)
        {
            rigidbody.linearVelocity = Vector2.zero;

        }
        else
        {
            rigidbody.linearVelocity = transform.up * Speed;
        }
    }

    private void RespawnEnemy()
    {
       gameObject.SetActive(true);
        transform.position = initialPosition;
        
        Debug.Log("enemy respawned");
    }

    private void OnDestroy()
    {
        if(player != null)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.OnRespawn -= RespawnEnemy;
            }
        }
    }

    private void LateUpdate()
    {
        sprite.transform.rotation = Quaternion.identity;
    }
}
