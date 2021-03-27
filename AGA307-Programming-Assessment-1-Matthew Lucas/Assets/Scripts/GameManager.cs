using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float timer;
    public int score;
    GameDifficulty difficulty;
    private int gCount;
    
    void Start()
    {
        timer = 30;
        ToggleDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        CountdownTimer();

        if (Input.GetKeyDown(KeyCode.G))
            ToggleDifficulty();
    }

    public void ToggleDifficulty()
    {
        gCount++;

        if (gCount == 1)
            difficulty = GameDifficulty.Medium;
        else if (gCount == 2)
            difficulty = GameDifficulty.Hard;
        else
        {
            difficulty = GameDifficulty.Easy;
            gCount = 0;
        }

        switch(difficulty)
        {
            case GameDifficulty.Easy:
                UIManager.instance.gameDifficulty = "Easy";
                EnemyManger.instance.difficultyValue = 2;
                break;
            case GameDifficulty.Medium:
                UIManager.instance.gameDifficulty = "Medium";
                EnemyManger.instance.difficultyValue = 1;
                break;
            case GameDifficulty.Hard:
                UIManager.instance.gameDifficulty = "Hard";
                EnemyManger.instance.difficultyValue = 0;
                break;
        }

    }

    public void CountdownTimer()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else
            Debug.Log("Game Over");
    }
}

public enum GameDifficulty
{
    Easy,
    Medium,
    Hard
}
