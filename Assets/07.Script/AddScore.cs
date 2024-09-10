using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    [SerializeField] private int scoreValue;//������ �������� �־��� ��
    [SerializeField] private AudioClip acPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))//Player��� �±׷� ���� Ʈ���Ÿ� �ν�
        {
            GameManager.instance.PlayAudio(acPoint);//���⿡���� gmi�� ��ȯ ���س��� �� �����
            ScoreManager.instance.UpdateScore(scoreValue);
            //ScoreManager�� UpdateScore�Լ��� Instance�Ͽ� scoreValue���� �־���.
        }
    }
}
