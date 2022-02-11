using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Base : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Get_Spell_Mana_Cost()
    {
        return Spell_Mana_Cost;
    }

    [SerializeField] private int Spell_Mana_Cost;
}
