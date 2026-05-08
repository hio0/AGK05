using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class GunMove : GunManager
{
    public float movespeed;
    public float spinspeed;
    public float jumpforce;

    bool isjump;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isjump && rb.velocity.sqrMagnitude > 0.1) // 공중에서 회전을 멈추지 않게 / 움직일 경우 회전을 하게 하는 코드.
        {
            transform.Rotate(0, 0, spinspeed);
        }
    }

    public void Move(Vector2 vec)
    {
        float moving = movespeed;
        if(isjump)
        {
            moving = moving / 3; // 공중 이동 제한
        }

        if (vec == Vector2.left)
        {
            spinspeed = moving * 2;
            rb.AddForce(Vector2.left * moving);
            //rb.velocity = new Vector2(x * movespeed, rb.velocity.y);
        }
        else if (vec == Vector2.right)
        {
            spinspeed = -moving * 2;
            rb.AddForce(Vector2.right * moving);
        }
        else
        {
            Debug.Log("아무것도 없잖아;;");
        }

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

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "stage")
        {
            isjump = false;
            rb.drag = 2f;
        }
    }
}
