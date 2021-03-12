using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManger : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoints;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            SpawnEnemies();
    }

    void SpawnEnemies()
    {
        int randomNumX = Random.Range(0,enemies.Length);
        int randomNumY = Random.Range(0, spawnPoints.Length);
        Instantiate(enemies[randomNumX], spawnPoints[randomNumY].position,spawnPoints[randomNumY].rotation);
    }
}
