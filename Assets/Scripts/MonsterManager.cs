using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour {
    public GameObject[] monster;//怪物数组
    public GameObject activeMonster;
    public AudioSource audioSource;
    public int gridPos;//格子的位置
    // Start is called before the first frame update
    void Start() {
        //ActiveMonster();
        StartCoroutine(AliveTimer());
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void ActiveMonster() {
        int randomIndex = Random.Range(0, monster.Length);
        activeMonster = monster[randomIndex];
        activeMonster.SetActive(true);
        activeMonster.GetComponent<Monster>().die = false;
        activeMonster.GetComponent<BoxCollider>().enabled = true;
        StartCoroutine(DeathTimer());
        //订阅管理者的消息,一旦发现newGame触发,就调用UpdateMonster方法
        GameManager.instance.newGame += UpdateMonster;
    }
    //随机激活怪物时间
    IEnumerator AliveTimer() {
        //yield return 12;//12帧之后执行
        yield return new WaitForSeconds(Random.Range(1, 4));
        ActiveMonster();
    }
    //将激活的怪物取消激活
    public void Deactive() {
        if (activeMonster != null) {
            activeMonster.GetComponent<BoxCollider>().enabled = false;
            activeMonster.SetActive(false);
            //activeMonster = null;
        }
        StartCoroutine(AliveTimer());
    }
    //死亡时间
    IEnumerator DeathTimer() {
        yield return new WaitForSeconds(Random.Range(3, 8));
        Deactive();
    }
    //死亡音效播放
    public void DieMusicPlay() {
        if (audioSource != null) {
            audioSource.Play();
        }
    }

    //刷新怪物,新游戏时调用
    public void UpdateMonster() {
        //Debug.Log("刷新场景");
        //清空信息
        if (activeMonster != null) {
            activeMonster.GetComponent<BoxCollider>().enabled = false;
            activeMonster.SetActive(false);
            activeMonster = null;
        }
        StopAllCoroutines();
        StartCoroutine(AliveTimer());
    }

    //按照给定的怪物类型激活怪物
    public void ActiveMonsterByType(int type) {
        //清空信息
        StopAllCoroutines();
        if (activeMonster!=null) {
            activeMonster.GetComponent<BoxCollider>().enabled = false;
            activeMonster.SetActive(false);
        }
        activeMonster = null;
        //设置重新激活的怪物信息
        activeMonster = monster[type];
        activeMonster.SetActive(true);
        activeMonster.GetComponent<BoxCollider>().enabled = true;
        StartCoroutine(DeathTimer());
    }
}
