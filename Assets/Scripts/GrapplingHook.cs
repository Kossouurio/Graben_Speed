using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class GrapplingHook : MonoBehaviour
{

    [SerializeField] private float grapplingForce;
    [SerializeField] private LayerMask layerMask;
    public LineRenderer rope;
    [SerializeField] private float grappleLength = Mathf.Infinity;

    Rigidbody2D rb;
    private Vector3 grapplePoint;
    private DistanceJoint2D joint;
    public bool isGrappling = false;
    public bool isOnMenu = false;


    public static GrapplingHook instance;


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
        rb = GetComponent<Rigidbody2D>();
        joint = gameObject.GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        rope.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseInScreen = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseInScreen.z = 0;
        Debug.DrawLine(transform.position, mouseInScreen, Color.magenta);
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, mouseInScreen - transform.position, grappleLength, layerMask);
            if (!isOnMenu)
            {
                if (hit && StaminaWheel.instance.stamina > 0)
                {
                    audioManager.instance.PlaySfx(12);
                    isGrappling = true;
                    rope.SetPosition(0, hit.point);
                    rope.SetPosition(1, transform.position);
                    rope.enabled = true;

                    rb.AddForce((new Vector3(hit.point.x, hit.point.y, 0f) - transform.position) * grapplingForce, ForceMode2D.Impulse);
                }
            }
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            rope.enabled = false;
        }

        if (rope.enabled == true)
        {
            rope.SetPosition(1, transform.position);
        }

        if (PlayerMovement.instance.isGrounded == true)
        {
            isGrappling = false;
        }
    }
}
