using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Transform playerSpawn;
    private Animator fadeSystem;

    public int damageDeathZone = 1;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ReplacePlayer(collision));
        }
    }
    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        PlayerMovement.instance.rb.constraints = RigidbodyConstraints2D.FreezeAll;
        fadeSystem.SetTrigger("Fade_in");
        Heal_System.instance.TakeDamage(damageDeathZone);
        yield return new WaitForSeconds(1f);
        collision.transform.position = playerSpawn.position;
        yield return new WaitForSeconds(0.8f);
        PlayerMovement.instance.rb.constraints = RigidbodyConstraints2D.FreezeRotation;

    }
}
