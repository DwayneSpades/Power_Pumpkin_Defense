using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Flower : Plant_Base
{
    // Start is called before the first frame update
    void Start()
    {
        Plant_Mngr = GameObject.Find("Plant_Manager");

        CanAttack = true;
        Water_Level = 0;
        Fire_Flower_Health_Current = Plant_Health;
        Fire_Flower_Damage_Current = Plant_Damage;
        Fire_Flower_Attack_Cooldown_Current = Plant_Attack_Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Water_Plant(int Water_Amount)
    {
  
        //Debug.Log("Gave water to fire flower: " + Water_Amount);
        Water_Level += Water_Amount;

        if (Water_Level >= Water_To_Upgrade_Level)
        {
            StopAllCoroutines();

            // Instantiate the next level plant
            GameObject P;
            P = Instantiate(Plant_Next_Lvl, transform.position, transform.rotation);

            // Set new plants plant pot - pass this one's plant pot gameobject
            P.gameObject.GetComponent<Plant_Base>().Assign_Plant_Pot(My_Plant_Pot);
            Plant_Mngr.GetComponent<Plant_Manager>().Add_ActivePlant(P, Lane_Num);
            Plant_Mngr.GetComponent<Plant_Manager>().Add_ActiveFireFlower(P);

            //Debug.Log("Fire flower upgraded to level " + (Flower_Level + 1));

            // Delete this plant
            Plant_Mngr.GetComponent<Plant_Manager>().Remove_ActivePlant(this.gameObject, Lane_Num);
            Plant_Mngr.GetComponent<Plant_Manager>().Remove_ActiveFireFlower(this.gameObject);

            Destroy(this.gameObject);
        }
  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CanAttack)
        {
            if (other.tag == "Monster")
            {
                CanAttack = false;

                //Debug.Log("Fire Flower Attacked Ghast");
                other.gameObject.GetComponent<Monster_Base>().Take_DamageOverTime(Fire_Flower_DoT_DPS, Fire_Flower_DoT_Duration);
                other.gameObject.GetComponent<Monster_Base>().TakeDamage(Fire_Flower_Damage_Current);

                StartCoroutine(Attack_Cooldown());
            }
        }
    }

    public override void TakeDamage(float d)
    {
        Fire_Flower_Health_Current -= d;

        if (Fire_Flower_Health_Current <= 0)
        {
            StopAllCoroutines();

            My_Plant_Pot.GetComponent<Plant_Pot>().UpdatePlantStatus_Dead();
            Plant_Mngr.GetComponent<Plant_Manager>().Remove_ActivePlant(this.gameObject, Lane_Num);
            Plant_Mngr.GetComponent<Plant_Manager>().Remove_ActiveFireFlower(this.gameObject);

            Destroy(this.gameObject);
        }
    }

    public override void GainHealth(float h)
    {
        Fire_Flower_Health_Current += h;
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
            //Debug.Log("Attack speed is currently modified - Fire Flower");
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
            //Debug.Log("Damage is currently modified - Fire Flower");
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
            //Debug.Log("DoT is active - Fire Flower");
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
            //Debug.Log("HoT is active - Fire Flower");
        }
    }

    IEnumerator Attack_Cooldown()
    {
        yield return new WaitForSeconds(Fire_Flower_Attack_Cooldown_Current);

        CanAttack = true;
    }

    IEnumerator Temp_Change_AttackSpeed(float modifier, float time)
    {
        //Debug.Log("Fire Flower current attack cd: " + Fire_Flower_Attack_Cooldown_Current);

        Fire_Flower_Attack_Cooldown_Current *= modifier;
        //Debug.Log("Temporary Fire Flower current attack cd: " + Fire_Flower_Attack_Cooldown_Current);

        yield return new WaitForSeconds(time);

        Fire_Flower_Attack_Cooldown_Current = Plant_Attack_Cooldown;
        //Debug.Log("Effect done - Fire Flower current attack cd: " + Fire_Flower_Attack_Cooldown_Current);
        AttackSpeed_Modified = false;
    }

    IEnumerator Temp_Change_DamageDone(float modifier, float time)
    {
        Fire_Flower_Damage_Current *= modifier;

        yield return new WaitForSeconds(time);

        Fire_Flower_Damage_Current = Plant_Damage;
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

    // Plant variables
    private float Fire_Flower_Health_Current;
    private float Fire_Flower_Damage_Current;
    private float Fire_Flower_Attack_Cooldown_Current;

    [SerializeField] private float Fire_Flower_DoT_DPS;
    [SerializeField] private float Fire_Flower_DoT_Duration;
}
