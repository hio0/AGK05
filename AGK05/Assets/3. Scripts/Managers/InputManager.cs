using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Gun gun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 이동
        if(Input.GetKey(KeyCode.A))
        {
            gun.Move(Vector2.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            gun.Move(Vector2.right);
        }

        // 점프
        if(Input.GetKeyDown(KeyCode.W))
        {
            gun.Jump();
        }

        // 발사
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gun.Shot();
        }
    }
}
