﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghast : Monster_Base
{
    // Start is called before the first frame update
    void Start()
    {
        CurrentPoint = 0;
        Ghast_Speed_Current = Monster_Speed;
        Ghast_Damage_Current = Monster_Damage;
        Ghast_Health_Current = Monster_Health;
        Ghast_Attack_Cooldown_Current = Monster_Attack_Cooldown;

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
            transform.position += ToVector * Ghast_Speed_Current * Time.deltaTime;

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

            //Debug.Log("Ghast Reached Great Pumpkin");
            other.gameObject.GetComponent<Great_Pumpkin>().TakeDamage(Ghast_Damage_Current);
            Monster_Mngr.gameObject.GetComponent<Monster_Manager>().Remove_ActiveMonster(this.gameObject, Lane_Num);
            Monster_Mngr.gameObject.GetComponent<Monster_Manager>().Remove_ActiveGhast(this.gameObject);

            Destroy(this.gameObject);
        }

        if (CanAttack)
        {
            if (other.tag == "Plant")
            {
                CanAttack = false;

                //Debug.Log("Ghast Attacked Punch Cactus");
                other.gameObject.GetComponent<Plant_Base>().TakeDamage(Ghast_Damage_Current);

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
        Ghast_Health_Current -= d;

        if (Ghast_Health_Current <= 0)
        {
            StopAllCoroutines();

            Resource_Mngr.GetComponent<Resource_Manager>().Spawn_Mana_Sphere(transform, ManaSphere);

            Monster_Mngr.gameObject.GetComponent<Monster_Manager>().Remove_ActiveMonster(this.gameObject, Lane_Num);
            Monster_Mngr.gameObject.GetComponent<Monster_Manager>().Remove_ActiveGhast(this.gameObject);

            Destroy(this.gameObject);
        }
    }

    public override void GainHealth(float h)
    {
        Ghast_Health_Current += h;
    }

    public override void Modify_AttackSpeed(float modifier, float time)
    {
        StartCoroutine(Temp_Change_AttackSpeed(modifier, time));
    }

    public override void Modify_MoveSpeed(float modifier, float time)
    {
        StartCoroutine(Temp_Change_MoveSpeed(modifier, time));
    }

    public override void Modify_DamageDone(float modifier, float time)
    {
        StartCoroutine(Temp_Change_DamageDone(modifier, time));
    }

    IEnumerator Attack_Cooldown()
    {
        yield return new WaitForSeconds(Ghast_Attack_Cooldown_Current);

        CanAttack = true;
    }

    IEnumerator Temp_Change_AttackSpeed(float modifier, float time)
    {
        Debug.Log("Ghast current attack cd: " + Ghast_Attack_Cooldown_Current);

        Ghast_Attack_Cooldown_Current *= modifier;
        Debug.Log("Temporary Ghast current attack cd: " + Ghast_Attack_Cooldown_Current);

        yield return new WaitForSeconds(time);

        Ghast_Attack_Cooldown_Current = Monster_Attack_Cooldown;
        Debug.Log("Effect done - Ghast current attack cd: " + Ghast_Attack_Cooldown_Current);
    }

    IEnumerator Temp_Change_MoveSpeed(float modifier, float time)
    {
        Debug.Log("Ghast move speed: " + Ghast_Speed_Current);

        Ghast_Speed_Current *= modifier;
        Debug.Log("Temporary Ghast move speed: " + Ghast_Speed_Current);

        yield return new WaitForSeconds(time);

        Ghast_Speed_Current = Monster_Speed;
        Debug.Log("Effect done - Ghast move speed: " + Ghast_Speed_Current);
    }

    IEnumerator Temp_Change_DamageDone(float modifier, float time)
    {
        Ghast_Damage_Current *= modifier;

        yield return new WaitForSeconds(time);

        Ghast_Damage_Current = Monster_Damage;
    }

    // Internal Functionality stuff
    private GameObject Lane_Mngr;
    private GameObject Monster_Mngr;
    private GameObject Resource_Mngr;

    public GameObject ManaSphere;

    // Ghast variables
    private float Ghast_Attack_Cooldown_Current;
    private float Ghast_Damage_Current;
    private float Ghast_Health_Current;
    private float Ghast_Speed_Current;
}
