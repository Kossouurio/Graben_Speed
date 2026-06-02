using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectZone : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("FallingRock"))
        {
            Destroy(collision.gameObject);
        }
    }
}
