using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class RankUI : MonoBehaviour
{
    [SerializeField]private Image medal;
    [SerializeField]private TextMeshProUGUI rankText;
    [SerializeField]private TextMeshProUGUI dateText;
    [SerializeField]private TextMeshProUGUI scoreText;
    [SerializeField]private Sprite[] medalSprite;
    
    public void SetRank(int rank, int score, string dt)
    {
        int medalIndex = (rank > 2) ? 3 : rank;//��ũ ������ 3�� �ʰ��̸� 3, �����̸� �� ���� �ε����� �Ѵ�.

        medal.sprite = medalSprite[medalIndex];//�޴� ��������Ʈ�� �ִ� �޴� ����.

        rankText.text = (rank + 1).ToString();

        //��ũ�� 3�̻��϶��� ǥ��
        rankText.gameObject.SetActive(rank > 2);
        if(dt != null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("20");
            sb.Append(dt.Substring(0, 2));
            sb.Append("/");
            sb.Append(dt.Substring(2, 2));
            sb.Append("/");
            sb.Append(dt.Substring(4, 2));
            sb.Append("Wn");
            sb.Append(dt.Substring(6, 2));
            sb.Append(":");
            sb.Append(dt.Substring(8, 2));
            sb.Append(":");
            sb.Append(dt.Substring(10, 2));
            dateText.text = sb.ToString();//StringBuilder���� �ѱ涧 tostring()�߿�.
        }
        scoreText.text = score.ToString();//���� ǥ��.
    }
}
