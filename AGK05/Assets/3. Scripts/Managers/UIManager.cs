using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : ManagerManager
{
    public static UIManager UI;

    public TMP_Text bulletT;
    public TMP_Text timerT;
    public TMP_Text saveT;
    public TMP_Text cleartimeT;

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
        saveT.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bulletT.text = gun.bulletcount.ToString();
        timerT.text = GameManager.Instance.time.ToString("F2");
    }

    public void FadeOut(GameObject obj, float startime, float outingtime)
    {
        bool isfadeout = false;

        obj.SetActive(true);
        while (!isfadeout)
        {
            startime -= Time.deltaTime;

            if(startime <= 0)
            {
                // 대충 페이드 아웃 시키는 코드(근데 시간 없어서 못 짬)
                obj.SetActive(false);
                isfadeout = true;
            }
        }
    }

    public void SetTMP(TMP_Text text, string what)
    {
        text.text = what;
    }
}
