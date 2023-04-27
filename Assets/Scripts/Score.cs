using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Inspired by: https://www.youtube.com/watch?v=vZU51tbgMXk
    [SerializeField] Image milkshake;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highscore;
    public TextMeshProUGUI scoreEnd;
    public TextMeshProUGUI highscoreEnd;
    public Player playerScript;

    float distance = 0.5f;
    float scoreValue;
    float highscoreValue;
    
    

    void Start()
    {
        highscoreValue = PlayerPrefs.GetFloat("HighScore",0);
        highscore.text = $"Highscore: {highscoreValue:n0} m";
        score.text = $"Score: {scoreValue:n0} m";

    }

    void Update()
    {
        scoreValue += distance * playerScript.shakeMoveSpeed;
        score.text = $"Score: {scoreValue:n0} m";
        UpdateHighScore();
        SetScoreOnEndScreen();
        MilkshakeScore();
    }

    public void SetScoreOnEndScreen()
    {
        scoreEnd.text = $"Score: \n{scoreValue:n0} m";
        highscoreEnd.text = $"Highscore: \n{highscoreValue:n0} m";
    }

    void UpdateHighScore()
    {
        highscoreValue = PlayerPrefs.GetFloat("HighScore",0);
        highscore.text = $"Highscore: {highscoreValue:n0} m";
        if (highscoreValue < scoreValue)
        {
            PlayerPrefs.SetFloat("HighScore", scoreValue);
        }
    }

    void MilkshakeScore()
    {
        var milkshakeFillLerp = Mathf.Lerp(0,scoreValue / 100,Time.deltaTime * .2f);
        milkshake.fillAmount = milkshakeFillLerp;
    }
}

