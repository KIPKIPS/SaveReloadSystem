using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save {
    public List<int[]>grid=new List<int[]>();
    //public List<int> livingMonsterPos = new List<int>();//存在激活怪物的格子
    //public List<int> activeMonsterType = new List<int>();//存储激活怪物的类型
    public int score = 0;//分数
    public bool bgm=true;
}
