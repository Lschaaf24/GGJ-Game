using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.transform.position + offset;
            transform.position = targetPosition;
        }
    }
}
