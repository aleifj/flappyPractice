using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;//static �߿�.

    [SerializeField] private PlayCanvas canvas;
    
    private int score = 0;
    public int Score { get { return score; } }//���� score�� PlayCanvas������ ������ �̷��� ����.

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
}
