using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch_Cactus : Plant_Base
{
    // Start is called before the first frame update
    void Start()
    {
        Plant_Mngr = GameObject.Find("Plant_Manager");

        CanAttack = true;
        Water_Level = 0;
        Punch_Cactus_Health_Current = Plant_Health;
        Punch_Cactus_Damage_Current = Plant_Damage;
        Punch_Cactus_Attack_Cooldown_Current = Plant_Attack_Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Water_Plant(int Water_Amount)
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
                P = Instantiate(Plant_Next_Lvl, transform.position, transform.rotation);

                // Set new plants plant pot - pass this one's plant pot gameobject
                P.gameObject.GetComponent<Plant_Base>().Assign_Plant_Pot(My_Plant_Pot);
                Plant_Mngr.GetComponent<Plant_Manager>().Add_ActivePlant(P, Lane_Num);
                Plant_Mngr.GetComponent<Plant_Manager>().Add_ActivePunchCactus(P);

                Debug.Log("Punch Cactus upgraded to level " + (Flower_Level + 1));

                // Delete this plant
                Plant_Mngr.GetComponent<Plant_Manager>().Remove_ActivePlant(this.gameObject, Lane_Num);
                Plant_Mngr.GetComponent<Plant_Manager>().Remove_ActivePunchCactus(this.gameObject);

                Destroy(this.gameObject);
            }
        }
        else
        {
            Debug.Log("Punch cactus is max level");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CanAttack)
        {
            if (other.tag == "Monster")
            {
                CanAttack = false;

                //Debug.Log("Punch Cactus Attacked Ghast");
                other.gameObject.GetComponent<Monster_Base>().TakeDamage(Punch_Cactus_Damage_Current);

                StartCoroutine(Attack_Cooldown());
            }
        }
    }

    public override void TakeDamage(float d)
    {
        Punch_Cactus_Health_Current -= d;

        if (Punch_Cactus_Health_Current <= 0)
        {
            StopAllCoroutines();

            My_Plant_Pot.GetComponent<Plant_Pot>().UpdatePlantStatus_Dead();
            Plant_Mngr.GetComponent<Plant_Manager>().Remove_ActivePlant(this.gameObject, Lane_Num);
            Plant_Mngr.GetComponent<Plant_Manager>().Remove_ActivePunchCactus(this.gameObject);

            Destroy(this.gameObject);
        }
    }

    public override void GainHealth(float h)
    {
        Punch_Cactus_Health_Current += h;
    }

    public override void Modify_AttackSpeed(float modifier, float time)
    {
        if (!AttackSpeed_Modified)
        {
            AttackSpeed_Modified = true;
            StartCoroutine(Temp_Change_AttackSpeed(modifier, time));
        }
        else
        {
            Debug.Log("Attack speed is currently modified - Punch Cactus");
        }
    }

    public override void Modify_DamageDone(float modifier, float time)
    {
        if (!DamageDone_Modified)
        {
            DamageDone_Modified = true;
            StartCoroutine(Temp_Change_DamageDone(modifier, time));
        }
        else
        {
            Debug.Log("Damage is currently modified - Punch Cactus");
        }
    }

    public override void Take_DamageOverTime(float d, float time)
    {
        if (!DoT_Active)
        {
            DoT_Active = true;
            StartCoroutine(Take_Damage_Over_Time(d, time));
        }
        else
        {
            Debug.Log("DoT is active - Punch Cactus");
        }
    }

    public override void Gain_HealthOverTime(float h, float time)
    {
        if (!HoT_Active)
        {
            HoT_Active = true;
            StartCoroutine(Gain_Health_Over_Time(h, time));
        }
        else
        {
            Debug.Log("HoT is active - Punch Cactus");
        }
    }

    IEnumerator Attack_Cooldown()
    {
        yield return new WaitForSeconds(Punch_Cactus_Attack_Cooldown_Current);

        CanAttack = true;
    }

    IEnumerator Temp_Change_AttackSpeed(float modifier, float time)
    {
        Debug.Log("Punch Cactus current attack cd: " + Punch_Cactus_Attack_Cooldown_Current);

        Punch_Cactus_Attack_Cooldown_Current *= modifier;
        Debug.Log("Temporary Punch Cactus current attack cd: " + Punch_Cactus_Attack_Cooldown_Current);

        yield return new WaitForSeconds(time);

        Punch_Cactus_Attack_Cooldown_Current = Plant_Attack_Cooldown;
        Debug.Log("Effect done - Punch Cactus current attack cd: " + Punch_Cactus_Attack_Cooldown_Current);
        AttackSpeed_Modified = false;
    }

    IEnumerator Temp_Change_DamageDone(float modifier, float time)
    {
        Punch_Cactus_Damage_Current *= modifier;

        yield return new WaitForSeconds(time);

        Punch_Cactus_Damage_Current = Plant_Damage;
        DamageDone_Modified = false;
    }

    IEnumerator Take_Damage_Over_Time(float d, float time)
    {
        TakeDamage(d);

        yield return new WaitForSeconds(1);

        if (time - 1 > 0)
        {
            StartCoroutine(Take_Damage_Over_Time(d, time - 1));
        }
        else
        {
            DoT_Active = false;
        }
    }

    IEnumerator Gain_Health_Over_Time(float h, float time)
    {
        GainHealth(h);

        yield return new WaitForSeconds(1);

        if (time - 1 > 0)
        {
            StartCoroutine(Gain_Health_Over_Time(h, time - 1));
        }
        else
        {
            HoT_Active = false;
        }
    }

    private GameObject Plant_Mngr;

    // Punch Cactus variables
    private float Punch_Cactus_Health_Current;
    private float Punch_Cactus_Damage_Current;
    private float Punch_Cactus_Attack_Cooldown_Current;
}
