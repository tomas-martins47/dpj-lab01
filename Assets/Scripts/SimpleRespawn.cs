
using UnityEngine;


public class SimpleRespawn : MonoBehaviour
{
    public Transform respawnPoint;
    public string deathTag = "Death";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = respawnPoint.position;
            
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.linearVelocity = Vector2.zero;
        }
    }
}