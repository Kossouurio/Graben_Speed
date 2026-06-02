using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform SpawnBullet;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    public static ShootingPlayer instance;

    private void Awake()
    {
        //permet de garder une seule instance commune pour tous les niveaux et de ne pas en cr�er pour chaque
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
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        if (GrapplingHook.instance.isOnMenu == false)
        {
            Vector3 rotation = mousePos - transform.position;

            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
        

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(1) && canFire)
        {
            canFire = false;
            Instantiate(bullet, SpawnBullet.position, SpawnBullet.rotation);
        }
    }
}
