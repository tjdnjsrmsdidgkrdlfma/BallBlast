using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    bool temp = false;
    bool show_text_end = false;

    GameObject create_ball;
    GameObject clear_text;
    GameObject coin_text;
    GameObject gamemanager;
    
    void Awake()
    {
        create_ball = GameObject.Find("CreateBall");
        clear_text = GameObject.Find("Canvas/RoundClearText");
        coin_text = GameObject.Find("Canvas/CoinText");
        gamemanager = GameObject.Find("GameManager");
    }

    void Update()
    {
        if (create_ball.GetComponent<CreateBall>().create_ball_ended == true)
        {
            if (GameObject.Find("Ball(Clone)") == null)
            {
                if(temp == false)
                {
                    temp = true; // 한 번만 실행
                    StartCoroutine(ShowClearText());
                }
                else if(show_text_end == true)
                {
                    show_text_end = false; // 한 번만 실행
                    StartCoroutine(GoToMainScreen());
                }
            }
        }
        coin_text.GetComponent<TextMeshProUGUI>().text = "Coins " + gamemanager.GetComponent<GameManager>().coins;
    }

    IEnumerator ShowClearText()
    {
        float half_height = Screen.height / 2;
        float half_width = Screen.width / 2;
        int speed = 30;

        while (clear_text.GetComponent<RectTransform>().position.y >= half_height)
        {
            clear_text.GetComponent<RectTransform>().position = new Vector2(half_width, clear_text.GetComponent<RectTransform>().position.y - speed);
            yield return new WaitForSeconds(0.02f);
        }

        show_text_end = true;
    }

    IEnumerator GoToMainScreen()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("MainScreen");
    }
}
