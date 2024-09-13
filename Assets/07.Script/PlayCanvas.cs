using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scorePlay;
    [SerializeField] private TextMeshProUGUI scoreResult;
    [SerializeField] private TextMeshProUGUI bestText;  
    [SerializeField] private Image medal;
    [SerializeField] private Sprite[] medalSprite;
    private ScoreManager smi; //���� ���� ScoreManager�� instance.
    void Start()
    {
        smi = ScoreManager.instance;//���� ���°� �����ϱ�.
    }

    public void UpdateScore()
    {
        scorePlay.text = smi.Score.ToString();
    }

    void Update()
    {
        
    }
}
