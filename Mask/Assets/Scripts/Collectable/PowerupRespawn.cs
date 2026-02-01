using UnityEngine;

public class PowerupRespawn : MonoBehaviour
{

    private Vector3 initialPosition;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.OnRespawn += RespawnEnemy;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void RespawnEnemy()
    {
        gameObject.SetActive(true);
        transform.position = initialPosition;

        Debug.Log("enemy respawned");
    }

    private void OnDestroy()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.OnRespawn -= RespawnEnemy;
        }
    }
}
