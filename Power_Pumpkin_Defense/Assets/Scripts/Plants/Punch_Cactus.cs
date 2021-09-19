using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch_Cactus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Plant_Mngr = GameObject.Find("Plant_Manager");

        CanAttack = true;
        Water_Level = 0;
        Punch_Cactus_Health_Current = Punch_Cactus_Health;
        Punch_Cactus_Damage_Current = Punch_Cactus_Damage;
        Punch_Cactus_Attack_Cooldown_Current = Punch_Cactus_Attack_Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Water_Punch_Cactus(int Water_Amount)
    {
        Water_Level += Water_Amount;

        if (Water_Level >= Water_To_Upgrade_Level)
        {
            // Instantiate the next level plant
            // Delete this plant
        }
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
        yield return new WaitForSeconds(Punch_Cactus_Attack_Cooldown_Current);

        CanAttack = true;
    }

    private GameObject Plant_Mngr;

    public GameObject Punch_Cactus_Next_Lvl;

    // Punch Cactus variables
    public float Punch_Cactus_Health;
    private float Punch_Cactus_Health_Current;

    public float Punch_Cactus_Damage;
    private float Punch_Cactus_Damage_Current;

    public float Punch_Cactus_Attack_Cooldown;
    private float Punch_Cactus_Attack_Cooldown_Current;

    private bool CanAttack;

    private int Water_Level;

    public int Water_To_Upgrade_Level;
}
