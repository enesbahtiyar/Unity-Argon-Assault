using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] int score = 0;
    TMP_Text scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = score.ToString();
    }

    public void increaseScore(int Score)
    {
        score = score + Score; 
        scoreText.text = Score.ToString();
    }
}
