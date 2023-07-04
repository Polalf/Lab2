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
    void Start()
    {
        Load();
    }

    
    void Update()
    {
        scoreText.text = "Score " +score.ToString();
        highScoreText.text ="Highscore "+  highScore.ToString();
        if(score > highScore)
        {
            highScore = score;
            Save();
        }
    }

    void Save()
    {
        PlayerPrefs.SetInt("Score",highScore);
    }

    void Load()
    {
        if(PlayerPrefs.HasKey("Score"))
        {
            highScore = PlayerPrefs.GetInt("Score"); 
        }
    }
}
