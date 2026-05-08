using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GunMove gunmove;

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
            gunmove.Move(Vector2.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gunmove.Move(Vector2.left);
        }

        // 점프
        if(Input.GetKeyDown(KeyCode.W))
        {
            gunmove.Jump();
        }

        // 발사
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gunmove.Shot();
        }
    }
}
