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

    public override void GainHealth(float h)
    {
        Shriek_Root_Health_Current += h;
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
            Debug.Log("Attack speed is currently modified - Shriek Root");
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
            Debug.Log("Damage is currently modified - Shriek Root");
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
            Debug.Log("DoT is active - Shriek Root");
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
            Debug.Log("HoT is active - Shriek Root");
        }
    }

    IEnumerator Attack_Cooldown()
    {
        yield return new WaitForSeconds(Shriek_Root_Attack_Cooldown_Current);

        CanAttack = true;
    }

    IEnumerator Temp_Change_AttackSpeed(float modifier, float time)
    {
        Debug.Log("Shriek Root current attack cd: " + Shriek_Root_Attack_Cooldown_Current);

        Shriek_Root_Attack_Cooldown_Current *= modifier;
        Debug.Log("Temporary Shriek Root current attack cd: " + Shriek_Root_Attack_Cooldown_Current);

        yield return new WaitForSeconds(time);

        Shriek_Root_Attack_Cooldown_Current = Plant_Attack_Cooldown;
        Debug.Log("Effect done - Shriek Root current attack cd: " + Shriek_Root_Attack_Cooldown_Current);
        AttackSpeed_Modified = false;
    }

    IEnumerator Temp_Change_DamageDone(float modifier, float time)
    {
        Shriek_Root_Damage_Current *= modifier;

        yield return new WaitForSeconds(time);

        Shriek_Root_Damage_Current = Plant_Damage;
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
    private float Shriek_Root_Health_Current;
    private float Shriek_Root_Damage_Current;
    private float Shriek_Root_Attack_Cooldown_Current;

    [SerializeField] private float Shriek_Root_Attack_Slow_Modifier;
    [SerializeField] private float Shriek_Root_Attack_Slow_Duration;
}
