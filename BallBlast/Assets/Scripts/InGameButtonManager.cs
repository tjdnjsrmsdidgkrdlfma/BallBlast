using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameButtonManager : MonoBehaviour
{
    public bool paused = false;

    public void PauseButton()
    {
        if(paused == true)
        {
            Time.timeScale = 1;
            GameObject.Find("Canvas/Pause/PauseFilter").SetActive(false);
            GameObject.Find("Canvas/Pause/PauseText").SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            GameObject.Find("Canvas/Pause/PauseFilter").SetActive(true);
            GameObject.Find("Canvas/Pause/PauseText").SetActive(true);
        }
        paused = !paused;
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void NotButton()
    {
        GameObject.Find("Canvas/AskQuit").SetActive(false);
    }
}
