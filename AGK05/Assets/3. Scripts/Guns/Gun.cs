using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public float movespeed;
    public float spinspeed;
    public float spingajungchi;
    public float jumpforce;

    public bool isjump;

    public GameObject bullet;
    public Transform shotpoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (isjump && rb.velocity.sqrMagnitude > 0) // 공중에서 회전을 멈추지 않게 / 움직일 경우 회전을 하게 하는 코드.
        {
            transform.Rotate(0, 0, spinspeed);
        }
    }

    public void Move(Vector2 vec)
    {
        float moving = movespeed;
        if (isjump)
        {
            moving = moving / 3; // 공중 이동 제한
        }

        if (vec == Vector2.left)
        {
            spinspeed = moving * spingajungchi;
            //rb.velocity = new Vector2(x * movespeed, rb.velocity.y);
        }
        else if (vec == Vector2.right)
        {
            spinspeed = -moving * spingajungchi;
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
        Quaternion quar = Quaternion.Euler(0, 0, transform.eulerAngles.z);

        GameObject b = Instantiate(bullet, shotpoint.position, quar);
        b.transform.Rotate(0, 0, -90);
        b.GetComponent<Bullet>().path = shotpoint.right;

        rb.AddForce(-shotpoint.right * 5f, ForceMode2D.Impulse);
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
