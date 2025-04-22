using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float range = 50.0f;
    private float startDelay = 2.0f;
    private float spawnInterval = 5.0f;
    public GameObject[] objectPrefabs;
    private PlayerController playerController;
    void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnEnemies", startDelay, spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemies()
    {
        if(playerController.GetStateOfGame())
        {
            int enemyIndex = Random.Range(0, objectPrefabs.Length);
            Instantiate(objectPrefabs[enemyIndex], GenerateSpawnPosition(), objectPrefabs[enemyIndex].transform.rotation);
        }
    }

    Vector3 GenerateSpawnPosition()
    {
        float positionX = Random.Range(-range, range);
        float positionZ = Random.Range(-range, range);
        return new Vector3(positionX, 2, positionZ);
    }
}
