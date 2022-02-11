using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGame_PauseMenu_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Restart_Level_Button.GetComponent<Button>().onClick.AddListener(Click_Restart_Level);
        Main_Menu_Button.GetComponent<Button>().onClick.AddListener(Click_Exit_Main_Menu);
        Exit_Game_Button.GetComponent<Button>().onClick.AddListener(Click_Exit_Game);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Click_Restart_Level()
    {
        UnPause_Game();
        SceneManager.LoadScene("SampleScene");
    }

    void Click_Exit_Main_Menu()
    {
        UnPause_Game();
        SceneManager.LoadScene("Main_Menu");
    }

    void Click_Exit_Game()
    {
        Application.Quit();
    }

    public void UnPause_Game()
    {
        Time.timeScale = 1;
    }

    [SerializeField] private Button Restart_Level_Button;
    [SerializeField] private Button Main_Menu_Button;
    [SerializeField] private Button Exit_Game_Button;
}
