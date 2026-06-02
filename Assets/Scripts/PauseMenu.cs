using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string LevelToLoad;
    //static permet d'acceder à la variable dans d'autres scripts
    public static bool isGamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsWindow;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            
            if(isGamePaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        GrapplingHook.instance.isOnMenu = true;
        ShootingPlayer.instance.canFire = false;
        audioManager.instance.PlaySfx(18);
        GameObject.Find("PlayerCanvas").transform.GetChild(0).gameObject.SetActive(false);
        PlayerMovement.instance.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void Resume()
    {
        audioManager.instance.PlaySfx(19);
        PlayerMovement.instance.enabled = true;
        GameObject.Find("PlayerCanvas").transform.GetChild(0).gameObject.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        ShootingPlayer.instance.canFire = true;
        GrapplingHook.instance.isOnMenu = false;
    }

    public void OpenSettingsWindow()
    {
        audioManager.instance.PlaySfx(16);
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        audioManager.instance.PlaySfx(17);
        settingsWindow.SetActive(false);
    }

    public void LoadMainMenu()
    {
        audioManager.instance.PlaySfx(19);
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        Resume();
        SceneManager.LoadScene("Menu");
        

    }
}
