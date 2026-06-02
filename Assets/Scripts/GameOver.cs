using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject gameOverUI;
    public static GameOver instance;

    private void Awake()
    {
        //permet de garder une seule instance commune pour tous les niveaux et de ne pas en créer pour chaque
        if (instance != null)
        {
            Debug.LogWarning("LUIGIIIIIIII");
            return;
        }
        instance = this;
    }
    public void OnPlayerDeath()
    {
        if (currentSceneManager.instance.isPlayerPresentByDefault)
        {
            DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        }
        GameObject.Find("Canvas").transform.GetChild(2).gameObject.SetActive(false);
        gameOverUI.SetActive(true);
    }

    public void RetryButton()
    {
        Inventory.instance.RemoveCoins(currentSceneManager.instance.coinsPickedUpInThisSceneCount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Heal_System.instance.Respawn();
        gameOverUI.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(2).gameObject.SetActive(true);
    }
    public void MainMenuButton()
    {
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        SceneManager.LoadScene("Menu");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
