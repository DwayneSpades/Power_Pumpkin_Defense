using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Lane_Mngr = GameObject.Find("Lane_Manager");
        UI_Mngr = GameObject.Find("UI_Manager");
        CurrentPlant_Index = 0;
        Current_Selected_Plant = Available_Plant_List[CurrentPlant_Index];

        //PlantPot_List = new List<GameObject>();
        Active_Plants = new List<GameObject>();
        Active_PunchCacti = new List<GameObject>();
        Active_ShriekRoots = new List<GameObject>();
        Active_FireFlowers = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cycle_Plant()
    {
        if (CurrentPlant_Index >= (Available_Plant_List.Count - 1))
        {
            CurrentPlant_Index = 0;
        }
        else
        {
            CurrentPlant_Index++;
        }

        Current_Selected_Plant = Available_Plant_List[CurrentPlant_Index];
        UI_Mngr.GetComponent<UI_Manager>().Cycle_Plant_Icon();

        Debug.Log("Plant Cycled - Current Selected Plant: " + Current_Selected_Plant.name);
    }

    public GameObject Get_Selected_Plant()
    {
        return Current_Selected_Plant;
    }

    // Get list
    public List<GameObject> Get_Plant_List(GameObject P)
    {
        List<GameObject> Plant_List;

        if (P.name == "Punch_Cactus_L1")
        {
            Plant_List = Active_PunchCacti;
        }
        else if (P.name == "Fire_Flower_L1")
        {
            Plant_List = Active_FireFlowers;
        }
        else if (P.name == "Shriek_Root_Level_4")
        {
            Plant_List = Active_ShriekRoots;
        }
        else
        {
            Plant_List = null;
        }

        return Plant_List;
    }

    public List<GameObject> Get_Active_Plants()
    {
        return Active_Plants;
    }

    public List<GameObject> Get_Active_PunchCacti()
    {
        return Active_PunchCacti;
    }

    public List<GameObject> Get_Active_ShriekRoots()
    {
        return Active_ShriekRoots;
    }

    public List<GameObject> Get_Active_FireFlowers()
    {
        return Active_FireFlowers;
    }

    // Add functions
    public void Add_ActivePlant(GameObject P, int L_num)
    {
        Active_Plants.Add(P);
        Lane_Mngr.GetComponent<Lane_Manager>().Add_Plant_To_Lane(P, L_num);
    }

    public void Add_ActivePunchCactus(GameObject P)
    {
        Active_PunchCacti.Add(P);
    }

    public void Add_ActiveShriekRoot(GameObject P)
    {
        Active_ShriekRoots.Add(P);
    }

    public void Add_ActiveFireFlower(GameObject P)
    {
        Active_FireFlowers.Add(P);
    }

    // Remove functions
    public void Remove_ActivePlant(GameObject P, int L_num)
    {
        Active_Plants.Remove(P);
        Lane_Mngr.GetComponent<Lane_Manager>().Remove_Plant_In_Lane(P, L_num);
    }

    public void Remove_ActivePunchCactus(GameObject P)
    {
        Active_PunchCacti.Remove(P);
    }

    public void Remove_ActiveShriekRoot(GameObject P)
    {
        Active_ShriekRoots.Remove(P);
    }

    public void Remove_ActiveFireFlower(GameObject P)
    {
        Active_FireFlowers.Remove(P);
    }

    private GameObject Lane_Mngr;
    private GameObject UI_Mngr;

    //[SerializeField] private List<GameObject> PlantPot_List;

    [SerializeField] private List<GameObject> Active_Plants;
    [SerializeField] private List<GameObject> Active_PunchCacti;
    [SerializeField] private List<GameObject> Active_ShriekRoots;
    [SerializeField] private List<GameObject> Active_FireFlowers;

    private GameObject Current_Selected_Plant;
    [SerializeField] private List<GameObject> Available_Plant_List;
    private int CurrentPlant_Index;

    //[SerializeField] private GameObject PlantPot;
}
