using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CurrentPoint = 0;
        Hexer_Speed_Current = Hexer_Speed;
        Hexer_Damage_Current = Hexer_Damage;
        Hexer_Health_Current = Hexer_Health;
        Hexer_Attack_Cooldown_Current = Hexer_Attack_Cooldown;

        CanAttack = true;

        LnMngr = GameObject.Find("Lane_Manager");
        Monster_Mngr = GameObject.Find("Monster_Manager");
        Plant_Mngr = GameObject.Find("Plant_Manager");
        Path = LnMngr.GetComponent<Lane_Manager>().GetAPath();

        //Debug.Log("Path size: " + Path.Count);

        TargetPos = Path[CurrentPoint].position;
        ToVector = TargetPos - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentPoint < Path.Count)
        {
            transform.position += ToVector * Hexer_Speed_Current * Time.deltaTime;

            //Debug.Log("Current point: " + CurrentPoint);
        }

        //if (Hexer_Health_Current < 1)
        //{
        //    Monster_Mngr.gameObject.GetComponent<Monster_Manager>().Remove_ActiveMonster(this.gameObject);
        //    Monster_Mngr.gameObject.GetComponent<Monster_Manager>().Remove_ActiveHexer(this.gameObject);
        //    Destroy(this.gameObject);
        //}

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

            if (CurrentPoint >= Path.Count)
            {
                CurrentPoint = 0;
            }

            UpdateTargetPos();
        }

        if (other.tag == "Great_Pumpkin")
        {
            StopAllCoroutines();

            //Debug.Log("Polter Reached Great Pumpkin");
            other.gameObject.GetComponent<Great_Pumpkin>().TakeDamage(Hexer_Damage_Current);
            Monster_Mngr.gameObject.GetComponent<Monster_Manager>().Remove_ActiveMonster(this.gameObject);
            Monster_Mngr.gameObject.GetComponent<Monster_Manager>().Remove_ActiveHexer(this.gameObject);
            Destroy(this.gameObject);
        }

        if (CanAttack)
        {
            if (other.tag == "Punch_Cactus")
            {
                CanAttack = false;

                //Debug.Log("Hexer Attacked Punch Cactus");
                other.gameObject.GetComponent<Punch_Cactus>().Punch_Cactus_TakeDamage(Hexer_Damage_Current);

                StartCoroutine(Attack_Cooldown());
            }
            else if (other.tag == "Fire_Flower")
            {
                CanAttack = false;

                //Debug.Log("Hexer Attacked Fire Flower");
                other.gameObject.GetComponent<Fire_Flower>().Fire_Flower_TakeDamage(Hexer_Damage_Current);

                StartCoroutine(Attack_Cooldown());
            }
            else if (other.tag == "Shriek_Root")
            {
                CanAttack = false;

                //Debug.Log("Hexer Attacked Shriek Root");
                other.gameObject.GetComponent<Shriek_Root>().Shriek_Root_TakeDamage(Hexer_Damage_Current);

                StartCoroutine(Attack_Cooldown());
            }
        }

    }

    public void Hexer_TakeDamage(float d)
    {
        Hexer_Health_Current -= d;

        if (Hexer_Health_Current <= 0)
        {
            StopAllCoroutines();

            Monster_Mngr.gameObject.GetComponent<Monster_Manager>().Remove_ActiveMonster(this.gameObject);
            Monster_Mngr.gameObject.GetComponent<Monster_Manager>().Remove_ActiveHexer(this.gameObject);

            Destroy(this.gameObject);
        }
    }

    IEnumerator Attack_Cooldown()
    {
        yield return new WaitForSeconds(Hexer_Attack_Cooldown_Current);

        CanAttack = true;
    }


    // Internal Functionality stuff
    private GameObject LnMngr;
    private GameObject Monster_Mngr;
    private GameObject Plant_Mngr;

    private Vector3 ToVector;
    private Vector3 TargetPos;

    private List<Transform> Path;
    private int CurrentPoint;

    // Hexer variables
    public float Hexer_Speed;
    private float Hexer_Speed_Current;

    public float Hexer_Health;
    private float Hexer_Health_Current;

    public float Hexer_Damage;
    private float Hexer_Damage_Current;

    public float Hexer_Attack_Cooldown;
    private float Hexer_Attack_Cooldown_Current;

    private bool CanAttack;
}
