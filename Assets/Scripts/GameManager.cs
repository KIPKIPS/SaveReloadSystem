using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public GameObject scorePanel;
    public int score = 0;
    public Toggle OF;//背景音乐开关Toggle组件
    private Text scoreText;//得分文本框组件

    public GameObject pausePanel;
    public GameObject pauseBtn;//暂停按钮
    public bool canShoot=true;
    private Animator anim;
    public AnimationClip[] ac;
    public AudioSource audioSource;
    public bool isOn;//音乐是否打开

    void Awake() {
        canShoot = true;
        Time.timeScale = 1;
        audioSource = GetComponent<AudioSource>();
        OF = GameObject.Find("BGM").GetComponent<Toggle>();
    }
    // Start is called before the first frame update
    void Start() {
        instance = this;
        scoreText = scorePanel.GetComponent<Text>();
        anim = pausePanel.GetComponent<Animator>();
        score = PlayerPrefs.GetInt("Score");
    }

    // Update is called once per frame
    void Update() {
        scoreText.text = "Score : " + score;
    }
    public void PauseGame() {
        canShoot = false;
        anim.SetBool("pause", true);
        pausePanel.SetActive(true);
        pauseBtn.SetActive(false);
        //audio.Pause();
    }
    public void ResumeGame() {
        Time.timeScale = 1;
        anim.SetBool("pause",false);
        canShoot = true;
        //audio.Play();
    }

    public void NewGame() {
        canShoot = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("Score", 0);
    }

    public void SaveGame() {
        Debug.Log("保存成功");
        canShoot = true;
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Score",score);
        anim.SetBool("pause", false);
    }

    public void LoadGame() {
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void BGMController() {
        //通过判断单选框是否被勾选上来决定音乐的播放
        //播放
        if (OF.isOn) {
            audioSource.Play();
            isOn = true;
            PlayerPrefs.SetInt("Music",1);
        }
        //暂停
        else {
            audioSource.Pause();
            isOn = false;
            PlayerPrefs.SetInt("Music", 0);
        }
    }
}
