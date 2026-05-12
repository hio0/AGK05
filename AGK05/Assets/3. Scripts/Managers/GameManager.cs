using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ManagerManager
{
    public static GameManager Instance;

    public GameObject gamep;
    public GameObject clearP;

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
    }

    public void Clear()
    {
        gun.gundata.movespeed = 0;
        isstart = false;
    }
}
