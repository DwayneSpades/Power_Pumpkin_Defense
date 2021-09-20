using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Spigot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        isPlayer_Near = false;
        PlayerRef = GameObject.Find("Pumpkin_Witch");
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer_Near)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                PlayerRef.GetComponent<Character_Controller>().Refill_Water();
            }
        }
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

    private bool isPlayer_Near;
    private GameObject PlayerRef;
}

