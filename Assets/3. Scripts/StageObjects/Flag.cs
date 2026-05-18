using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public bool useautosavespot;

    public Vector2 save;
    public bool issaved;

    public GameObject saveflag;

    // Start is called before the first frame update
    void Start()
    {
        saveflag.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(useautosavespot)
        {
            save = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 2f);
            useautosavespot = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !issaved)
        {
            StartCoroutine(UIManager.UI.FadeOut(UIManager.UI.saveT.gameObject, 2f));

            saveflag.SetActive(true);
            issaved = true;
            GameManager.Instance.SetSave(save);
        }
    }
}
