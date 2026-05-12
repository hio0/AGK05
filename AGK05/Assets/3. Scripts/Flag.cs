using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public Vector2 save;
    public bool issaved;

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
        if (collision.gameObject.tag == "Player" && issaved)
        {
            UIManager.UI.FadeOut(gameObject.transform.Find("saved").gameObject, 0.3f, 0.3f);

            gameObject.transform.Find("flag").gameObject.SetActive(true);
            issaved = true;
            GameManager.Instance.SetSave(save);
        }
    }
}
