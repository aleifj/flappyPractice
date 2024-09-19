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

    public void UpdateResult()
    {
        if(smi.Rank < 3)//3등을 넘으면
        {
            medal.sprite = medalSprite[smi.Rank];//메달 표시
        }
        else
        {
            medal.gameObject.SetActive(false);//아니면 표시 안함.
        }
        scoreResult.text = smi.Score.ToString();
        bestText.text = PlayerPrefs.GetInt("RANKSCORE0", 0).ToString();//베스트스코어는 최고스코어 값 표시.

    }
}
