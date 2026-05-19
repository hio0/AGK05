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
    public Action moveing;

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
            moveing();
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
