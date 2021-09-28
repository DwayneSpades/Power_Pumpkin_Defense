using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Lane_Mngr = GameObject.Find("Lane_Manager");

        PlantPot_List = new List<GameObject>();
        Active_Plants = new List<GameObject>();
        Active_PunchCacti = new List<GameObject>();
        Active_ShriekRoots = new List<GameObject>();
        Active_FireFlowers = new List<GameObject>();

        //foreach (Transform t in PlantPot_Positions)
        //{
        //    GameObject Pot;
        //    Pot = Instantiate(PlantPot, t.position, t.rotation);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Get list
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

    [SerializeField] private List<GameObject> PlantPot_List;

    [SerializeField] private List<GameObject> Active_Plants;
    [SerializeField] private List<GameObject> Active_PunchCacti;
    [SerializeField] private List<GameObject> Active_ShriekRoots;
    [SerializeField] private List<GameObject> Active_FireFlowers;

    public GameObject PlantPot;
}
