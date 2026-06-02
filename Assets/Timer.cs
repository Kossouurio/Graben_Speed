using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] Text timerText;
    [SerializeField] Text highScoreTimerMinutesText;
    [SerializeField] Text highScoreTimerSecondsText;
    float elapsedTime;
    int minutes;
    int seconds;

    public static Timer instance;

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
    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
        highScoreTimerMinutesText.text = PlayerPrefs.GetInt("MinutesHighScore", 99).ToString();
        highScoreTimerSecondsText.text = PlayerPrefs.GetInt("SecondsHighScore", 99).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        minutes = Mathf.FloorToInt(elapsedTime / 60);
        seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        print(seconds);
    }

    public void GetHighScore()
    {
        if (minutes < PlayerPrefs.GetInt("MinutesHighScore", minutes))
        {
            PlayerPrefs.SetInt("MinutesHighScore", minutes);
            PlayerPrefs.SetInt("SecondsHighScore", seconds);
            highScoreTimerMinutesText.text = minutes.ToString();
            highScoreTimerSecondsText.text = seconds.ToString();
            print("minuteOrsecondDiff");
        }
        else if (minutes == PlayerPrefs.GetInt("MinutesHighScore", minutes) && seconds < PlayerPrefs.GetInt("SecondsHighScore", seconds))
        {
            PlayerPrefs.SetInt("SecondsHighScore", seconds);
            highScoreTimerMinutesText.text = minutes.ToString();
            highScoreTimerSecondsText.text = seconds.ToString();
            print("secondDiff");
        }
        
    }

    public void ResetTimer()
    {
        minutes = 0;
        seconds = 0;
        timerText.text = "00:00";
        print("timerreseted");
    }

   public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("MinutesHighScore");
        PlayerPrefs.DeleteKey("SecondsHighScore");
    }
}
