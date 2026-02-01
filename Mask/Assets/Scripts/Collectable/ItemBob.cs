using UnityEngine;

public class ItemBob : MonoBehaviour
{
   
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.time * 5) / 200);
    }
}
