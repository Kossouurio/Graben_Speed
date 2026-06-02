using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicTrigger : MonoBehaviour
{
    public AudioClip newTrack;

    private audioManager theAM;
    // Start is called before the first frame update
    void Start()
    {
        theAM = FindObjectOfType<audioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(newTrack != null)
            {
                theAM.ChangeBGM(newTrack);
                Destroy(gameObject);
            }
            
        }
    }
}
