using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CurrentPoint = 0;
        LnMngr = GameObject.Find("Lane_Manager");
        Wave_Mngr = GameObject.Find("Wave_Manager");
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
            transform.position += ToVector * Ghast_Speed * Time.deltaTime;

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
            Debug.Log("Ghast Reached Great Pumpkin");
            other.gameObject.GetComponent<Great_Pumpkin>().TakeDamage(Ghast_Damage);
            Wave_Mngr.gameObject.GetComponent<Wave_Manager>().Remove_ActiveMonster(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    // Internal Functionality stuff
    private GameObject LnMngr;
    private GameObject Wave_Mngr;

    private Vector3 ToVector;
    private Vector3 TargetPos;

    private List<Transform> Path;
    private int CurrentPoint;

    // Ghast variables
    public float Ghast_Speed;
    public float Ghast_Health;
    public float Ghast_Damage;
}
