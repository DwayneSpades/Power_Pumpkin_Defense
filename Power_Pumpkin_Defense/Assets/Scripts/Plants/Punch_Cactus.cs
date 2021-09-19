using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch_Cactus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Plant_Mngr = GameObject.Find("Plant_Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject Plant_Mngr;
}
