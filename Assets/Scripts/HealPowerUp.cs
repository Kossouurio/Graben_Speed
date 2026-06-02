using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public int HealthPoints;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(Heal_System.instance.currentHealth != Heal_System.instance.maxHealth)
            {
                Heal_System.instance.HealPlayer(HealthPoints);
                Destroy(gameObject);
            }
        }
    }
}
