using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenerySpawner : MonoBehaviour
{

    [SerializeField] float treeLeftSpawnPositionXUpper = 1382.9f;
    [SerializeField] float treeLeftSpawnPositionXLower = 1340f;
    [SerializeField] float treeRightSpawnPositionXUpper = 1382.9f;
    [SerializeField] float treeRightSpawnPositionXLower = 1340f;
    [SerializeField] float treeSpawnPositionY = -383f;
    [SerializeField] float treeSpawnPositionZ = -514.3f;


    [SerializeField] float stoneLeftSpawnPositionXUpper;
    [SerializeField] float stoneLeftSpawnPositionXLower;
    [SerializeField] float stoneRightSpawnPositionXUpper;
    [SerializeField] float stoneRightSpawnPositionXLower;

    [SerializeField] float stoneSpawnPositionY;
    [SerializeField] float stoneSpawnPositionZ;

    float spawnIntervalUpper = 1f;
    float spawnIntervalLower = 0f;
 

    private int sceneryCount = 5;
    [SerializeField] int maxSceneryCount;

    [SerializeField] GameObject[] sceneryObjects = new GameObject[3];
    GameObject cylinder;

    Quaternion TreeSpawnRotation = Quaternion.Euler(180, 0, 0);
    Quaternion StoneSpawnRotation = Quaternion.Euler(172, 0, 0);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tree" || other.gameObject.tag == "Stone")
        {
            Destroy(other.gameObject);
            Invoke("SpawnScenery", Random.Range(spawnIntervalLower, spawnIntervalUpper));
            if (sceneryCount < maxSceneryCount)
            {
                Invoke("SpawnScenery", Random.Range(spawnIntervalLower, spawnIntervalUpper));
                sceneryCount += 1;
            }
        }
    }

    void SpawnScenery()
    {
        int pickRandomObject = (int)Random.Range(0, 2);
        GameObject newThing = Instantiate(sceneryObjects[pickRandomObject], GetRandomPosition(pickRandomObject), GetRotation(pickRandomObject));
        newThing.transform.SetParent(cylinder.transform, true);
    }

    Vector3 GetRandomPosition(int objectIndex)
    {
        
        int leftOrRight = Random.Range(0, 2);

        if (objectIndex == 0)
        {
            if (leftOrRight == 0)
            {
                Vector3 spawnLocation = new Vector3(Random.Range(treeLeftSpawnPositionXLower, treeLeftSpawnPositionXUpper), treeSpawnPositionY, treeSpawnPositionZ);
                return spawnLocation;
            }
            else
            {
                Vector3 spawnLocation = new Vector3(Random.Range(treeRightSpawnPositionXLower, treeRightSpawnPositionXUpper), treeSpawnPositionY, treeSpawnPositionZ);
                return spawnLocation;
            }
        }
        else
        {
            if (leftOrRight == 0)
            {
                Vector3 spawnLocation = new Vector3(Random.Range(stoneLeftSpawnPositionXLower, stoneLeftSpawnPositionXUpper), stoneSpawnPositionY, stoneSpawnPositionZ);
                return spawnLocation;
            }
            else
            {
                Vector3 spawnLocation = new Vector3(Random.Range(stoneRightSpawnPositionXLower, stoneRightSpawnPositionXUpper), stoneSpawnPositionY, stoneSpawnPositionZ);
                return spawnLocation;
            }
        }
    }

    Quaternion GetRotation (int objectIndex)
    {
        if (objectIndex == 0)
        {
            return TreeSpawnRotation;
        }
        else
        {
            return StoneSpawnRotation;
        }
    }

    private void Start()
    {
        cylinder = GameObject.Find("Cylinder");

        GameObject newThing = Instantiate(sceneryObjects[0], GetRandomPosition(0), GetRotation(0));
        newThing.transform.SetParent(cylinder.transform, true);
    }

}


