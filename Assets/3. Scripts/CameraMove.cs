using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            float x = target.position.x;
            float y = target.position.y + 2f;
            // float y = Mathf.FloorToInt(target.position.y) + 2f; FloorToInt, CeilToInt 문법. 내림 / 올림 처리.(Gun이 이리저리 튕기느라 y값이 땅에선 드드드드거려서 적용.)

            gameObject.transform.position = new Vector3(x, y / 2, gameObject.transform.position.z);
        }
    }
}
