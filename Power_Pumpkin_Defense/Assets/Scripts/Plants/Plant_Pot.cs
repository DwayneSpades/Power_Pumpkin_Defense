using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Pot : MonoBehaviour
{

    //public bool menuVisible = false;
    public GameObject menu_ui;
    public playerControl playerRef;

    // Start is called before the first frame update
    void Start()
    {
        Plant_Mngr = GameObject.Find("Plant_Manager");
        Resource_Mngr = GameObject.Find("Resource_Manager");
        Active_Plant = false;
        menu_ui.SetActive(false);
        playerRef = FindObjectOfType<playerControl>();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            menu_ui.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            menu_ui.SetActive(false);
        }
    }

    
    public void Grow_Plant()
    {
        if (!Active_Plant)
        {
            //GameObject plant = Plant_Mngr.GetComponent<Plant_Manager>().Get_Selected_Plant();

            if (playerRef.currentPlant == playerControl.selectedPlant.punchCactus)
            {
                Spawn_Punch_Cactus();
            }
            else if (playerRef.currentPlant == playerControl.selectedPlant.fireFlower)
            {            
               Spawn_Fire_Flower();          
            }
            else
            {
                Spawn_Shriek_Root();          
            }
        }
        else
        {
            Debug.Log("Plant has an active plant");
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

        //Resource_Mngr.GetComponent<Resource_Manager>().UseMana(Resource_Mngr.GetComponent<Resource_Manager>().Get_Punch_Cactus_Mana_Cost());

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

        //Resource_Mngr.GetComponent<Resource_Manager>().UseMana(Resource_Mngr.GetComponent<Resource_Manager>().Get_Shriek_Root_Mana_Cost());

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

        //Resource_Mngr.GetComponent<Resource_Manager>().UseMana(Resource_Mngr.GetComponent<Resource_Manager>().Get_Fire_Flower_Mana_Cost());

        Current_Active_Plant = P;
        P.GetComponent<Plant_Base>().Assign_Plant_Pot(this.gameObject);
        P.GetComponent<Plant_Base>().Assign_Lane(Lane_Num);

        // Tell plant manager
        Plant_Mngr.GetComponent<Plant_Manager>().Add_ActivePlant(P, Lane_Num);
        Plant_Mngr.GetComponent<Plant_Manager>().Add_ActiveFireFlower(P);
    }

    private GameObject Plant_Mngr;
    private GameObject Resource_Mngr;

    [SerializeField] private GameObject FireFlower;
    [SerializeField] private GameObject ShriekRoot;
    [SerializeField] private GameObject PunchCactus;

    private GameObject Current_Active_Plant;
    private bool Active_Plant;

    [SerializeField] private int Lane_Num;
}
