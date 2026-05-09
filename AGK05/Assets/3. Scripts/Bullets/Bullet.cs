using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;

    public Vector2 path;
    float bulletspeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        bulletspeed = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = path * bulletspeed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
