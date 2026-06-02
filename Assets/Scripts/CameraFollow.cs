using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;
    public float blockCamLeft = 7.42f;
    public float blockCamRight = 8.7f;
    public float blockCamBottom = -3.91f;
    public float blockCamTop = 0f;

    private Vector3 velocity;

    [SerializeField] 
    private Transform targetToFollow;

    // Update is called once per frame
    void Update()
    {
        //x = 7.42 min et 8.7 max | y = -3.91 min et 0 max
        //transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
        transform.position = new Vector3(Mathf.Clamp(targetToFollow.position.x, blockCamLeft, blockCamRight),
            Mathf.Clamp(targetToFollow.position.y, blockCamBottom, blockCamTop),transform.position.z);
        
            
        
    }
}
