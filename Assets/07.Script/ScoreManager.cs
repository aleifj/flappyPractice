using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;//static �߿�.

    [SerializeField] private PlayCanvas canvas;
    [SerializeField] private Ranking ranking;
    
    private int score = 0;
    private int rank = 0;
    public int Score => score;
    public int Rank => rank;
    //public int Score { get { return score; } }���� score�� PlayCanvas������ ������ �̷��� ����.

    private void Awake()
    {//awake���� instance����.
        if (instance == null) instance = this;
    }
    public void UpdateScore(int value)//scoreValue�� �־���
    {
        score += value;
        canvas.UpdateScore();//�����Ѱ� �ҷ����⸸ �ϸ� ��.
        //scoreText.text = score.ToString();PlayCanvas���� �̹� ������.
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
