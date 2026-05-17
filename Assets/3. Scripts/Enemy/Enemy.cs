using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemydata;
    public Rigidbody2D rb;

    public int hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = enemydata.hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemydata.hp <= 0)
        {
            DamageManager.Damage.EnemyDie(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            DamageManager.Damage.ToPlayerWeekDamage();

            float x = collision.transform.position.x - gameObject.transform.position.x + 0.00001f; // 왜 0.00001f를 더할까요 ??
            if(x > 0)
            {
                rb.AddForce(Vector2.right * enemydata.pushforce);
            }
            else if(x < 0)
            {
                rb.AddForce(Vector2.left * enemydata.pushforce);
            }
        }
    }
}
