using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float PipeSpeed = 0.65f;
    [SerializeField] BoxCollider2D upPipe;
    [SerializeField] BoxCollider2D downPipe;

    public bool Moving { get; set; }

    void Update()
    {
        
        //���� ���°� PLAY�� ���� �����δ�.
        if (GameManager.instance.GameState == GameManager.State.PLAY)
        {
            if (Moving)
            {
                transform.position += Vector3.left * PipeSpeed * Time.deltaTime;//������ �������� ������
            }
        }
        else if(GameManager.instance.GameState == GameManager.State.GAMEOVER)
        {
            upPipe.enabled = false;
            downPipe.enabled = false;
        }
    }
}