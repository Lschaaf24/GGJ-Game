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

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        enemyAwarenessController = GetComponent<EnemyAwarenessController>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
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
}
