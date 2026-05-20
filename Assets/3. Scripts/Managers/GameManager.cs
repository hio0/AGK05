using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : ManagerManager
{
    public static GameManager Instance;

    public bool issaved;

    public GameObject gameP;
    public GameObject clearP;
    public Transform items;
    public Transform enemys;

    public bool isstart;
    public float time;

    public Vector2 savepoint;

    private void Awake() // Awake는 오브젝트가 활성화되거나 씬에 생성될 때 가장 먼저 호출(Active도 따지지 않고 무조건 첫빠따)
    {
        if(Instance == null)
        {
            Instance = this;

            if (SaveManager.Save.issavegame)
            {
                savepoint = new Vector2(SaveManager.Save.SetData().spx, gun.transform.position.y);
                Debug.Log(savepoint);
                gun.gundata = SaveManager.Save.SetData().gd;
                time = SaveManager.Save.SetData().tm;
            }
            else
            {
                SaveManager.Save.NewData(savepoint.x, gun.gundata, time, SceneManager.GetActiveScene().name);
                SetSave(new Vector2(gun.transform.position.x, gun.transform.position.y + 4f));
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        BackToSave();
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

        for (int i = 0; i < enemys.childCount; i++)
        {
            if (enemys.GetChild(i).gameObject.activeSelf == false)
            {
                enemys.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    public void Clear()
    {
        isstart = false;

        InputManager.In.x = 0;
        InputManager.In.enabled = false;
        gun.spinspeed = 0;
        enemys.gameObject.SetActive(false);

        gameP.SetActive(false);
        clearP.SetActive(true);

        UIManager.UI.SetTMP(UIManager.UI.cleartimeT, time.ToString("F2"));
    }

    public void BackToMain()
    {
        SaveData();
        SceneManager.LoadScene("Main");
    }

    public void NextStage()
    {
        SaveData();
    }

    public void SaveData()
    {
        SaveManager.Save.SaveData(savepoint.x, gun.gundata, time, SceneManager.GetActiveScene().name);
    }
}
