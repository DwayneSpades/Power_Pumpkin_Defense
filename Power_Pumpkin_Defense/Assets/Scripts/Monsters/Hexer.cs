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
        Wave_Mngr = GameObject.Find("Wave_Manager");
        Path = LnMngr.GetComponent<Lane_Manager>().GetHexerPath();

        //Debug.Log("Path size: " + Path.Count);

        TargetPos = Path[CurrentPoint].position;
        ToVector = TargetPos - transform.position;

        StartCoroutine(Hexer_DeathTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentPoint < Path.Count)
        {
            transform.position += ToVector * Hexer_Speed_Current * Time.deltaTime;

            //Debug.Log("Current point: " + CurrentPoint);
        }

        if (Hexer_Health_Current < 1)
        {
            Wave_Mngr.gameObject.GetComponent<Wave_Manager>().Remove_ActiveMonster(this.gameObject);
            Wave_Mngr.gameObject.GetComponent<Wave_Manager>().Remove_ActiveHexer(this.gameObject);
            Destroy(this.gameObject);
        }

    }

    void UpdateTargetPos()
    {
        TargetPos = Path[CurrentPoint].position;
        ToVector = TargetPos - transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hexer_Lane_Obj")
        {
            CurrentPoint++;

            if (CurrentPoint >= Path.Count)
            {
                CurrentPoint = 0;
            }

            UpdateTargetPos();
        }

    }

    IEnumerator Attack_Cooldown()
    {
        yield return new WaitForSeconds(Hexer_Attack_Cooldown_Current);

        CanAttack = true;
    }

    // For testing purposes to make sure waves keep going
    IEnumerator Hexer_DeathTimer()
    {
        yield return new WaitForSeconds(10);

        Wave_Mngr.gameObject.GetComponent<Wave_Manager>().Remove_ActiveMonster(this.gameObject);
        Wave_Mngr.gameObject.GetComponent<Wave_Manager>().Remove_ActiveHexer(this.gameObject);
        Destroy(this.gameObject);
    }

    // Internal Functionality stuff
    private GameObject LnMngr;
    private GameObject Wave_Mngr;

    private Vector3 ToVector;
    private Vector3 TargetPos;

    private List<Transform> Path;
    private int CurrentPoint;

    // Polter variables
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
