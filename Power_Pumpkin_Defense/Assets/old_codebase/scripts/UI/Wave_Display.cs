using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wave_Display : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Current_Wave_Number = 0;
        Wave_Num_Display.text = "Wave: " + Current_Wave_Number;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Update_Display_Current_Wave(int wave)
    {
        Current_Wave_Number = wave;
        Wave_Num_Display.text = "Wave: " + Current_Wave_Number;
    }

    [SerializeField] private Text Wave_Num_Display;

    private int Current_Wave_Number;
}
