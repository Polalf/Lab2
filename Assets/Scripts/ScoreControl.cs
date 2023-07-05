using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreControl : MonoBehaviour
{
    public int score;
    public int highScore;
    
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    public bool inGame;
    void Start()
    {
        Load();
    }

    
    void Update()
    {
        if(inGame)
        {
            scoreText.text = "Score " + score.ToString();
            highScoreText.text = "Highscore " + highScore.ToString();
        }
        else
        {
            highScoreText.text = highScore.ToString();
        }
        
        
        if(score > highScore)
        {
            highScore = score;
            Save();
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt("HScore",highScore);
    }

    void Load()
    {
        if(PlayerPrefs.HasKey("HScore"))
        {
            highScore = PlayerPrefs.GetInt("HScore"); 
        }
    }
}
