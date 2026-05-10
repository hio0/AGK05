using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Gun : MonoBehaviour
{
    public GunData gundata;
    public Rigidbody2D rb;
    
    public float movespeed;
    public float spinspeed;
    public float spingajungchi;
    public float jumpforce;

    bool isjump;

    public GameObject bullet;
    public int bulletcount;
    float nextshot;
    bool isshot;

    // Start is called before the first frame update
    void Start()
    {
        SetNewData(gundata);
    }

    void Update()
    {
        if (isjump && rb.velocity.sqrMagnitude > 0) // sqrMagnitude: 움직임을 감지.
        {
            transform.Rotate(0, 0, spinspeed);
        }

        if (isshot)
        {
            nextshot -= Time.deltaTime;
            if(nextshot <= 0)
            {
                nextshot = 0;
                isshot = false;
            }
        }
    }

    public void Move(Vector2 vec)
    {
        float moving = movespeed;
        if (isjump)
        {
            moving = moving / 3;
        }

        if (vec == Vector2.left)
        {
            spinspeed = movespeed * spingajungchi;
            //rb.velocity = new Vector2(x * movespeed, rb.velocity.y);
        }
        else if (vec == Vector2.right)
        {
            spinspeed = -movespeed * spingajungchi;
        }
        else
        {
            Debug.Log("아무것도 없잖아;;");
        }

        rb.AddForce(vec * moving);
        transform.Rotate(0, 0, spinspeed);
    }

    public void Jump()
    {
        if (!isjump)
        {
            //rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            isjump = true;

            rb.drag = 0.5f;
        }
    }

    public void Shot()
    {
        Transform t = null;
        t.position = gundata.shotpoint;

        if(bulletcount > 0 && !isshot)
        {
            Quaternion quar = Quaternion.Euler(0, 0, transform.eulerAngles.z);

            GameObject b = Instantiate(bullet, t.position, quar);
            b.transform.Rotate(0, 0, -90);
            b.GetComponent<Bullet>().path = t.right;

            rb.AddForce(-t.right * 5f, ForceMode2D.Impulse);
            
            bulletcount--;
            nextshot = gundata.nextshottime;
            isshot = true;
        }
    }

    public void SetNewData(GunData data)
    {
        gundata = data;

        gameObject.GetComponent<SpriteRenderer>().sprite = data.gunsprite;
        data.shotpoint = gameObject.transform.InverseTransformPoint(gundata.shotpoint);

        if(bulletcount >= data.maxbullet)
        {
            bulletcount = data.maxbullet;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "stage")
        {
            isjump = false;
            rb.drag = 2f;
            spinspeed = 0f;
        }
    }
}
