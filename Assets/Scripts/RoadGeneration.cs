using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGeneration : MonoBehaviour
{
    [SerializeField]
    GameObject[] RoadPrefabs;
    float spawningZ = 0;
    float roadLength = 100;
    int numOfRoads = 4;
    [SerializeField]
    Transform playerTransform;
    List<GameObject> activeRoads = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numOfRoads; i++)
        {
            if (i == 0)
                SpawnRoad(0);
            else
            SpawnRoad(Random.Range(0, RoadPrefabs.Length));
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z -110 > spawningZ - (numOfRoads* roadLength))
        {
            SpawnRoad(Random.Range(0, RoadPrefabs.Length));
            Destroy(activeRoads[0]);
            activeRoads.RemoveAt(0);
        }
    }
    public void SpawnRoad(int prefabIndex)
    {
        GameObject newroad =Instantiate(RoadPrefabs[prefabIndex], transform.forward * spawningZ, transform.rotation);
        spawningZ += roadLength;
        activeRoads.Add(newroad);
    }
}
