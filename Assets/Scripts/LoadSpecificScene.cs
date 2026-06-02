using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;
    public Animator fadeSystem;

    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            Timer.instance.GetHighScore();
            StartCoroutine(loadNextScene());
            Timer.instance.ResetTimer();
        }
    }
    public IEnumerator loadNextScene()
    {         
        audioManager.instance.PlaySfx(13);
        fadeSystem.SetTrigger("Fade_in");
        yield return new WaitForSeconds(1f);
        Heal_System.instance.currentHealth = Heal_System.instance.maxHealth;
        StaminaWheel.instance.stamina = StaminaWheel.instance.maxStamina;
        audioManager.instance.PlaySfx(13);
        SceneManager.LoadScene(sceneName);
        if (sceneName == "Credits")
        {
            Heal_System.instance.Die();
        }
    }
}
