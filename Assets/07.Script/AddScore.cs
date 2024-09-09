using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    [SerializeField] private int scoreValue;//������ �������� �־��� ��

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))//Player��� �±׷� ���� Ʈ���Ÿ� �ν�
        {
            ScoreManager.instance.UpdateScore(scoreValue);
            //ScoreManager�� UpdateScore�Լ��� Instance�Ͽ� scoreValue���� �־���.
        }
    }
}
