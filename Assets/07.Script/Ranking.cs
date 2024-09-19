using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Ranking : MonoBehaviour
{
    public const int MAX_RANK = 5;
    public static string DTPattern = @"yyMMddhhmmss";//using System적어야됨.
    [SerializeField] private RankUI[] ranking;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < MAX_RANK; i++)
        {
            string key = PlayerPrefs.GetString($"RANKDATE{i}", $"24010112000{i}");
            int value = PlayerPrefs.GetInt($"RANKSCORE{i}", 0);
            ranking[i].SetRank(i, value, key);
        }
    }

    public int CalcurateRank(int score)
    {
        Dictionary<string, int> rankDic = new Dictionary<string, int>();
        for(int i = 0; i < MAX_RANK; i++)
        {
            string key = PlayerPrefs.GetString($"RANKDATE{i}", $"24010112000{i}");
            int value = PlayerPrefs.GetInt($"RANKSCORE{i}", 0);
            rankDic.Add(key, value);
        }
        string nowKey = DateTime.Now.ToString(DTPattern);
        rankDic.Add(nowKey, score);

        var newDic = rankDic.OrderByDescending(x => x.Value);//Linq필요함.내림차순
        int nowRanking = MAX_RANK;
        int index = 0;
        foreach(var item in newDic)
        {
            PlayerPrefs.SetString($"RANKDATE{index}", item.Key);
            PlayerPrefs.SetInt($"RANKSCORE{index}", item.Value);
            if(item.Key.CompareTo(nowKey) == 0)
            {
                nowRanking = index;
            }
            if (++index == MAX_RANK) break;
        }
        return 0;
    }
}
