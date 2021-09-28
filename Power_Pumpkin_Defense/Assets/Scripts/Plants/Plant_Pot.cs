using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Pot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Plant_Mngr = GameObject.Find("Plant_Manager");
        Resource_Mngr = GameObject.Find("Resource_Manager");
        Active_Plant = false;
        isPlayer_Near = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Active_Plant && isPlayer_Near)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Resource_Mngr.GetComponent<Resource_Manager>().Can_Plant_Punch_Cactus())
                {
                    Spawn_Punch_Cactus();
                }
                else
                {
                    Debug.Log("Not enough mana to plant punch cactus");
                }
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                if (Resource_Mngr.GetComponent<Resource_Manager>().Can_Plant_Shriek_Root())
                {
                    Spawn_Shriek_Root();
                }
                else
                {
                    Debug.Log("Not enough mana to plant shriek root");
                }
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                if (Resource_Mngr.GetComponent<Resource_Manager>().Can_Plant_Fire_Flower())
                {
                    Spawn_Fire_Flower();
                }
                else
                {
                    Debug.Log("Not enough mana to plant fire flower");
                }
            }
        }
    }

    public void UpdatePlantStatus_Dead()
    {
        Active_Plant = false;
        Current_Active_Plant = null;
    }

    private void Spawn_Punch_Cactus()
    {
        Active_Plant = true;
        //Debug.Log("Spawned Punch Cactus");

        // Instantiate plant
        Vector3 tmp = transform.position;
        tmp.y += 0.5f;
        tmp.x -= 0.35f;
        GameObject P = Instantiate(PunchCactus, tmp, transform.rotation);

        Resource_Mngr.GetComponent<Resource_Manager>().UseMana(Resource_Mngr.GetComponent<Resource_Manager>().Get_Punch_Cactus_Mana_Cost());

        Current_Active_Plant = P;
        P.GetComponent<Plant_Base>().Assign_Plant_Pot(this.gameObject);
        P.GetComponent<Plant_Base>().Assign_Lane(Lane_Num);

        // Tell plant manager
        Plant_Mngr.GetComponent<Plant_Manager>().Add_ActivePlant(P, Lane_Num);
        Plant_Mngr.GetComponent<Plant_Manager>().Add_ActivePunchCactus(P);
    }

    private void Spawn_Shriek_Root()
    {
        Active_Plant = true;
        //Debug.Log("Spawned Shriek Root");

        // Instantiate plant
        Vector3 tmp = transform.position;
        tmp.y += 0.5f;
        tmp.x -= 0.25f;
        GameObject P = Instantiate(ShriekRoot, tmp, transform.rotation);

        Resource_Mngr.GetComponent<Resource_Manager>().UseMana(Resource_Mngr.GetComponent<Resource_Manager>().Get_Shriek_Root_Mana_Cost());

        Current_Active_Plant = P;
        P.GetComponent<Plant_Base>().Assign_Plant_Pot(this.gameObject);
        P.GetComponent<Plant_Base>().Assign_Lane(Lane_Num);

        // Tell plant manager
        Plant_Mngr.GetComponent<Plant_Manager>().Add_ActivePlant(P, Lane_Num);
        Plant_Mngr.GetComponent<Plant_Manager>().Add_ActiveShriekRoot(P);
    }

    private void Spawn_Fire_Flower()
    {
        Active_Plant = true;
        //Debug.Log("Spawned Fire Flower");

        // Instantiate plant
        Vector3 tmp = transform.position;
        tmp.y += 0.5f;
        tmp.x -= 0.1f;
        GameObject P = Instantiate(FireFlower, tmp, transform.rotation);

        Resource_Mngr.GetComponent<Resource_Manager>().UseMana(Resource_Mngr.GetComponent<Resource_Manager>().Get_Fire_Flower_Mana_Cost());

        Current_Active_Plant = P;
        P.GetComponent<Plant_Base>().Assign_Plant_Pot(this.gameObject);
        P.GetComponent<Plant_Base>().Assign_Lane(Lane_Num);

        // Tell plant manager
        Plant_Mngr.GetComponent<Plant_Manager>().Add_ActivePlant(P, Lane_Num);
        Plant_Mngr.GetComponent<Plant_Manager>().Add_ActiveFireFlower(P);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayer_Near = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayer_Near = false;
        }
    }

    private GameObject Plant_Mngr;
    private GameObject Resource_Mngr;

    [SerializeField] private GameObject FireFlower;
    [SerializeField] private GameObject ShriekRoot;
    [SerializeField] private GameObject PunchCactus;

    private GameObject Current_Active_Plant;
    private bool Active_Plant;

    private bool isPlayer_Near;

    [SerializeField] private int Lane_Num;
}
