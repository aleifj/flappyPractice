using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    [SerializeField] private int scoreValue;//각각의 파이프에 넣어줄 값

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))//Player라는 태그로 들어온 트리거만 인식
        {
            ScoreManager.instance.UpdateScore(scoreValue);
            //ScoreManager의 UpdateScore함수를 Instance하여 scoreValue값을 넣어줌.
        }
    }
}
