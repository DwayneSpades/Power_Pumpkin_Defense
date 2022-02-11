using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
    public static gameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void startGame()
    {

    }
    
    public void winGame()
    {
        SceneManager.LoadScene("win");

    }
    public void loseGame()
    {
        SceneManager.LoadScene("lose");

    }
    public void restartGame()
    {
        SceneManager.LoadScene("Get_Away");
    }
}
