using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour
{
    Enemy enemy;

    float randomtimer;
    float x;
    bool goleft;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();

        randomtimer = Random.Range(5f, 20f);
        x = -enemy.enemydata.movespeed;

        enemy.canmaove = true;
        enemy.moveing += Moving;
    }

    // Update is called once per frame
    void Update()
    {
        randomtimer -= Time.deltaTime;

        if(randomtimer <= 0)
        {
            randomtimer = Random.Range(5f, 20f);

            if(goleft)
            {
                goleft = false;
            }
            else
            {
                goleft = true;
            }
        }
    }

    public void Moving()
    {
        if(!goleft)
        {
            x = enemy.enemydata.movespeed;
        }
        else
        {
            x = -enemy.enemydata.movespeed;
        }

        enemy.rb.velocity = new Vector2(x, enemy.rb.velocity.y);
    }
}
