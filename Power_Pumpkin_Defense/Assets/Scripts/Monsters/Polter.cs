﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polter : Monster_Base
{
    // Start is called before the first frame update
    void Start()
    {
        CurrentPoint = 0;
        Polter_Speed_Current = Monster_Speed;
        Polter_Damage_Current = Monster_Damage;
        Polter_Health_Current = Monster_Health;
        Polter_Attack_Cooldown_Current = Monster_Attack_Cooldown;

        MoveSpeed_Modified = false;
        AttackSpeed_Modified = false;
        DamageDone_Modified = false;
        DoT_Active = false;
        HoT_Active = false;

        CanAttack = true;

        Lane_Mngr = GameObject.Find("Lane_Manager");
        Monster_Mngr = GameObject.Find("Monster_Manager");
        Resource_Mngr = GameObject.Find("Resource_Manager");

        Path = Lane_Mngr.GetComponent<Lane_Manager>().GetPath(this.gameObject, transform.position);

        //Debug.Log("Path size: " + Path.Count);

        TargetPos = Path[CurrentPoint].position;
        ToVector = TargetPos - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentPoint < Path.Count)
        {
            transform.position += ToVector * Polter_Speed_Current * Time.deltaTime;

            //Debug.Log("Current point: " + CurrentPoint);
        }

    }

    void UpdateTargetPos()
    {
        TargetPos = Path[CurrentPoint].position;
        ToVector = TargetPos - transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Lane_Obj")
        {
            CurrentPoint++;
            UpdateTargetPos();
        }

        if (other.tag == "Great_Pumpkin")
        {
            StopAllCoroutines();

            //Debug.Log("Polter Reached Great Pumpkin");
            other.gameObject.GetComponent<Great_Pumpkin>().TakeDamage(Polter_Damage_Current);
            Monster_Mngr.gameObject.GetComponent<Monster_Manager>().Remove_ActiveMonster(this.gameObject, Lane_Num);
            Monster_Mngr.gameObject.GetComponent<Monster_Manager>().Remove_ActivePolter(this.gameObject);

            Destroy(this.gameObject);
        }

        if (CanAttack)
        {
            if (other.tag == "Plant")
            {
                CanAttack = false;

                //Debug.Log("Polter Attacked Punch Cactus");
                other.gameObject.GetComponent<Plant_Base>().TakeDamage(Polter_Damage_Current);

                StartCoroutine(Attack_Cooldown());
            }
        }
    }

    public override void Assign_Lane_Number(int L_num)
    {
        Lane_Num = L_num;
        Lane_Mngr.GetComponent<Lane_Manager>().Add_Monster_To_Lane(this.gameObject, Lane_Num);
    }

    public override void TakeDamage(float d)
    {
        Polter_Health_Current -= d;

        if (Polter_Health_Current <= 0)
        {
            StopAllCoroutines();

            //Resource_Mngr.GetComponent<Resource_Manager>().Spawn_Mana_Sphere(transform, ManaSphere);

            Monster_Mngr.gameObject.GetComponent<Monster_Manager>().Remove_ActiveMonster(this.gameObject, Lane_Num);
            Monster_Mngr.gameObject.GetComponent<Monster_Manager>().Remove_ActivePolter(this.gameObject);

            Destroy(this.gameObject);
        }
    }

    public override void GainHealth(float h)
    {
        Polter_Health_Current += h;
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
            Debug.Log("Attack speed is currently modified - Polter");
        }
    }

    public override void Modify_MoveSpeed(float modifier, float time)
    {
        if (!MoveSpeed_Modified)
        {
            MoveSpeed_Modified = true;
            StartCoroutine(Temp_Change_MoveSpeed(modifier, time));
        }
        else
        {
            Debug.Log("Move speed is currently modified - Polter");
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
            Debug.Log("Damage is currently modified - Polter");
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
            Debug.Log("DoT is active - Polter");
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
            Debug.Log("HoT is active - Polter");
        }
    }

    IEnumerator Attack_Cooldown()
    {
        yield return new WaitForSeconds(Polter_Attack_Cooldown_Current);

        CanAttack = true;
    }

    IEnumerator Temp_Change_AttackSpeed(float modifier, float time)
    {
        Debug.Log("Ghast current attack cd: " + Polter_Attack_Cooldown_Current);

        Polter_Attack_Cooldown_Current *= modifier;
        Debug.Log("Temporary Ghast current attack cd: " + Polter_Attack_Cooldown_Current);

        yield return new WaitForSeconds(time);

        Polter_Attack_Cooldown_Current = Monster_Attack_Cooldown;
        Debug.Log("Effect done - Ghast current attack cd: " + Polter_Attack_Cooldown_Current);
        AttackSpeed_Modified = false;
    }

    IEnumerator Temp_Change_MoveSpeed(float modifier, float time)
    {
        Polter_Speed_Current *= modifier;

        yield return new WaitForSeconds(time);

        Polter_Speed_Current = Monster_Speed;
        MoveSpeed_Modified = false;
    }

    IEnumerator Temp_Change_DamageDone(float modifier, float time)
    {
        Polter_Damage_Current *= modifier;

        yield return new WaitForSeconds(time);

        Polter_Damage_Current = Monster_Damage;
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

    // Internal Functionality stuff
    private GameObject Lane_Mngr;
    private GameObject Monster_Mngr;
    private GameObject Resource_Mngr;

    public GameObject ManaSphere;

    // Polter variables
    private float Polter_Speed_Current;

    private float Polter_Health_Current;

    private float Polter_Damage_Current;

    private float Polter_Attack_Cooldown_Current;
}
