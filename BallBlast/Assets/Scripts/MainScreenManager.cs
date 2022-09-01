using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScreenManager : MonoBehaviour
{
    int coins;
    int bullet_damage_upgrade_cost;
    int bullet_fire_speed_upgrade_cost;

    GameObject gamemanager;
    GameObject upgrade_buttons;
    GameObject upgrade_text;
    GameObject coin_text;

    void Awake()
    {
        gamemanager = GameObject.Find("GameManager");
        upgrade_buttons = GameObject.Find("UpgradeButtons");
        upgrade_text = GameObject.Find("UpgradeText");
        coin_text = GameObject.Find("CoinText");
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("InGame");
    }

    public void BulletDamageMenuButton()
    {
        upgrade_buttons.transform.Find("BulletDamageUpgradeButton").gameObject.SetActive(true);
        upgrade_buttons.transform.Find("BulletFireSpeedUpgradeButton").gameObject.SetActive(false);
        upgrade_text.GetComponent<TextMeshProUGUI>().text = "Damage Upgrade";

    }

    public void BulletFireSpeedMenuButton()
    {
        upgrade_buttons.transform.Find("BulletFireSpeedUpgradeButton").gameObject.SetActive(true);
        upgrade_buttons.transform.Find("BulletDamageUpgradeButton").gameObject.SetActive(false);
        upgrade_text.GetComponent<TextMeshProUGUI>().text = "Fire Speed Upgrade";
    }

    public void BulletDamageUpgradeButton()
    {
        if(coins >= bullet_damage_upgrade_cost)
        {
            gamemanager.GetComponent<GameManager>().bullet_damage_upgrade++;
            gamemanager.GetComponent<GameManager>().coins -= bullet_damage_upgrade_cost;
        }
        else
        {
            // 버튼 회색, 클릭만 가능 작동은 안하게
        }
    }

    public void BulletFireSpeedUpgradeButton()
    {
        if (coins >= bullet_fire_speed_upgrade_cost)
        {
            gamemanager.GetComponent<GameManager>().bullet_fire_speed_upgrade++;
            gamemanager.GetComponent<GameManager>().coins -= bullet_fire_speed_upgrade_cost;
        }
        else
        {

        }
    }

    void Update() // button 스크립트와 이 부분 분리
    {
        //coins = gamemanager.GetComponent<GameManager>().coins;
        //bullet_damage_upgrade_cost = gamemanager.GetComponent<GameManager>().bullet_damage_upgrade * 10 + 10;
        //bullet_fire_speed_upgrade_cost = gamemanager.GetComponent<GameManager>().bullet_fire_speed_upgrade * 10 + 10;

        //upgrade_buttons.transform.Find("BulletDamageUpgradeButton").transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text =
        //    bullet_damage_upgrade_cost.ToString();
        //upgrade_buttons.transform.Find("BulletFireSpeedUpgradeButton").transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text =
        //    bullet_fire_speed_upgrade_cost.ToString();
        //coin_text.GetComponent<TextMeshProUGUI>().text =
        //    "Coins: " + coins;
    }
}