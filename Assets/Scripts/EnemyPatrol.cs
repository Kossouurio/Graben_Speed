using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;

    public int damageOnCollision =1;

    private Transform target;
    private int destPoint = 0;

    public SpriteRenderer graphics;

    public float projectionPlayer;

    public static EnemyPatrol instance;


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
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(speed * Time.deltaTime * dir.normalized, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Heal_System playerhealth = collision.transform.GetComponent<Heal_System>();
            playerhealth.TakeDamage(damageOnCollision);

            if (graphics.flipX == true)
            {
                collision.rigidbody.velocity = new Vector2(-projectionPlayer, 0);
            }
            else if (graphics.flipX == false)
            {
                collision.rigidbody.velocity = new Vector2(projectionPlayer, 0);
            }
        }
    }
}
