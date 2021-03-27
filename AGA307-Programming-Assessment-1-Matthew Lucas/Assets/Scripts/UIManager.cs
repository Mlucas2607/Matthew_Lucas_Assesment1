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
    public Text hintsText;

    public Animator scoreAnim;

    public string gameDifficulty;
    public int countdownTimer;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(hintsText.gameObject.activeSelf)
                hintsText.gameObject.SetActive(false);
            else
                hintsText.gameObject.SetActive(true);

        }
       

        countdownTimer = (int)GameManager.instance.timer;
        timerText.text = "Time Remaining:" + countdownTimer;

        enemiesText.text = "Enemies Left: " + EnemyManger.instance.enemiesList.Length.ToString();
        difficultyText.text = "Diffculty: " + gameDifficulty;
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + GameManager.instance.score.ToString();
        scoreAnim.SetTrigger("Score");
    }
}
