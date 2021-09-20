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
        Debug.Log("Gave water to punch cactus: " + Water_Amount);
        Water_Level += Water_Amount;

        if (isMaxLevel == false)
        {
            if (Water_Level >= Water_To_Upgrade_Level)
            {
                StopAllCoroutines();

                // Instantiate the next level plant
                GameObject P;
                P = Instantiate(Punch_Cactus_Next_Lvl, transform.position, transform.rotation);

                // Set new plants plant pot - pass this one's plant pot gameobject
                P.gameObject.GetComponent<Punch_Cactus>().Assign_Plant_Pot(My_Plant_Pot);
                Plant_Mngr.GetComponent<Plant_Manager>().Add_ActivePlant(P);
                Plant_Mngr.GetComponent<Plant_Manager>().Add_ActivePunchCactus(P);

                Debug.Log("Punch Cactus upgraded to level " + (Flower_Level + 1));

                // Delete this plant
                Plant_Mngr.GetComponent<Plant_Manager>().Remove_ActivePlant(this.gameObject);
                Plant_Mngr.GetComponent<Plant_Manager>().Remove_ActivePunchCactus(this.gameObject);

                Destroy(this.gameObject);
            }
        }
        else
        {
            Debug.Log("Punch cactus is max level");
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

                //Debug.Log("Punch Cactus Attacked Ghast");
                other.gameObject.GetComponent<Ghast>().Ghast_TakeDamage(Punch_Cactus_Damage_Current);

                StartCoroutine(Attack_Cooldown());
            }
            else if (other.tag == "Polter")
            {
                CanAttack = false;

                //Debug.Log("Punch Cactus Attacked Polter");
                other.gameObject.GetComponent<Polter>().Polter_TakeDamage(Punch_Cactus_Damage_Current);

                StartCoroutine(Attack_Cooldown());
            }
            else if (other.tag == "Hexer")
            {
                CanAttack = false;

                //Debug.Log("Punch Cactus Attacked Hexer");
                other.gameObject.GetComponent<Hexer>().Hexer_TakeDamage(Punch_Cactus_Damage_Current);

                StartCoroutine(Attack_Cooldown());
            }
        }
    }

    public void Punch_Cactus_TakeDamage(float d)
    {
        Punch_Cactus_Health_Current -= d;

        if (Punch_Cactus_Health_Current <= 0)
        {
            StopAllCoroutines();

            My_Plant_Pot.GetComponent<Plant_Pot>().UpdatePlantStatus_Dead();
            Plant_Mngr.GetComponent<Plant_Manager>().Remove_ActivePlant(this.gameObject);
            Plant_Mngr.GetComponent<Plant_Manager>().Remove_ActivePunchCactus(this.gameObject);

            Destroy(this.gameObject);
        }
    }

    IEnumerator Attack_Cooldown()
    {
        yield return new WaitForSeconds(Punch_Cactus_Attack_Cooldown_Current);

        CanAttack = true;
    }

    private GameObject Plant_Mngr;

    public GameObject Punch_Cactus_Next_Lvl;

    private GameObject My_Plant_Pot;

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
    public bool isMaxLevel;
    public int Flower_Level;
}
