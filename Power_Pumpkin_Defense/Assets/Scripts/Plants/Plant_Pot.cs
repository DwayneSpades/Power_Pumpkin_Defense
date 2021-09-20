using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Pot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Plant_Mngr = GameObject.Find("Plant_Manager");
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
                Spawn_Punch_Cactus();
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                Spawn_Shriek_Root();
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                Spawn_Fire_Flower();
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

        Current_Active_Plant = P;
        P.GetComponent<Punch_Cactus>().Assign_Plant_Pot(this.gameObject);

        // Tell plant manager
        Plant_Mngr.GetComponent<Plant_Manager>().Add_ActivePlant(P);
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

        Current_Active_Plant = P;
        P.GetComponent<Shriek_Root>().Assign_Plant_Pot(this.gameObject);

        // Tell plant manager
        Plant_Mngr.GetComponent<Plant_Manager>().Add_ActivePlant(P);
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

        Current_Active_Plant = P;
        P.GetComponent<Fire_Flower>().Assign_Plant_Pot(this.gameObject);

        // Tell plant manager
        Plant_Mngr.GetComponent<Plant_Manager>().Add_ActivePlant(P);
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

    public GameObject FireFlower;
    public GameObject ShriekRoot;
    public GameObject PunchCactus;

    private GameObject Current_Active_Plant;
    private bool Active_Plant;

    private bool isPlayer_Near;
}
