using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana_Bar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //ManaBar.value = 0;
        //ManaBar.maxValue = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Update_Mana_Value(int m)
    {
        ManaBar.value = m;
    }

    public void Update_Max_Mana_Value(int m)
    {
        ManaBar.maxValue = m;
    }

    [SerializeField] private Slider ManaBar;
}
