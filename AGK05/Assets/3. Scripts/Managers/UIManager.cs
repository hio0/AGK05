using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : ManagerManager
{
    public static UIManager UI;

    public TMP_Text bulletT;
    public TMP_Text timerT;
    public TMP_Text saveT;
    public TMP_Text cleartimeT;
    public Image bulletimebar;

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

    public IEnumerator FillAmount(Image image, float maxtime)
    {
        while(image.fillAmount > 0)
        {
            image.fillAmount -= Time.deltaTime / maxtime;
            yield return null;
        }
    }

    public IEnumerator FadeOut(GameObject obj, float startime, float outingtime) // 코루틴은 간단히 말해 실행을 잠깐 씩 끊을 수 있는 함수입니다.
    {
        obj.SetActive(true);

        yield return new WaitForSeconds(startime); // yeild return을 이용해 startime 만큼 끊었습니다.
        
        obj.SetActive(false);
    }

    public void SetTMP(TMP_Text text, string what)
    {
        text.text = what;
    }
}
