using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    // 적 이름
    new public string name;

    // 적 외형
    public Sprite enemysprite;

    // 적 체력
    public int hp;

    // 적 밀려나는 정도
    public float pushforce;

    // 적 이속
    public float movespeed;

    // 움직이는 함수
    //public Action howmoveing;
}
