using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManger : Singleton<EnemyManger>
{
    public GameObject[] enemies;
    public Transform[] spawnPoints;
    public GameObject[] enemiesList;
    public int difficultyValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            SpawnEnemies();

        if (Input.GetKeyDown(KeyCode.R))
            RandomiseEnemies();

        if (Input.GetKeyDown(KeyCode.G))
            RandomiseEnemies();

        if (Input.GetKeyDown(KeyCode.C))
        {
            for (int i = 0; i < enemiesList.Length; i++)
                Destroy(enemiesList[i]);
        }

        CountEnemies();
    }

    void SpawnEnemies()
    {
        int randomNumX = Random.Range(0,enemies.Length);
        int randomNumY = Random.Range(0, spawnPoints.Length);

        GameObject enemy = Instantiate(enemies[randomNumX], spawnPoints[randomNumY].position,spawnPoints[randomNumY].rotation);
        enemy.SendMessage("SetUpEnemy",difficultyValue);
    }

    void RandomiseEnemies()
    {
        for (int i = 0; i < enemiesList.Length; i++)
            enemiesList[i].SendMessage("SetUpEnemy",difficultyValue);
    }

    void CountEnemies()
    {
        enemiesList = GameObject.FindGameObjectsWithTag("Target");
    }
}

public enum EnemySizes
{
    Small,
    Medium,
    Large
}
