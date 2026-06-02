using UnityEngine;

public class DetectBullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject); // Détruit l'objet ayant le script
            Destroy(this); // Détruit le script lui-même
        }
    }
}