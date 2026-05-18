using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : MonoBehaviour
{
    public GunData gundata;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = gundata.gunsprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Gun gun = collision.GetComponent<Gun>();

            if (gun.gundata != gundata)
            {
                gun.rb.AddForce(Vector2.up * 3f);
                gun.SetNewData(gundata);
                gameObject.SetActive(false);
            }
        }
    }
}
