using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour {
    public GameObject[] monster;//怪物数组
    public GameObject activeMonster;
    // Start is called before the first frame update
    void Start()
    {
        ActiveMonster();
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
}
