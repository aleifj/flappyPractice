using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject gameOverUI;

    private void Awake()
    {
        if(instance == null)
        {//이 스크립트를 다를 곳에서도 사용하기 위해서 만듬.
            instance = this;
        }
        Time.timeScale = 1.0f;
    } 
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;//죽으면 게임시간을 멈춤.
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
