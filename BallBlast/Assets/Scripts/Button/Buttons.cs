using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("InGame");
    }

    public void BulletDamageUpgradeButton()
    {
        Debug.Log("BulletDamageUpgradeButton");
    }

    public void BulletFireSpeedUpgradeButton()
    {
        Debug.Log("BulletFireSpeedUpgradeButton");
    }
}
