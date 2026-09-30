
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreValue = 1;
    public bool destroyOnCollect = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(scoreValue);
            }
            else
            {
                Debug.LogWarning("GameManager não encontrado na cena. Certificar que existe um GameManager com script anexado.");
            }

            if (destroyOnCollect)
                Destroy(gameObject);
            else
                gameObject.SetActive(false);
        }
    }
}