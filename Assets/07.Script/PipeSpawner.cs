using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float heightRange = 0.5f;//생성위치
    [SerializeField] private GameObject pipePrefab;//파이프 프레팝 연결
    [SerializeField] private GameObject pipePrefabRed;//빨간 파이프 연결
    
    private float timer;

    void Update()
    {
        //게임상태가 PLAY일때만 파이프를 생성하게 한다.
        if (GameManager.instance.GameState == GameManager.State.PLAY)
        {//게임상태(state)가 PLAY일때.
            if (timer > maxTime)
            {
                SpawnPipe();//파이프스폰 시작.
                timer = 0;
            }
            timer = timer + Time.deltaTime;
        }

    }
    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));//랜덤으로 y값 정해서, 생성될 파이프의 위치 정하기.

        //랜덤으로 녹색, 빨간색 파이프 선택
        GameObject pipPf = (Random.Range(0, 100) > 10) ? pipePrefab : pipePrefabRed;

        //instantiate로 생성, 생성된 객체는 pipe라는 gameObject에 할당.
        GameObject pipe = Instantiate(pipPf, spawnPos, Quaternion.identity);
        Destroy(pipe, 5.0f);//5초뒤 파괴.
    }
}
