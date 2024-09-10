using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum State//게임 상태를 저장할 enum.
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
    private State gameState;//게임상태(enum)를 실제로 저장할 변수
    public State GameState { get { return gameState; } }//gameState를 외부에 전달'만' 할 변수

    private void Awake()
    {
        if(instance == null)
        {//이 스크립트를 다를 곳에서도 사용하기 위해서 만듬.
            instance = this;
        }
    }
    private void Start()
    {
        GameTitle();
        Time.timeScale = 1.0f;
        audio = GetComponent<AudioSource>(); //AudioSource연결
    }
    public void PlayAudio(AudioClip clip)
    {
        audio.PlayOneShot(clip);//파라메터로 넘어온 clip을 한번만 재생시킨다.
    }
    private void ChangeState(State value)
    {
        gameState = value;

        foreach(var item in stateUI)
        {//stateUI의 모든 UI를 끈다.
            item.SetActive(false);
        }

        int temp = (int)value;//State값을 공통으로 사용하므로, (int)value를 temp로 변환.
        BackGround.sprite = BGSprite[temp % 2]; //해당하는 BackGround Sprite연결.
        stateUI[temp].SetActive(true);//필요한 stateUI를 켠다.
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
        Time.timeScale = 0f;//죽으면 게임시간을 멈춤.
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
