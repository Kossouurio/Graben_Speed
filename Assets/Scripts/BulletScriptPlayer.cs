using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class BulletScriptPlayer : MonoBehaviour
{
    public GameObject bullet;
    public float force;
    public float bulletTimeToDestroy;
   

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, bulletTimeToDestroy);
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * force * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("uifdhsuifhsu");
        Destroy(bullet);
        
        if (collision.transform.CompareTag("Enemy"))
        {
            Destroy(collision.transform.parent.gameObject);
            Object.Destroy(GameObject.Find("BranchStartPoint(Clone)"));


        }
    }
}
