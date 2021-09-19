using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CurrentPoint = 0;
        Polter_Speed_Current = Polter_Speed;
        Polter_Damage_Current = Polter_Damage;
        Polter_Health_Current = Polter_Health;
        Polter_Attack_Cooldown_Current = Polter_Attack_Cooldown;

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
            //Debug.Log("Polter Reached Great Pumpkin");
            other.gameObject.GetComponent<Great_Pumpkin>().TakeDamage(Polter_Damage_Current);
            Monster_Mngr.gameObject.GetComponent<Monster_Manager>().Remove_ActiveMonster(this.gameObject);
            Monster_Mngr.gameObject.GetComponent<Monster_Manager>().Remove_ActivePolter(this.gameObject);
            Destroy(this.gameObject);
        }

        if (CanAttack)
        {

        }
    }

    IEnumerator Attack_Cooldown()
    {
        yield return new WaitForSeconds(Polter_Attack_Cooldown_Current);

        CanAttack = true;
    }

    // Internal Functionality stuff
    private GameObject LnMngr;
    private GameObject Monster_Mngr;

    private Vector3 ToVector;
    private Vector3 TargetPos;

    private List<Transform> Path;
    private int CurrentPoint;

    // Polter variables
    public float Polter_Speed;
    private float Polter_Speed_Current;

    public float Polter_Health;
    private float Polter_Health_Current;

    public float Polter_Damage;
    private float Polter_Damage_Current;

    public float Polter_Attack_Cooldown;
    private float Polter_Attack_Cooldown_Current;

    private bool CanAttack;
}
