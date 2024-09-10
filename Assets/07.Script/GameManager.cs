using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum State//���� ���¸� ������ enum.
    {
        TITLE,
        READY,
        PLAY,
        GAMEOVER,
        HISCORE
    }

    public static GameManager instance;

    [SerializeField] private SpriteRenderer BackGround;
    [SerializeField] private AudioClip acReady;
    [SerializeField] private AudioClip acHit;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject[] stateUI;
    [SerializeField] private Sprite[] BGSprite;

    private new AudioSource audio;
    private State gameState;//���ӻ���(enum)�� ������ ������ ����
    public State GameState { get { return gameState; } }//gameState�� �ܺο� ����'��' �� ����

    private void Awake()
    {
        if(instance == null)
        {//�� ��ũ��Ʈ�� �ٸ� �������� ����ϱ� ���ؼ� ����.
            instance = this;
        }
    }
    private void Start()
    {
        GameTitle();
        Time.timeScale = 1.0f;
        audio = GetComponent<AudioSource>(); //AudioSource����
    }
    public void PlayAudio(AudioClip clip)
    {
        audio.PlayOneShot(clip);//�Ķ���ͷ� �Ѿ�� clip�� �ѹ��� �����Ų��.
    }
    private void ChangeState(State value)
    {
        gameState = value;

        foreach(var item in stateUI)
        {//stateUI�� ��� UI�� ����.
            item.SetActive(false);
        }

        int temp = (int)value;//State���� �������� ����ϹǷ�, (int)value�� temp�� ��ȯ.
        BackGround.sprite = BGSprite[temp % 2]; //�ش��ϴ� BackGround Sprite����.
        stateUI[temp].SetActive(true);//�ʿ��� stateUI�� �Ҵ�.
    }
    public void GameTitle()
    {
        ChangeState(State.TITLE);
    }
    public void GameReady()
    {
        ChangeState(State.READY);
        PlayAudio(acReady);
    }
    public void GamePlay()
    {
        ChangeState(State.PLAY);
    }
    public void GameOver()
    {
        ChangeState(State.GAMEOVER);
        PlayAudio(acHit);
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;//������ ���ӽð��� ����.
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
