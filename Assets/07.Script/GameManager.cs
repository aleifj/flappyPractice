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
        {//�� ��ũ��Ʈ�� �ٸ� �������� ����ϱ� ���ؼ� ����.
            instance = this;
        }
        Time.timeScale = 1.0f;
    } 
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;//������ ���ӽð��� ����.
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
