using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int coins;
    public int round;
    public int bullet_damage_upgrade;
    public int bullet_fire_speed_upgrade;

    public int bullet_damage;
    public float bullet_fire_speed;

    public Data data;
    string file_path;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        #region 세이브 로드 관련 함수

        file_path = Application.persistentDataPath + "/SaveData.txt";

        if (File.Exists(file_path))
        {
            Load();
        }
        else
        {
            ResetSaveData();
            Save();
            coins = 100;
        }

        MoveDataToLocal();

        #endregion
    }

    #region 세이브 로드 관련 함수

    public void ResetSaveData()
    {
        data.coins = "0";
        data.round = "0";
        data.bullet_damage_upgrade = "0";
        data.bullet_fire_speed_upgrade = "0";
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(file_path, json);
    }

    public void Load()
    {
        string json = File.ReadAllText(file_path);
        data = JsonUtility.FromJson<Data>(json);
    }

    public void MoveDataToLocal()
    {
        coins = int.Parse(data.coins);
        round = int.Parse(data.round);
        bullet_damage_upgrade = int.Parse(data.bullet_damage_upgrade);
        bullet_fire_speed_upgrade = int.Parse(data.bullet_fire_speed_upgrade);

    }

    #endregion

    void OnLevelWasLoaded() //나중에 수정할 예정
    {
        bullet_damage = 1 + bullet_damage_upgrade * 10 / 100; //기본 1에서 10번 업그레이드 할 때 마다 1씩 증가
        bullet_fire_speed = 1.0f / (bullet_fire_speed_upgrade + 3); //기본 속도가 3shot/s
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true)
            GameObject.Find("Canvas").transform.Find("AskQuit").gameObject.SetActive(true);
    }
}

[System.Serializable]
public class Data
{
    public string coins, round, bullet_damage_upgrade, bullet_fire_speed_upgrade;
}