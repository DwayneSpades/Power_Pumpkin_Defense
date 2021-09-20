﻿using System.Collections;
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

        Instantiate(PlantPot, Pot_Spawn_Test.position, Pot_Spawn_Test.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void All_Plants_Hexer_Curse(float attk_mult)
    {

    }

    // Add functions
    public void Add_ActivePlant(GameObject P)
    {
        Active_Plants.Add(P);
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
    public void Remove_ActivePlant(GameObject P)
    {
        Active_Plants.Remove(P);
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

    public List<GameObject> PlantPot_List;

    [SerializeField] private List<GameObject> Active_Plants;
    [SerializeField] private List<GameObject> Active_PunchCacti;
    [SerializeField] private List<GameObject> Active_ShriekRoots;
    [SerializeField] private List<GameObject> Active_FireFlowers;

    public GameObject FireFlower_Lvl1;
    public GameObject FireFlower_Lvl2;
    public GameObject FireFlower_Lvl3;

    public GameObject ShriekRoot_Lvl1;
    public GameObject ShriekRoot_Lvl2;
    public GameObject ShriekRoot_Lvl3;

    public GameObject PunchCactus_Lvl1;
    public GameObject PunchCactus_Lvl2;
    public GameObject PunchCactus_Lvl3;

    public GameObject PlantPot;

    public Transform Pot_Spawn_Test;
}
