using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class Data
{
    public float savepointx;
    public GunData gundata;
    public float time;
    public int stage;
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager Save;

    public Data data;

    private void Awake()
    {
        if (Save == null)
        {
            Save = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GetAllData();
    }


    public void SaveData(float a, GunData b, float t, int d)
    {
        data.savepointx = a;
        data.gundata = b;
        data.time = t;
        data.stage = d;

        string json = JsonUtility.ToJson(data); // 데이터를 json으로 변환

        DateTime now = DateTime.Now;
        string filepath = Path.Combine(Application.persistentDataPath, $"{now.Year}-{now.Month}-{now.Date}"); // 저장 장소 및 이름 설정.
        File.WriteAllText(filepath, json); // 저장
    }

    public void GetAllData()
    {
        string[] files = Directory.GetFiles(Application.persistentDataPath); // 경로 내 모든 파일 저장

        foreach (string file in files) // 모든 파일 탐색
        {
            string json = File.ReadAllText(file); // 파일 읽고
            data = JsonUtility.FromJson<Data>(json); // 기져와서 json에서 데이터로 다시 변환

            MainManager.Main.SaveSlotSet(Path.GetFileNameWithoutExtension(file), data.time, data.gundata.gunsprite); // 세이브 슬롯 만듬.
        }
    }

    public (float spx, GunData gd, float tm, int stgn) SetData(float a, GunData b, float t, int d, string filename)
    {
        return (a, b, t, d);
    }
}
