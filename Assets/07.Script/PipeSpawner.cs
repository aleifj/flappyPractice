using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float heightRange = 0.5f;//������ġ
    [SerializeField] private GameObject[] pipePrefab;//������ ������ ����
    [SerializeField] private GameObject[] pipePrefabRed;//���� ������ ����

    private const int MAX_PIPE = 4;//������Ʈ Ǯ���� ���� �̸� ����� ���� �ִ� ������ ����.
    private int pipeIndex;//������ƮǮ���� ���� �ε��� ����� ����.

    
    private float timer;

    void Update()
    {
        //���ӻ��°� PLAY�϶��� �������� �����ϰ� �Ѵ�.
        if (GameManager.instance.GameState == GameManager.State.PLAY)
        {//���ӻ���(state)�� PLAY�϶�.
            if (timer > maxTime)
            {
                SpawnPipe();//���������� ����.
                timer = 0;
            }
            timer = timer + Time.deltaTime;
        }

    }
    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));//�������� y�� ���ؼ�, ������ �������� ��ġ ���ϱ�.

        /*�������� ���, ������ ������ ����
        GameObject pipPf = (Random.Range(0, 100) > 10) ? pipePrefab : pipePrefabRed;

        instantiate�� ����, ������ ��ü�� pipe��� gameObject�� �Ҵ�.
        GameObject pipe = Instantiate(pipPf, spawnPos, Quaternion.identity);
        Destroy(pipe, 5.0f);//5�ʵ� �ı�.*/

        //������Ʈ Ǯ��
        if((Random.Range(0, 100) < 10))
        {
            pipePrefabRed[pipeIndex].transform.SetPositionAndRotation(spawnPos, Quaternion.identity);
            pipePrefabRed[pipeIndex].GetComponent<MovePipe>().Moving = true;
        }
        else
        {
            pipePrefab[pipeIndex].transform.SetPositionAndRotation(spawnPos, Quaternion.identity);
            pipePrefab[pipeIndex].GetComponent<MovePipe>().Moving = true;
        }

        if(++pipeIndex == MAX_PIPE)
        {
            pipeIndex = 0;
        }
    }
}
