using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour
{
    Enemy enemy;

    float randomtimer;
    float x;
    bool goright;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();

        randomtimer = Random.Range(5f, 20f);

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

            if(goright)
            {
                goright = false;
            }
            else
            {
                goright = true;
            }
        }
    }

    public void Moving()
    {
        if(goright)
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
