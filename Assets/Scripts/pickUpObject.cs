using System.Collections;
using UnityEngine;

public class pickUpObject : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound;
    public float waitAfterDestroy = 0.1f;
    public SpriteRenderer graphics;
    public Collider2D coll;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //PlayOneShot() est une methode asynchrone, ce qui peut poser problème avec le Destroy --> besoin d'une coroutine ?
            //Yes ça peut fonctionner mais d'autres parlent d'utiliser un Audio Manager, ce que je vais faire
            //audioSource.PlayOneShot(sound);
            audioManager.instance.PlaySfx(0);
            Inventory.instance.AddCoins(1);
            currentSceneManager.instance.coinsPickedUpInThisSceneCount++;
            Destroy(gameObject);
        }
    }    
}
