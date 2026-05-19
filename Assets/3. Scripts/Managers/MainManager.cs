using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Main;

    public Transform content;
    public GameObject creditP;
    public GameObject nondataT;

    public GameObject saveslot;

    private void Awake()
    {
        if (Main == null)
        {
            Main = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SaveManager.Save.GetAllData();
    }

    // Update is called once per frame
    void Update()
    {
        if(content.childCount <= 0)
        {
            nondataT.SetActive(true);
        }
        else
        {
            nondataT.SetActive(false);
        }
    }

    public void SaveSlotSet(string name, float time, Sprite sprite)
    {
        Debug.Log("saveslotset");

        GameObject pre = Instantiate(saveslot, content);

        pre.GetComponent<SaveSlots>().savedata = SaveManager.Save.data;
        pre.transform.GetChild(0).GetComponent<TMP_Text>().text = name;
        pre.transform.GetChild(1).GetComponent<TMP_Text>().text = time.ToString("F2");
        pre.transform.GetChild(2).GetComponent<Image>().sprite = sprite;
        pre.GetComponent<Button>().onClick.AddListener(() => SavedGame(pre.GetComponent<Button>()));
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Stage1");
        SaveManager.Save.issavegame = false;
    }

    public void SavedGame(Button b)
    {
        Debug.Log("savedgame");
        SaveManager.Save.filename = b.gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text + ".json";
        SaveManager.Save.data = b.GetComponent<SaveSlots>().savedata;

        SceneManager.LoadScene(b.GetComponent<SaveSlots>().savedata.stage);
        SaveManager.Save.issavegame = true;
    }

    public void Credit()
    {
        StartCoroutine(CreditActive());
    }

    IEnumerator CreditActive()
    {
        creditP.SetActive(true);
        yield return new WaitForSeconds(2f);

        creditP.SetActive(false);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
