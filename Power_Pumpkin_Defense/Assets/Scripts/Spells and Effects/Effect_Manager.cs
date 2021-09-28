using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Monster_Mngr = GameObject.Find("Monster_Manager");
        Plant_Mngr = GameObject.Find("Plant_Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Ghost gain/lose health
    // Ghost dmg
    // Ghost move speed
    // Ghost attack speed

    // Plant gain/lose health
    // Plant dmg
    // Plant attack speed

    // Stand by a lane hitbox to cast a spell on that lane?
    // Separate spell for each lane?

    private GameObject Monster_Mngr;
    private GameObject Plant_Mngr;
}
