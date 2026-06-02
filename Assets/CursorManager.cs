using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;

    private void Start()
    {
        // Détermine le hotspot au centre de l'image du curseur
        Vector2 cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);

        // Définit le curseur personnalisé avec le hotspot au centre
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    }
}
