using UnityEngine;
using System.Collections;

public class checkpoint : MonoBehaviour
{
    private Transform playerSpawn;
    public SpriteRenderer graphics;
    public float invicibilityDelay = 0.2f;
    public float invicibilityHandleTime = 2.0f;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerSpawn.position = transform.position;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            audioManager.instance.PlaySfx(10);
            StartCoroutine(Flash());
        }
    }

    public IEnumerator Flash()
    {
        graphics.color = new Color(1f, 1f, 1f, 0.2f);
        yield return new WaitForSeconds(invicibilityDelay);
        graphics.color = new Color(1f, 1f, 1f, 0f);
        yield return new WaitForSeconds(invicibilityDelay);
        graphics.color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(invicibilityDelay);
        graphics.color = new Color(1f, 1f, 1f, 0f);
        yield return new WaitForSeconds(invicibilityDelay);
        graphics.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(invicibilityDelay);
    }
    
}
