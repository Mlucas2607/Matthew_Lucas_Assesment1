using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManger : MonoBehaviour
{
    public float timer;
    public GameObject[] enemies;
    public Transform[] spawnPoints;
    public List<GameObject> enemiesList;


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

        if (Input.GetKeyDown(KeyCode.C))
        {
            for (int i = 0; i < enemiesList.Count; i++)
            {
                if (enemiesList[i] == isActiveAndEnabled)
                    Destroy(enemiesList[i]);
                else
                    enemiesList.RemoveAt(i);
            }

            enemiesList.Clear();
        }
    }

    void SpawnEnemies()
    {
        int randomNumX = Random.Range(0,enemies.Length);
        int randomNumY = Random.Range(0, spawnPoints.Length);

        GameObject currentEnemy = Instantiate(enemies[randomNumX], spawnPoints[randomNumY].position,spawnPoints[randomNumY].rotation);
        enemiesList.Add(currentEnemy);
    }

    void RandomiseEnemies()
    {
        for (int i = 0; i < enemiesList.Count; i++)
        {
            if (enemiesList[i] == isActiveAndEnabled)
                enemiesList[i].SendMessage("SetUpEnemy");
            else
                enemiesList.RemoveAt(i);
        }
    }
}

public enum EnemySizes
{
    Small,
    Medium,
    Large
}
