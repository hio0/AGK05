using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ManagerManager
{
    public static GameManager Instance;

    public GameObject gameP;
    public GameObject clearP;
    public Transform items;

    public bool isstart;
    public float time;

    public Vector2 savepoint;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameP.SetActive(true);
        clearP.SetActive(false);

        isstart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isstart)
        {
            time += Time.deltaTime;
        }
    }

    public void SetSave(Vector2 point)
    {
        savepoint = point;
    }

    public void BackToSave()
    {
        gun.transform.position = savepoint;
        gun.spinspeed = 0f;

        for (int i = 0;i< items.childCount; i++)
        {
            if (items.GetChild(i).gameObject.activeSelf == false)
            {
                items.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    public void Clear()
    {
        isstart = false;

        InputManager.In.x = 0;
        InputManager.In.enabled = false;
        gun.spinspeed = 0;

        gameP.SetActive(false);
        clearP.SetActive(true);

        UIManager.UI.SetTMP(UIManager.UI.cleartimeT, time.ToString("F2"));
        time = 0;
    }
}
