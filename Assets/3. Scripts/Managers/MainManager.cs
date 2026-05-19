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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveSlotSet(string name, float time, Sprite sprite)
    {
        GameObject pre = Instantiate(saveslot, content);

        pre.transform.GetChild(0).GetComponent<TMP_Text>().text = name;
        pre.transform.GetChild(1).GetComponent<TMP_Text>().text = time.ToString();
        pre.transform.GetChild(2).GetComponent<Image>().sprite = sprite;
    }

    public void NewGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Stage1");
    }

    public void SavedGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Stage1");
    }
}
