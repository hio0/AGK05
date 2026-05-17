using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    // 적 외형
    public Sprite enemysprite;

    // 적 체력
    public int hp;

    // 적 밀려나는 정도
    public float pushforce;
}
