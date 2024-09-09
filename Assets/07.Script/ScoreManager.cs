using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;//static �߿�.
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;

    private void Awake()
    {//awake���� instance����.
        if (instance == null) instance = this;
    }
    public void UpdateScore(int value)//scoreValue�� �־���
    {
        score += value;
        scoreText.text = score.ToString();
    }
}
