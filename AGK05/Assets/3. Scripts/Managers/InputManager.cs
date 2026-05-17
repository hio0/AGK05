using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : ManagerManager
{
    public static InputManager In;
    public float x;

    private void Awake()
    {
        if (In == null)
        {
            In = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");

        // 점프
        if (Input.GetKeyDown(KeyCode.W))
        {
            gun.Jump();
        }

        // 발사
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gun.Shot();
        }
    }
}
