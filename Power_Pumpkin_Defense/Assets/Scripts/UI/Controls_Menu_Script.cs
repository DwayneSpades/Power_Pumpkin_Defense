using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls_Menu_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        To_Main_Menu_Button.GetComponent<Button>().onClick.AddListener(Click_To_Main_Menu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Click_To_Main_Menu()
    {
        Main_Menu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    [SerializeField] private Button To_Main_Menu_Button;

    [SerializeField] private GameObject Main_Menu;
}
