using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    public Text scoreText;
    public Text enemiesText;
    public Text difficultyText;
    public Text timerText;

    public string gameDifficulty;
    public int countdownTimer;
    void Start()
    {
        
    }

    void Update()
    {
        
        countdownTimer = (int)GameManager.instance.timer;

        scoreText.text = "Score: " + GameManager.instance.score.ToString();
        enemiesText.text = "Enemies Left: " + EnemyManger.instance.enemiesList.Length.ToString();
        difficultyText.text = "Diffculty: " + gameDifficulty;
        timerText.text = "Time Remaining:" + countdownTimer;
    }
}
