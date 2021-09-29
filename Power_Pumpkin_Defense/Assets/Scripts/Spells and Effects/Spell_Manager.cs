using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Resource_Mngr = GameObject.Find("Resource_Manager");
        CurrentSpell_Index = 0;
        Current_Selected_Spell = Spell_List[CurrentSpell_Index];

        Can_Use_Spell = true;
        //Current_Selected_Spell = Spell_List[CurrentSpell_Index];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Cycle_Spell()
    {
        if (CurrentSpell_Index >= (Spell_List.Count - 1))
        {
            CurrentSpell_Index = 0;
        }
        else
        {
            CurrentSpell_Index++;
        }

        Current_Selected_Spell = Spell_List[CurrentSpell_Index];

        Debug.Log("Spell Cycled - Current Selected Spell: " + Current_Selected_Spell.name);
    }

    public void Use_Selected_Spell()
    {
        if (Can_Use_Spell)
        {
            Can_Use_Spell = false;
            Instantiate(Current_Selected_Spell, transform.position, transform.rotation);
        }
        else
        {
            Debug.Log("Spells still on cooldown!");
        }

    }

    public bool Can_Cast_Spell()
    {
        return Can_Use_Spell;
    }

    IEnumerator Spell_Cooldown()
    {
        yield return new WaitForSeconds(Spell_Cooldown_Time);

        Can_Use_Spell = true;
    }

    private GameObject Resource_Mngr;

    private GameObject Current_Selected_Spell;

    public List<GameObject> Spell_List;
    private int CurrentSpell_Index;

    private bool Can_Use_Spell;
    public float Spell_Cooldown_Time;
}
