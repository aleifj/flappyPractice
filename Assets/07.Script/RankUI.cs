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
        int medalIndex = (rank > 2) ? 3 : rank;//렝크 순위가 3위 초과이면 3, 이하이면 그 값을 인덱스로 한다.

        medal.sprite = medalSprite[medalIndex];//메달 스프라이트에 있는 메달 선택.

        rankText.text = (rank + 1).ToString();

        //랭크가 3이상일때만 표시
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
            dateText.text = sb.ToString();//StringBuilder값을 넘길때 tostring()중요.
        }
        scoreText.text = score.ToString();//점수 표시.
    }
}
