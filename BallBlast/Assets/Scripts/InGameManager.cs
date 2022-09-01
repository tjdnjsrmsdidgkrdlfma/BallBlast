using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    GameObject create_ball;

    void Awake()
    {
        create_ball = GameObject.Find("CreateBall");
    }

    void Update()
    {
        if (create_ball.GetComponent<CreateBall>().create_ball_ended == true)
        {
            if (GameObject.Find("Ball(Clone)") == null)
            {
                Debug.Log("round clear");
                SceneManager.LoadScene("MainScreen");
            }
        }
    }
}
