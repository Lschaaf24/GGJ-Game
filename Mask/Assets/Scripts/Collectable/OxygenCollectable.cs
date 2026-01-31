using UnityEngine;

public class OxygenCollectable : MonoBehaviour
{
    [SerializeField] private int healthAdded = 50;
   
    private PlayerHealth health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        //health = GetComponent<PlayerHealth>();
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth health = collision.GetComponent<PlayerHealth>();
        health.AddHealth(healthAdded);
        Destroy(gameObject);
        Debug.Log(health.currentHealth);
    }



}
