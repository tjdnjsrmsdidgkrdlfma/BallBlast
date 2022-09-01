using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScript : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("MainScreen");
    }
}
