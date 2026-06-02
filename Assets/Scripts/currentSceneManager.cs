using UnityEngine;

public class currentSceneManager : MonoBehaviour
{
    public bool isPlayerPresentByDefault = false;

    public static currentSceneManager instance;

    public int coinsPickedUpInThisSceneCount;
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
}
