using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinsCount;

    public static Inventory instance;

    public Text coinsCountText;

    private void Start()
    {
        coinsCountText.text = coinsCount.ToString();
    }

    private void Awake()
    {
        //permet de garder une seule instance commune pour tous les niveaux et de ne pas en créer pour chaque
        if(instance != null)
        {
            Debug.LogWarning("WAAAARRRRIOOOOO");
            return;
        }
        instance = this;
    }

    public void AddCoins(int count)
    {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }

    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        coinsCountText.text = coinsCount.ToString();
    }
}
