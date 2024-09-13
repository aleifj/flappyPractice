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
    private ScoreManager smi; //자주 쓰는 ScoreManager의 instance.
    void Start()
    {
        smi = ScoreManager.instance;//자주 쓰는거 선언하기.
    }

    public void UpdateScore()
    {
        scorePlay.text = smi.Score.ToString();
    }

    void Update()
    {
        
    }
}
