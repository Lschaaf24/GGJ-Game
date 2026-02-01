using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    private EnemyAwarenessController enemyAwarenessController;
    private EnemyMovement enemyMovement;
    private GameObject player;
    private Health health;
   [SerializeField] private CharacterObjects enemyStats;
    private float lastAttackTime;
    private HealthBar healthBar;
   // private Vector3 initialPosition;
   // [SerializeField] private GameObject enemyPrefab;

    //public float AttackRange => enemyStats.attackRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        enemyAwarenessController = GetComponent<EnemyAwarenessController>();
        enemyMovement = GetComponent<EnemyMovement>();
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<Health>();
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        //enemyStats = player.GetComponent<CharacterObjects>();   
        lastAttackTime = -enemyStats.attackCooldown;
        //initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemyAwarenessController.AwareOfPlayer) return;
        
        float distance  = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= enemyStats.attackRange && CanAttack()) 
        {
            Attack();
        }
    }


    private bool CanAttack()
    {
        return Time.time >= lastAttackTime + enemyStats.attackCooldown;
    }

    private void Attack()
    {
        lastAttackTime = Time.time;
     
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth.IsRespawning())
        {
            Debug.Log("Player us respawning");
            return;
        }

        health.TakeDamage(enemyStats.attackDamage, transform);
        healthBar.setHealth(health.currentHealth);
        Debug.Log(health.currentHealth);
       // enemyMovement.CanMove = false;
    }


    //private void RespawnEnemy()
    //{
    //    gameObject.SetActive(true);
    //    transform.position = initialPosition;
     
    //    Debug.Log("enemy respawned");
    //}

    //private void OnDestroy()
    //{
    //    PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
    //    if (playerHealth != null)
    //    {
    //        playerHealth.OnRespawn -= RespawnEnemy;
    //    }
    //}


}
