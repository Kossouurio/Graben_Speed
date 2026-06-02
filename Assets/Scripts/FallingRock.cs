using UnityEngine;

public class FallingRock : MonoBehaviour
{
    public GameObject platformPrefab;
    public float spawnRate = 2f;
    public float spawnDelay = 0f;
    public float speed = 5f;

    private float blockCamLeft;
    private float blockCamRight;
    private float blockCamBottom;
    private float blockCamTop;

    void Start()
    {
        // Obtient une référence à la caméra dans la scène
        CameraFollow cameraFollow = FindObjectOfType<CameraFollow>();

        // Vérifie si la caméra a été trouvée
        if (cameraFollow != null)
        {
            // Récupère les limites de la caméra
            blockCamLeft = cameraFollow.blockCamLeft;
            blockCamRight = cameraFollow.blockCamRight;
            blockCamBottom = cameraFollow.blockCamBottom;
            blockCamTop = cameraFollow.blockCamTop;
        }
        else
        {
            Debug.LogError("CameraFollow script not found in the scene!");
        }

        // Lance la génération de plateformes
        InvokeRepeating("SpawnPlatform", spawnDelay, spawnRate);
    }

    void SpawnPlatform()
    {
        GameObject newPlatform = Instantiate(platformPrefab, transform.position, Quaternion.identity);
        // Récupère le Rigidbody2D de la plateforme nouvellement créée
        Rigidbody2D rb = newPlatform.GetComponent<Rigidbody2D>();

        // Applique une force constante horizontale au Rigidbody2D de la plateforme
        rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
    }
}