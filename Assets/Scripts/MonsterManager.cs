using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour {
    public GameObject[] monster;//怪物数组
    public GameObject activeMonster;
    // Start is called before the first frame update
    void Start() {
        //ActiveMonster();
        StartCoroutine(AliveTimer());
    }

    // Update is called once per frame
    void Update() {

    }

    void ActiveMonster() {
        int randomIndex = Random.Range(0, monster.Length);
        activeMonster = monster[randomIndex];
        activeMonster.SetActive(true);
        activeMonster.GetComponent<BoxCollider>().enabled = true;
        StartCoroutine(DeathTimer());
    }
    //随机激活怪物时间
    IEnumerator AliveTimer() {
        //yield return 12;//12帧之后执行
        yield return new WaitForSeconds(Random.Range(1, 4));
        ActiveMonster();
    }
    //将激活的怪物取消激活
    public void Deactive() {
        if (activeMonster!=null) {
            activeMonster.GetComponent<BoxCollider>().enabled = false;
            activeMonster.SetActive(false);
            activeMonster = null;
        }
        StartCoroutine(AliveTimer());
    }
    //死亡时间
    IEnumerator DeathTimer() {
        yield return new WaitForSeconds(Random.Range(3,8));
        Deactive();
    }
}
