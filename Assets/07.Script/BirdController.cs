using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GMState = GameManager.State;//using�� �̿��Ͽ� ���־��� �ܾ ����� �� �ִ�.

public class BirdController : MonoBehaviour
{
    [SerializeField] private float velocity = 1.5f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private AudioClip acWing;
    [SerializeField] private AudioClip acDie;

    private Rigidbody2D rigid;
    private GameManager gmi;//���� ���Ű��� instance�� �ٿ� �� �� �ִ�.

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        //���� Ÿ��Ʋ���� �� �������� �߷°� ����.
        rigid.gravityScale = 0f;
        //���� ������ ���� instance����.
        gmi = GameManager.instance;//instance�� using���� ����� �� ���� �̷��� �����.
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gmi.GameState == GMState.READY)//using�� �̿��Ͽ� ���־��� �ܾ ����� �� �ִ�.
            {//���ӻ��°� READY�̸�

                gmi.GamePlay();//���ӻ��¸� PLAY�� �ٲٰ�
                rigid.gravityScale = 0.5f;//�߷°��� ������ �ǵ��� ����
            }
            else if (gmi.GameState == GMState.PLAY)
            {//���ӻ��°� PLAY��
                rigid.velocity = Vector2.up * velocity;//���� �ö�.
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
            gmi.GameOver();//instance�� using���� ����� �� ���� �̷��� ��.
            //���� Flap�ִϸ��̼��� �����.
            GetComponent<Animator>().enabled = false;
            if (transform.position.y > 0)
            {//���� Y��ǥ�� ���� audio���
                gmi.PlayAudio(acDie);
            }
        }
    }
}
