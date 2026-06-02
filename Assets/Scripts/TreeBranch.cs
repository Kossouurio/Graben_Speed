using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBranch : MonoBehaviour
{

    public GameObject root;
    [Range(2f, 10f)]
    public float branchLength;
    public GameObject plant;
    public GameObject ennemy;
    private bool canGrowth = true;

    private GameObject[] objects;
    private GameObject rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.Find("PlantLocation");
        objects = new GameObject[rb.transform.childCount];
        for (int i = 0; i < rb.transform.childCount; i++)
        {
            objects[i] = rb.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ennemy && canGrowth) 
        {
            StartCoroutine(GenerateBranch());
            canGrowth = false;
        }
 
        else if (!ennemy)
        {
            
            Object.Destroy(GameObject.Find("BranchStartPoint(Clone)"));

        }

    }

    IEnumerator GenerateBranch()
    {
        

        Vector2 rootPos = root.transform.position;

        GameObject Branch = Instantiate(plant, rootPos, root.transform.rotation);
        Branch.transform.localScale = new Vector2(0.20f, 1 / branchLength);


        yield return null;
    }

}
