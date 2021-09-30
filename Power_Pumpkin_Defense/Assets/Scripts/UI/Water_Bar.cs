using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water_Bar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Update_Water_Value(int w)
    {
        WaterBar.value = w;
    }

    public void Update_Max_Water_Value(int w)
    {
        WaterBar.maxValue = w;
    }

    [SerializeField] private Slider WaterBar;
}
