using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Select_Level_Menu_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Select_Level_1_Button.GetComponent<Button>().onClick.AddListener(Click_Select_Level_1);
        Select_Level_2_Button.GetComponent<Button>().onClick.AddListener(Click_Select_Level_2);
        To_Main_Menu_Button.GetComponent<Button>().onClick.AddListener(Click_To_Main_Menu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Click_Select_Level_1()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void Click_Select_Level_2()
    {
        //SceneManager.LoadScene("SampleScene");
    }

    void Click_To_Main_Menu()
    {
        Main_Menu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    [SerializeField] private Button Select_Level_1_Button;
    [SerializeField] private Button Select_Level_2_Button;

    [SerializeField] private Button To_Main_Menu_Button;

    [SerializeField] private GameObject Main_Menu;
}
