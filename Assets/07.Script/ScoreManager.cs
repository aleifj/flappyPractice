using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;//static 중요.
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;

    private void Awake()
    {//awake에서 instance연결.
        if (instance == null) instance = this;
    }
    public void UpdateScore(int value)//scoreValue을 넣어줌
    {
        score += value;
        scoreText.text = score.ToString();
    }
}
