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
    public float jumpforce;
    public float bulletimesecond;

    bool isjump;
    public Transform shotpoint;
    public GameObject bullet;
    public int bulletcount;
    float nextshot;
    bool isshot;

    // Start is called before the first frame update
    void Start()
    {
        SetNewData(gundata);
        GameManager.Instance.SetSave(new Vector2(transform.position.x, transform.position.y + 4f));
    }

    void Update()
    {
        if (isshot)
        {
            nextshot -= Time.deltaTime;
            if (nextshot <= 0)
            {
                nextshot = 0;
                isshot = false;
            }
        }
    }

    void FixedUpdate()
    {
        // 이동
        if (InputManager.In.x != 0f)
        {
            float moving = movespeed;
            if (isjump)
            {
                moving = moving / 3; // 공중에서 이동 줄이기
            }

            spinspeed = -InputManager.In.x * moving;
            if (movespeed <= 6f)
            {
                spinspeed = -InputManager.In.x * moving * 2f;
            }

            rb.AddForce(new Vector2(InputManager.In.x * moving, 0));
            //rb.velocity = new Vector2(InputManager.In.x * moving, rb.velocity.y);
            //transform.Translate(moving, 0, 0);
        }

        if (Mathf.Abs(rb.velocity.x) >= 2f) // 절댓값
        {
            rb.MoveRotation(rb.rotation + spinspeed);
        }
    }

    /*
    public void Move(Vector2 vec)
    {
        float moving = movespeed;
        if (isjump)
        {
            moving = moving / 3; // 공중에서 이동 줄이기
        }

        if (vec == Vector2.left)
        {
            spinspeed = moving;
            if (movespeed < 2f)
            {
                spinspeed = moving * 2f;
            }
            //rb.velocity = new Vector2(x * movespeed, rb.velocity.y);
        }
        else if (vec == Vector2.right)
        {
            spinspeed = moving;
            if (movespeed < 2f)
            {
                spinspeed = moving * 2f;
            }
        }
        else
        {
            Debug.Log("아무것도 없잖아;;");
        }

        rb.AddForce(vec * moving);
        transform.Rotate(0, 0, spinspeed);
    }

    */
    public void Jump()
    {
        if (!isjump)
        {
            //rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
    }

    public void Shot()
    {
        if (bulletcount > 0 && !isshot)
        {
            Quaternion quar = Quaternion.Euler(0, 0, transform.eulerAngles.z);

            GameObject b = Instantiate(bullet, shotpoint.position, quar);
            b.transform.Rotate(0, 0, -90);
            b.GetComponent<Bullet>().path = shotpoint.right;
            b.GetComponent<Bullet>().damage = gundata.bulletdamage;

            rb.AddForce(-shotpoint.right * gundata.bulletbackforce, ForceMode2D.Impulse);

            bulletcount--;
            nextshot = gundata.nextshottime;
            isshot = true;
        }
    }

    public void SetNewData(GunData data)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = data.gunsprite;
        Destroy(gameObject.GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
        movespeed = data.movespeed;

        shotpoint.localPosition = data.shotpoint;
        bulletcount = data.maxbullet;


        gundata = data;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Stage" && collision.gameObject.transform.position.y < gameObject.transform.position.y)
        {
            isjump = false;
            rb.drag = 2f;
            //spinspeed = 0f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Stage" && collision.gameObject.transform.position.y < gameObject.transform.position.y)
        {
            isjump = true;
            rb.drag = 0.5f;
        }
    }
}
