using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedZone : MonoBehaviour
{
    private bool isWindy = false;

    //public GameObject windSense;

    public float HorizontalSpeedBoost = 900;
    public float VerticalSpeedBoost = 900;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Right Wind on
            if (PlayerMovement.instance.spriteRenderer.flipX == false && this.CompareTag("RightWind"))
            {
                //attention ce systeme n'augmente pas de manière constante la vitesse car speedboost diminue du même montant à la sortie du collider
                PlayerMovement.instance.moveSpeed += HorizontalSpeedBoost;
                audioManager.instance.PlaySfx(15);
                print("RightWind");
                isWindy = true;
            }
            //Left Wind on
            else if (PlayerMovement.instance.spriteRenderer.flipX == true && this.CompareTag("LeftWind"))
            {
                //attention ce systeme n'augmente pas de manière constante la vitesse car speedboost diminue du même montant à la sortie du collider
                PlayerMovement.instance.moveSpeed += HorizontalSpeedBoost;
                audioManager.instance.PlaySfx(15);
                print("LeftWind");
                isWindy = true;
            }
            //Top Wind on
            else if (this.CompareTag("TopWind"))
            {
                //attention ce systeme n'augmente pas de manière constante la vitesse car speedboost diminue du même montant à la sortie du collider
                PlayerMovement.instance.rb.AddForce(new Vector2(0f, VerticalSpeedBoost));
                audioManager.instance.PlaySfx(15);
                print("TopWind");
                isWindy = true;
            }
            //Bot Wind on
            else if (this.CompareTag("BotWind"))
            {
                //attention ce systeme n'augmente pas de manière constante la vitesse car speedboost diminue du même montant à la sortie du collider
                PlayerMovement.instance.rb.AddForce(new Vector2(0f, -VerticalSpeedBoost));
                audioManager.instance.PlaySfx(15);
                print("BotWind");
                isWindy = true;
            }
        }
    }
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (this.CompareTag("TopWind"))
    //    {
    //        //attention ce systeme n'augmente pas de manière constante la vitesse car speedboost diminue du même montant à la sortie du collider
    //        PlayerMovement.instance.rb.AddForce(new Vector2(0f, 1800f));
    //        audioManager.instance.PlaySfx(15);
    //        print("TopWind");
    //        isWindy = true;
    //    }
    //}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Right Wind off
            if (isWindy == true && this.CompareTag("RightWind"))
            {
                PlayerMovement.instance.moveSpeed -= HorizontalSpeedBoost;
                print("not speed anymore");
                isWindy = false;
            }
            //Left Wind off
            else if (isWindy == true && this.CompareTag("LeftWind"))
            {
                PlayerMovement.instance.moveSpeed -= HorizontalSpeedBoost;
                print("not speed anymore");
                isWindy = false;
            }
            //Top Wind off
            else if (isWindy == true && this.CompareTag("TopWind"))
            {
                PlayerMovement.instance.rb.AddForce(new Vector2(0f, 0f));
                print("not speed anymore");
                isWindy = false;
            }
            else if (isWindy == true && this.CompareTag("BotWind"))
            {
                PlayerMovement.instance.rb.AddForce(new Vector2(0f, 0f));
                print("not speed anymore");
                isWindy = false;
            }
        }
    }
}
