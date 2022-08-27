using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public int round;
    public int coins;

    public int bullet_damage;
    public int bullet_damage_upgrade;
    public float bullet_fire_speed;
    public int bullet_fire_speed_upgrade;

    public Data data;
    public string file_path;

    void Awake()
    {
        bullet_damage_upgrade = 0;
        bullet_fire_speed_upgrade = 0;

        bullet_damage = 1 + bullet_damage_upgrade * 10 / 100; //기본 1에서 10번 업그레이드 할 때 마다 1씩 증가
        bullet_fire_speed = 1.0f / (bullet_fire_speed_upgrade + 3.0f); //기본 속도가 3shot/s

        file_path = Application.persistentDataPath + "/SaveData.txt";
    }

    void Start()
    {
        //round = int.Parse(data.round);
    }

    public void ResetSaveData()
    {
        data.round = "0";
        data.coins = "0";
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
}

[System.Serializable]
public class Data
{
    public string round, coins, bullet_damage_upgrade, bullet_fire_speed_upgrade;
}