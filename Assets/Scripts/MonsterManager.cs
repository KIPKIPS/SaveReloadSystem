using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour {
    public GameObject[] monster;//怪物数组
    public GameObject activeMonster;
    // Start is called before the first frame update
    void Start()
    {
        //ActiveMonster();
        StartCoroutine(AliveTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActiveMonster() {
        int randomIndex = Random.Range(0, monster.Length);
        activeMonster = monster[randomIndex];
        activeMonster.SetActive(true);
        activeMonster.GetComponent<BoxCollider>().enabled=true;
    }

    IEnumerator AliveTimer() {
        //yield return 12;//12帧之后执行
        yield return new WaitForSeconds(Random.Range(1,5));
        ActiveMonster();
    }
}
