using System.Security;
using UnityEngine;

public class EnemyAwarenessController : MonoBehaviour
{

    public bool AwareOfPlayer { get; private set;  }

    public Vector2 DirectionToPlayer { get; private set;  }

    [SerializeField] private float PlayerAwarenessDistance;
     private Transform Player;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = Player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if(enemyToPlayerVector.magnitude <= PlayerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer= false;   
        }
    }
}
