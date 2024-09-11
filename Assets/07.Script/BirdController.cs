using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GMState = GameManager.State;//using을 이용하여 자주쓰는 단어를 등록할 수 있다.

public class BirdController : MonoBehaviour
{
    [SerializeField] private float velocity = 1.5f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private AudioClip acWing;
    [SerializeField] private AudioClip acDie;

    private Rigidbody2D rigid;
    private GameManager gmi;//자주 쓸거같은 instance는 줄여 쓸 수 있다.

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        //새가 타이틀에서 안 떨어지게 중력값 조정.
        rigid.gravityScale = 0f;
        //자주 쓰려고 만든 instance연결.
        gmi = GameManager.instance;//instance는 using으로 등록할 수 없어 이렇게 등록함.
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gmi.GameState == GMState.READY)//using을 이용하여 자주쓰는 단어를 등록할 수 있다.
            {//게임상태가 READY이면

                gmi.GamePlay();//게임상태를 PLAY로 바꾸고
                rigid.gravityScale = 0.5f;//중력값을 게임이 되도록 조정
            }
            else if (gmi.GameState == GMState.PLAY)
            {//게임상태가 PLAY면
                rigid.velocity = Vector2.up * velocity;//위로 올라감.
                gmi.PlayAudio(acWing);
            }
        }
    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rigid.velocity.y * rotateSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gmi.GameState == GMState.PLAY)
        {
            gmi.GameOver();//instance는 using으로 등록할 수 없어 이렇게 씀.
            //새의 Flap애니메이션을 멈춘다.
            GetComponent<Animator>().enabled = false;
            if (transform.position.y > 0)
            {//새의 Y좌표에 따라 audio재생
                gmi.PlayAudio(acDie);
            }
        }
    }
}
