using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : ManagerManager
{
    public static DamageManager Damage;

    public GunData defultgundata;

    private void Awake()
    {
        if (Damage == null)
        {
            Damage = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        defultgundata = gun.gundata;
    }

    public void ToEnemyDamage(int damage, GameObject enemy)
    {
        enemy.GetComponent<Enemy>().hp -= damage;
    }

    public void EnemyDie(GameObject enemy)
    {
        Destroy(enemy);
    }

    public void ToPlayerWeekDamage()
    {
        if(gun.gundata == defultgundata)
        {
            ToPlayerStrongDamage();
        }
        else
        {
            gun.SetNewData(defultgundata);
        }
    }

    public void ToPlayerStrongDamage()
    {
        GameManager.Instance.BackToSave();

        if (GameManager.Instance.isstart)
        {
            gun.bulletcount = 0;
            gun.SetNewData(defultgundata);
        }
    }
}
