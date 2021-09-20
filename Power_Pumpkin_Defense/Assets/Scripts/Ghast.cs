using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CurrentPoint = 0;
        Ghast_Speed_Current = Ghast_Speed;
        Ghast_Damage_Current = Ghast_Damage;
        Ghast_Health_Current = Ghast_Health;
        Ghast_Attack_Cooldown_Current = Ghast_Attack_Cooldown;

        CanAttack = true;

        LnMngr = GameObject.Find("Lane_Manager");
        Monster_Mngr = GameObject.Find("Monster_Manager");
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
            Monster_Mngr.gameObject.GetComponent<Monster_Manager>().Remove_ActiveMonster(this.gameObject);
            Monster_Mngr.gameObject.GetComponent<Monster_Manager>().Remove_ActiveGhast(this.gameObject);
            Destroy(this.gameObject);
        }

        if (CanAttack)
        {
            if (other.tag == "Punch_Cactus")
            {
                CanAttack = false;

                //Debug.Log("Ghast Attacked Punch Cactus");
                other.gameObject.GetComponent<Punch_Cactus>().Punch_Cactus_TakeDamage(Ghast_Damage_Current);

                StartCoroutine(Attack_Cooldown());
            }
            else if (other.tag == "Fire_Flower")
            {
                CanAttack = false;

                //Debug.Log("Ghast Attacked Fire Flower");
                other.gameObject.GetComponent<Fire_Flower>().Fire_Flower_TakeDamage(Ghast_Damage_Current);

                StartCoroutine(Attack_Cooldown());
            }
            else if (other.tag == "Shriek_Root")
            {
                CanAttack = false;

                //Debug.Log("Ghast Attacked Shriek Root");
                other.gameObject.GetComponent<Shriek_Root>().Shriek_Root_TakeDamage(Ghast_Damage_Current);

                StartCoroutine(Attack_Cooldown());
            }
        }
    }

    public void Ghast_TakeDamage(float d)
    {
        Ghast_Health_Current -= d;

        if (Ghast_Health_Current <= 0)
        {
            StopAllCoroutines();

            Monster_Mngr.gameObject.GetComponent<Monster_Manager>().Remove_ActiveMonster(this.gameObject);
            Monster_Mngr.gameObject.GetComponent<Monster_Manager>().Remove_ActiveGhast(this.gameObject);

            Destroy(this.gameObject);
        }
    }

    IEnumerator Attack_Cooldown()
    {
        yield return new WaitForSeconds(Ghast_Attack_Cooldown_Current);

        CanAttack = true;
    }

    // Internal Functionality stuff
    private GameObject LnMngr;
    private GameObject Monster_Mngr;

    private Vector3 ToVector;
    private Vector3 TargetPos;

    private List<Transform> Path;
    private int CurrentPoint;

    // Ghast variables
    public float Ghast_Speed;
    private float Ghast_Speed_Current;

    public float Ghast_Health;
    private float Ghast_Health_Current;

    public float Ghast_Damage;
    private float Ghast_Damage_Current;

    public float Ghast_Attack_Cooldown;
    private float Ghast_Attack_Cooldown_Current;

    private bool CanAttack;
}
