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

    public void UpdateResult()
    {
        if(smi.Rank < 3)//3���� ������
        {
            medal.sprite = medalSprite[smi.Rank];//�޴� ǥ��
        }
        else
        {
            medal.gameObject.SetActive(false);//�ƴϸ� ǥ�� ����.
        }
        scoreResult.text = smi.Score.ToString();
        bestText.text = PlayerPrefs.GetInt("RANKSCORE0", 0).ToString();//����Ʈ���ھ�� �ְ��ھ� �� ǥ��.

    }
}
