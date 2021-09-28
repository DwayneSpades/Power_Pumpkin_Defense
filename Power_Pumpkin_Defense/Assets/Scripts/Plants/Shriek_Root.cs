using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shriek_Root : Plant_Base
{
    // Start is called before the first frame update
    void Start()
    {
        Plant_Mngr = GameObject.Find("Plant_Manager");

        CanAttack = true;
        Water_Level = 0;
        Shriek_Root_Health_Current = Plant_Health;
        Shriek_Root_Damage_Current = Plant_Damage;
        Shriek_Root_Attack_Cooldown_Current = Plant_Attack_Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Water_Plant(int Water_Amount)
    {
        Debug.Log("Gave water to shriek root: " + Water_Amount);
        Water_Level += Water_Amount;

        if (isMaxLevel == false)
        {
            if (Water_Level >= Water_To_Upgrade_Level)
            {
                StopAllCoroutines();

                // Instantiate the next level plant
                GameObject P;
                P = Instantiate(Plant_Next_Lvl, transform.position, transform.rotation);

                // Set new plants plant pot - pass this one's plant pot gameobject
                P.gameObject.GetComponent<Plant_Base>().Assign_Plant_Pot(My_Plant_Pot);
                Plant_Mngr.GetComponent<Plant_Manager>().Add_ActivePlant(P, Lane_Num);
                Plant_Mngr.GetComponent<Plant_Manager>().Add_ActiveShriekRoot(P);

                Debug.Log("Shriek Root upgraded to level " + (Flower_Level + 1));

                // Delete this plant
                Plant_Mngr.GetComponent<Plant_Manager>().Remove_ActivePlant(this.gameObject, Lane_Num);
                Plant_Mngr.GetComponent<Plant_Manager>().Remove_ActiveShriekRoot(this.gameObject);

                Destroy(this.gameObject);
            }
        }
        else
        {
            Debug.Log("Shriek root is max level");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CanAttack)
        {
            if (other.tag == "Monster")
            {
                CanAttack = false;

                //Debug.Log("Shriek Root Attacked Ghast");
                other.gameObject.GetComponent<Monster_Base>().Modify_MoveSpeed(Shriek_Root_Attack_Slow_Modifier, Shriek_Root_Attack_Slow_Duration);
                other.gameObject.GetComponent<Monster_Base>().TakeDamage(Shriek_Root_Damage_Current);

                StartCoroutine(Attack_Cooldown());
            }
        }
    }

    public override void TakeDamage(float d)
    {
        Shriek_Root_Health_Current -= d;

        if (Shriek_Root_Health_Current <= 0)
        {
            StopAllCoroutines();

            My_Plant_Pot.GetComponent<Plant_Pot>().UpdatePlantStatus_Dead();
            Plant_Mngr.GetComponent<Plant_Manager>().Remove_ActivePlant(this.gameObject, Lane_Num);
            Plant_Mngr.GetComponent<Plant_Manager>().Remove_ActiveShriekRoot(this.gameObject);

            Destroy(this.gameObject);
        }
    }

    IEnumerator Attack_Cooldown()
    {
        yield return new WaitForSeconds(Shriek_Root_Attack_Cooldown_Current);

        CanAttack = true;
    }

    private GameObject Plant_Mngr;

    // Punch Cactus variables
    private float Shriek_Root_Health_Current;
    private float Shriek_Root_Damage_Current;
    private float Shriek_Root_Attack_Cooldown_Current;

    [SerializeField] private float Shriek_Root_Attack_Slow_Modifier;
    [SerializeField] private float Shriek_Root_Attack_Slow_Duration;
}
