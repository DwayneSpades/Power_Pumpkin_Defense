using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Active_Plants = new List<GameObject>();
        Active_PunchCacti = new List<GameObject>();
        Active_ShriekRoots = new List<GameObject>();
        Active_FireFlowers = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Remove_ActivePlant(GameObject M)
    {
        Active_Plants.Remove(M);
    }

    public void Remove_ActivePunchCactus(GameObject M)
    {
        Active_PunchCacti.Remove(M);
    }

    public void Remove_ActiveShriekRoot(GameObject M)
    {
        Active_ShriekRoots.Remove(M);
    }

    public void Remove_ActiveFireFlower(GameObject M)
    {
        Active_FireFlowers.Remove(M);
    }

    public List<GameObject> PlantPot_List;

    [SerializeField] private List<GameObject> Active_Plants;
    [SerializeField] private List<GameObject> Active_PunchCacti;
    [SerializeField] private List<GameObject> Active_ShriekRoots;
    [SerializeField] private List<GameObject> Active_FireFlowers;

    public GameObject FireFlower;
    public GameObject ShriekRoot;
    public GameObject PunchCactus;
}
