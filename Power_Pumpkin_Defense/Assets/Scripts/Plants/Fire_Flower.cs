using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Flower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Plant_Mngr = GameObject.Find("Plant_Manager");

        CanAttack = true;
        Water_Level = 0;
        Fire_Flower_Health_Current = Fire_Flower_Health;
        Fire_Flower_Damage_Current = Fire_Flower_Damage;
        Fire_Flower_Attack_Cooldown_Current = Fire_Flower_Attack_Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Water_Fire_Flower(int Water_Amount)
    {
        Debug.Log("Gave water to fire flower: " + Water_Amount);
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
        yield return new WaitForSeconds(Fire_Flower_Attack_Cooldown_Current);

        CanAttack = true;
    }

    private GameObject Plant_Mngr;

    public GameObject Fire_Flower_Next_Lvl;

    private GameObject My_Plant_Pot;

    // Punch Cactus variables
    public float Fire_Flower_Health;
    private float Fire_Flower_Health_Current;

    public float Fire_Flower_Damage;
    private float Fire_Flower_Damage_Current;

    public float Fire_Flower_Attack_Cooldown;
    private float Fire_Flower_Attack_Cooldown_Current;

    private bool CanAttack;

    private int Water_Level;

    public int Water_To_Upgrade_Level;
    public bool isMaxLevel;
}
