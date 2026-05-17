using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GunData : ScriptableObject
{
    // ÃÑ ¿ÜÇü
    public Sprite gunsprite;

    // ÃÑ ÀÌµ¿¼Óµµ
    public float movespeed;
    
    // ÃÑ±¸
    public Vector2 shotpoint;

    // ÃÖ´ëÅº¾à
    public int maxbullet;

    // ¹ß»ç µô·¹ÀÌ
    public float nextshottime;

    // ÃÑ¾Ë ÇÇÇØ·®
    public int bulletdamage;

    // ÃÑ¾Ë ¹Ýµ¿
    public float bulletbackforce;
}
