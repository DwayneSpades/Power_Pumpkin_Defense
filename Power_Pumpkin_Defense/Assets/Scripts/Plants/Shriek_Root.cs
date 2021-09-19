using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shriek_Root : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Plant_Mngr = GameObject.Find("Plant_Manager");

        CanAttack = true;
        Water_Level = 0;
        Shriek_Root_Health_Current = Shriek_Root_Health;
        Shriek_Root_Damage_Current = Shriek_Root_Damage;
        Shriek_Root_Attack_Cooldown_Current = Shriek_Root_Attack_Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Water_Shriek_Root(int Water_Amount)
    {
        Debug.Log("Gave water to shriek root: " + Water_Amount);
        Water_Level += Water_Amount;

        if (isMaxLevel == false)
        {
            if (Water_Level >= Water_To_Upgrade_Level)
            {
                // Instantiate the next level plant
                // Set new plants plant pot - pass this one's plant pot gameobject

                // Delete this plant
                // Maybe stop coroutines
            }
        }
    }

    public void Assign_Plant_Pot(GameObject P)
    {
        My_Plant_Pot = P;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CanAttack)
        {
            if (other.tag == "Ghast")
            {
                CanAttack = false;



                StartCoroutine(Attack_Cooldown());
            }
            else if (other.tag == "Polter")
            {
                CanAttack = false;



                StartCoroutine(Attack_Cooldown());
            }
            else if (other.tag == "Hexer")
            {
                CanAttack = false;



                StartCoroutine(Attack_Cooldown());
            }
        }
    }

    IEnumerator Attack_Cooldown()
    {
        yield return new WaitForSeconds(Shriek_Root_Attack_Cooldown_Current);

        CanAttack = true;
    }

    private GameObject Plant_Mngr;

    public GameObject Shriek_Root_Next_Lvl;

    private GameObject My_Plant_Pot;

    // Punch Cactus variables
    public float Shriek_Root_Health;
    private float Shriek_Root_Health_Current;

    public float Shriek_Root_Damage;
    private float Shriek_Root_Damage_Current;

    public float Shriek_Root_Attack_Cooldown;
    private float Shriek_Root_Attack_Cooldown_Current;

    private bool CanAttack;

    private int Water_Level;

    public int Water_To_Upgrade_Level;
    public bool isMaxLevel;
}
