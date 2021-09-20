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
                StopAllCoroutines();

                // Instantiate the next level plant
                GameObject P;
                P = Instantiate(Fire_Flower_Next_Lvl, transform.position, transform.rotation);

                // Set new plants plant pot - pass this one's plant pot gameobject
                P.gameObject.GetComponent<Fire_Flower>().Assign_Plant_Pot(My_Plant_Pot);
                Plant_Mngr.GetComponent<Plant_Manager>().Add_ActivePlant(P);
                Plant_Mngr.GetComponent<Plant_Manager>().Add_ActiveFireFlower(P);

                Debug.Log("Fire flower upgraded to level " + (Flower_Level + 1));

                // Delete this plant
                Plant_Mngr.GetComponent<Plant_Manager>().Remove_ActivePlant(this.gameObject);
                Plant_Mngr.GetComponent<Plant_Manager>().Remove_ActiveFireFlower(this.gameObject);

                Destroy(this.gameObject);
            }
        }
        else
        {
            Debug.Log("Fire flower is max level");
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

                //Debug.Log("Fire Flower Attacked Ghast");
                other.gameObject.GetComponent<Ghast>().Ghast_TakeDamage(Fire_Flower_Damage_Current);

                StartCoroutine(Attack_Cooldown());
            }
            else if (other.tag == "Polter")
            {
                CanAttack = false;

                //Debug.Log("Fire Flower Attacked Polter");
                other.gameObject.GetComponent<Polter>().Polter_TakeDamage(Fire_Flower_Damage_Current);

                StartCoroutine(Attack_Cooldown());
            }
            else if (other.tag == "Hexer")
            {
                CanAttack = false;

                //Debug.Log("Fire Flower Attacked Hexer");
                other.gameObject.GetComponent<Hexer>().Hexer_TakeDamage(Fire_Flower_Damage_Current);

                StartCoroutine(Attack_Cooldown());
            }
        }
    }

    public void Fire_Flower_TakeDamage(float d)
    {
        Fire_Flower_Health_Current -= d;

        if (Fire_Flower_Health_Current <= 0)
        {
            StopAllCoroutines();

            My_Plant_Pot.GetComponent<Plant_Pot>().UpdatePlantStatus_Dead();
            Plant_Mngr.GetComponent<Plant_Manager>().Remove_ActivePlant(this.gameObject);
            Plant_Mngr.GetComponent<Plant_Manager>().Remove_ActiveFireFlower(this.gameObject);

            Destroy(this.gameObject);
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
    public int Flower_Level;
}
