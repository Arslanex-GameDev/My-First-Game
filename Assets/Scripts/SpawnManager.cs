using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private GameObject[] prefabs;

    private float nextSpawnTime = 1f;
    private float spawnRate = 5f;
    private PlayerScript playerScript;

    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    void Update()
    {
        if(playerScript.gameOver != true){
            if(Time.timeSinceLevelLoad > nextSpawnTime){
                nextSpawnTime += spawnRate;
                SpawnObject(prefabs[RandomObjectSpawner(prefabs)], spawnPositions[RandomNumberSpawner(spawnPositions)]);
            }
        }
    }
    
    private void SpawnObject(GameObject objectToSpawn, Transform newTransform){
        Instantiate(objectToSpawn, newTransform.position, newTransform.rotation);
    }
    
    private int RandomNumberSpawner(Transform[] positions){
        return Random.Range(0, positions.Length);
    }

    private int RandomObjectSpawner(GameObject[] prefabs){
        return Random.Range(0, prefabs.Length);
    }
}
