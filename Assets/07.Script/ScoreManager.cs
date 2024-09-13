using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;//static 중요.

    [SerializeField] private PlayCanvas canvas;
    
    private int score = 0;
    public int Score { get { return score; } }//위의 score를 PlayCanvas에서도 쓰려고 이렇게 만듬.

    private void Awake()
    {//awake에서 instance연결.
        if (instance == null) instance = this;
    }
    public void UpdateScore(int value)//scoreValue을 넣어줌
    {
        score += value;
        canvas.UpdateScore();//선언한거 불러오기만 하면 됨.
        //scoreText.text = score.ToString();PlayCanvas에서 이미 선언함.
    }
}
