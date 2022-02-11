using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreatPumpkin_HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PumpkinHealthBar.value = PumpkinHealthBar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Update_Health_Value(float h)
    {
        PumpkinHealthBar.value = h;
    }

    public void Update_Max_Health_Value(float h)
    {
        PumpkinHealthBar.maxValue = h;
    }

    [SerializeField] private Slider PumpkinHealthBar;
}
