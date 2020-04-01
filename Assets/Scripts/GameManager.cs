﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
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
    public delegate void MusicPlay();
    private MusicPlay mp;
    public GameObject[] monsterGrids;

    public event Action newGame;//声明一个事件,发布消息
    void Awake() {
        //Debug.Log(PlayerPrefs.GetInt("MusicOn"));
        canShoot = true;
        Time.timeScale = 1;
        audioSource = GetComponent<AudioSource>();
        OF = GameObject.Find("BGM").GetComponent<Toggle>();
        if (OF.isOn) {
            audioSource.Play();
        }
        else {
            audioSource.Pause();
        }
        //if (PlayerPrefs.HasKey("MusicOn")) {
        //    int value = PlayerPrefs.GetInt("MusicOn");
        //    OF.isOn = value == 1;
        //    if (value==1) {
        //        mp = audioSource.Play;
        //    }
        //    else {
        //        mp = audioSource.Pause;
        //    }
        //    mp();
        //}
    }
    // Start is called before the first frame update
    void Start() {
        instance = this;
        scoreText = scorePanel.GetComponent<Text>();
        anim = pausePanel.GetComponent<Animator>();
        //score = PlayerPrefs.GetInt("Score");
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
        SceneManager.LoadScene(0);
        OF.isOn = true;
        canShoot = true;
        Time.timeScale = 1;
        score = 0;
        newGame?.Invoke();
    }

    public void SaveGame() {
        BinarySave();
        Time.timeScale = 1;
        Debug.Log("保存成功");
        canShoot = true;
        //PlayerPrefs.SetInt("Score",score);
        anim.SetBool("pause", false);
    }

    public void LoadGame() {
        canShoot = true;
        Time.timeScale = 1;
        //SceneManager.LoadScene(0);
        //PlayerPrefs.SetInt("Score", 0);
        //if (PlayerPrefs.HasKey("MusicOn")) {
        //    int value = PlayerPrefs.GetInt("MusicOn");
        //    OF.isOn = value == 1;
        //}
//        Save data = BinaryLoad();
//        isOn = data.bgm;
//        score = data.score;
//        foreach (var g in data.grid) {
//            monsterGrids[g[0]].SetActive(true);
//            //激活type的怪物
//            monsterGrids[g[0]].GetComponent<MonsterManager>().ActiveMonsterByType(g[1]);
//        }
    }

    public void QuitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//用于退出运行
        #else
            Application.Quit();
        #endif
    }
    public void BGMController() {
        //通过判断单选框是否被勾选上来决定音乐的播放
        //播放
        if (OF.isOn) {
            audioSource.Play();
            isOn = true;
            PlayerPrefs.SetInt("MusicOn",1);
        }
        //暂停
        else {
            audioSource.Pause();
            isOn = false;
            PlayerPrefs.SetInt("MusicOn", 0);
        }
        PlayerPrefs.Save();//保存设置的PlayerPrefs值
    }

    //创建Save对象,并存储当前游戏信息
    public Save CreateSaveObject() {
        Save save=new Save();
        //遍历格子获取信息
        foreach (GameObject grid in monsterGrids) {
            MonsterManager mm = grid.GetComponent<MonsterManager>();
            //若格子存在激活怪物
            if (mm.activeMonster!=null) {
                int[] info=new int[2];
                //将格子的位置存储
                info[0] = mm.gridPos;
                //将怪物类型存储
                info[1]=mm.activeMonster.GetComponent<Monster>().type;
                save.grid.Add(info);
            }
            save.score = score;
            save.bgm = isOn;
        }
        return save;
    }
    //二进制方法存取
    public void BinarySave() {
        //将save对象序列化(转化为二进制字节流)
        Save save = CreateSaveObject();
        //二进制格式器
        BinaryFormatter formatter=new BinaryFormatter();
        //创建文件流来保存
        FileStream file=File.Create(Application.dataPath + "/StreamingFile" + "/GameDataBinary.txt");
        //开始序列化,第一个参数为路径,第二个参数为需要序列化的对象
        formatter.Serialize(file,save);
        file.Close();
        AssetDatabase.Refresh();
    }
//    public Save BinaryLoad() {
//        //二进制格式器
//        BinaryFormatter formatter = new BinaryFormatter();
//        FileStream file = File.Open(Application.dataPath + "/StreamingFile" + "/GameDataBinary.txt", FileMode.Open);
//        Save data=(Save)formatter.Deserialize(file);
//        return data;
//    }
    //XML方法存取
    public void XMLSave() {

    }
    public void XMLLoad() {

    }
    //JSON方法存取
    public void JSONSave() {

    }
    public void JSONLoad() {

    }

}
