using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMove : GunManager
{
    public float movespeed;
    public float jumpforce;

    bool isjump;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if (x != 0)
        {
            transform.position = new Vector2(transform.position.x + x * movespeed * Time.deltaTime, transform.position.y);

            //float spin = Mathf.Atan2(1, moveDir.x) * Mathf.Rad2Deg; //Atan2는 y, x 값을 좌표 평면 상의 각도로 전환, Rad2Deg는 그 각도를 유니티용으로 변환(Atan2 쓸거면 반드시 써야함).

            float whatspin = 0;
            if (x < 0)
            {
                whatspin = -360f;
            }
            else
            {
                whatspin = 360f;
            }

            transform.rotation = Quaternion.Euler(0, 0, x + Time.time * whatspin); // rotation.z에 각도를 계속 넣기.

            if (transform.position.y < -3)
            {
                transform.position = new Vector2(transform.position.x, -3f);
            }
        }


    }

    public void Jump()
    {
        if (isjump)
        {
            rb.AddForce(Vector2.up * jumpforce * Time.deltaTime, ForceMode2D.Impulse);
            isjump = false;

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "stage")
        {
            isjump = true;
        }
    }
}
