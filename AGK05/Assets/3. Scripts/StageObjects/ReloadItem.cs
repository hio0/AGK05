using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Gun gun = collision.gameObject.GetComponent<Gun>();

            if(gun.bulletcount != gun.gundata.maxbullet)
            {
                gun.bulletcount = gun.gundata.maxbullet;
                Destroy(gameObject);
            }
        }
    }
}
