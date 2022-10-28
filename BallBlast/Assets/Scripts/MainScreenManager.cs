using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainScreenManager : MonoBehaviour
{
    GameObject Canvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Canvas = GameObject.Find("Canvas");
            Canvas.transform.Find("AskQuit").gameObject.SetActive(true);
        }
    }
}
