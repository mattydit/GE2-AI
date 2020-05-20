using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject plane;
    public GameObject obstaclePrefab;
    public int spawnSize;

    private Mesh mesh;
    private Vector3 min;
    private Vector3 max;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 boundsOffset = new Vector3(1, 0, 1);

        mesh = plane.GetComponent<MeshFilter>().mesh;
        min = mesh.bounds.min + boundsOffset;
        max = mesh.bounds.max - boundsOffset;

        Debug.Log(min);
        Debug.Log(max);

        for (int i = 0; i < spawnSize; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(min.x, max.x), obstaclePrefab.transform.position.y, Random.Range(min.z, max.z));

            GameObject instance = Instantiate(obstaclePrefab, randomPos, Quaternion.identity, gameObject.transform);
            instance.layer = 8;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
