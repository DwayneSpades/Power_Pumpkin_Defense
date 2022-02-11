using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_Menu_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Select_Level_Button.GetComponent<Button>().onClick.AddListener(Click_Select_Level);
        Controls_Menu_Button.GetComponent<Button>().onClick.AddListener(Click_Open_Controls_Menu);
        Exit_Game_Button.GetComponent<Button>().onClick.AddListener(Click_Exit_Game);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Click_Select_Level()
    {
        Select_Level_Menu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    void Click_Open_Controls_Menu()
    {
        Controls_Menu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    void Click_Exit_Game()
    {
        Application.Quit();
    }

    [SerializeField] private Button Select_Level_Button;
    [SerializeField] private Button Controls_Menu_Button;
    [SerializeField] private Button Exit_Game_Button;

    [SerializeField] private GameObject Select_Level_Menu;
    [SerializeField] private GameObject Controls_Menu;
}
