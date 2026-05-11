using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GunData : ScriptableObject
{
    public Sprite gunsprite;

    public Vector2 shotpoint;

    public int maxbullet;

    public float nextshottime;

    public int bulletdamage;

    public float bulletbackforce;
}
