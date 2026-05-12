using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : ManagerManager
{
    public static UIManager UI;

    public TMP_Text bulletT;
    public TMP_Text timerT;

    private void Awake()
    {
        if (UI == null)
        {
            UI = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletT.text = gun.bulletcount.ToString();
        timerT.text = GameManager.Instance.time.ToString("F2");
    }

    public void FadeOut(GameObject obj, float startime, float outingtime)
    {
        obj.SetActive(false);
    }
}
