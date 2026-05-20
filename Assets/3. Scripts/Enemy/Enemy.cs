using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemydata;
    public Rigidbody2D rb;

    public int hp;
    public bool canmaove;
    public Action moveing; // Action은 Deligate의 일종입니다. Deligate는 함수를 넣을 수 있는 변수인 느낌이고, 선언이 귀찮기에 매개변수가 없는/있는 함수를 저장 가능한 Action과 Func로 간단하게 사용 가능합니다.

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = enemydata.enemysprite;
        hp = enemydata.hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            DamageManager.Damage.EnemyDie(gameObject);
        }

        if(canmaove && moveing != null)
        {
            moveing(); // 이렇게 변수를 사용하여 Action 내 함수를 호출합니다.
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DamageManager.Damage.EnemyDie(gameObject);
            DamageManager.Damage.ToPlayerWeekDamage();
        }
    }
}
