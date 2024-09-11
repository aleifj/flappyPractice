using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float PipeSpeed = 0.65f;
    [SerializeField] BoxCollider2D upPipe;
    [SerializeField] BoxCollider2D downPipe;

    void Update()
    {
        //게임 상태가 PLAY일 때만 움직인다.
        if (GameManager.instance.GameState == GameManager.State.PLAY)
        {
            transform.position += Vector3.left * PipeSpeed * Time.deltaTime;//파이프 왼쪽으로 움직임
        }
        else if(GameManager.instance.GameState == GameManager.State.GAMEOVER)
        {
            upPipe.enabled = false;
            downPipe.enabled = false;
        }
    }
}