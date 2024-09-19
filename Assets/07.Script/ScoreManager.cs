using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;//static 중요.

    [SerializeField] private PlayCanvas canvas;
    [SerializeField] private Ranking ranking;
    
    private int score = 0;
    private int rank = 0;
    public int Score => score;
    public int Rank => rank;
    //public int Score { get { return score; } }위의 score를 PlayCanvas에서도 쓰려고 이렇게 만듬.

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
    public void ChackHiScore()
    {
        rank = ranking.CalcurateRank(score);
        canvas.UpdateResult();
    }
#if UNITY_EDITOR
    [MenuItem("FlappyBird/Reset Hi-Score", false, 1)]
    public static void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll(); ;
    }
#endif
}
