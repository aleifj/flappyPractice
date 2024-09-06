using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float PipeSpeed = 0.65f;
    void Update()
    {
        transform.position += Vector3.left * PipeSpeed * Time.deltaTime;//파이프 왼쪽으로 움직임
    }
}