using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StaminaWheel : MonoBehaviour
{
    public float stamina;
    [SerializeField] public float maxStamina = 100f;

    [SerializeField] private Image greenWheel;
    [SerializeField] private Image redWheel;

    public static StaminaWheel instance;
    public float staminaCost = 50;
    public float staminaGain;
    public float staminaTick;

    public CanvasGroup canvasGroup;

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
    void Start()
    {
        stamina = maxStamina;
    }

    void Update()
    {
        if(GrapplingHook.instance.rope.enabled == true) 
        {
            canvasGroup.alpha = 1;
            if (stamina > 0)
            {
                stamina -= staminaCost * Time.deltaTime;
            }
            redWheel.fillAmount = (stamina / maxStamina + 0.07f);
            if(stamina <= 0)
            {
                redWheel.fillAmount = (stamina / maxStamina);
            }
        }
        else if (PlayerMovement.instance.isGrounded == true)
        {
            if (stamina < maxStamina)
            {
                stamina += staminaTick * Time.deltaTime;
            }
            redWheel.fillAmount = (stamina / maxStamina);
            if (stamina >= maxStamina)
            {
                canvasGroup.alpha = 0;
            }
        }
        greenWheel.fillAmount = (stamina / maxStamina);
        
        if (stamina >= maxStamina)
        {
            stamina = maxStamina;
        }


    }                
}
