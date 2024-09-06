using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float heightRange = 0.5f;//생성위치
    [SerializeField] private GameObject pipePrefab;
    
    private float timer;

    void Update()
    {
        if(timer > maxTime)
        {
            SpawnPipe();
            timer = 0;
        }
        timer = timer + Time.deltaTime;
    }
    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        //instantiate로 생성, 생성된 객체는 pipe라는 gameObject에 할당.
        GameObject pipe = Instantiate(pipePrefab, spawnPos, Quaternion.identity);
        Destroy(pipe, 5.0f);//5초뒤 파괴.
    }
}
