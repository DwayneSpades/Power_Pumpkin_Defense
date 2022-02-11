using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Resource_Mngr = GameObject.Find("Resource_Manager");
        Spell_Mngr = GameObject.Find("Spell_Manager");
        Plant_Mngr = GameObject.Find("Plant_Manager");

        isFlowerNear = false;
        isPlantPotNear = false;

        Current_Move_Speed = Move_Speed;
    }

    // Update is called once per frame
    void Update()
    {
        float X_Direction = Input.GetAxis("Horizontal");
        float Z_Direction = Input.GetAxis("Vertical");

        Vector3 Move_Dir = new Vector3(X_Direction, 0.0f, Z_Direction);
        Move_Dir.Normalize();

        if (Move_Dir.x != 0 || Move_Dir.z != 0)
        {
            model.transform.forward = Move_Dir;
            animControl.Play("run");
        }
        else if(!Input.GetKey(KeyCode.Z))
        {
            animControl.Play("idle");
        }

        transform.position += Move_Dir * Move_Speed * Time.deltaTime;

        // Watering
        if (Input.GetKeyUp(KeyCode.Z))
        {
            if (isFlowerNear && Nearby_Flower && Resource_Mngr.GetComponent<Resource_Manager>().Can_Water()) // Can take out nearby_flower check, prob dont need but will leave it for now
            {
                animControl.Play("water");

                Resource_Mngr.GetComponent<Resource_Manager>().Water_Flower(Nearby_Flower);
            }
        }

        // Cycle through available spells
        if (Input.GetKeyUp(KeyCode.C))
        {
            Spell_Mngr.GetComponent<Spell_Manager>().Cycle_Spell();
        }

        // Use selected spell
        if (Input.GetKeyUp(KeyCode.X))
        {
            Spell_Mngr.GetComponent<Spell_Manager>().Use_Selected_Spell();
        }

        // Cycle through available plants
        if (Input.GetKeyUp(KeyCode.R))
        {
            Plant_Mngr.GetComponent<Plant_Manager>().Cycle_Plant();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (isPlantPotNear && Nearby_Plant_Pot)
            {
                Nearby_Plant_Pot.GetComponent<Plant_Pot>().Grow_Plant();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plant")
        {
            isFlowerNear = true;
            Nearby_Flower = other.gameObject;
        }
        else if (other.tag == "Plant_Pot")
        {
            isPlantPotNear = true;
            Nearby_Plant_Pot = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Plant")
        {
            isFlowerNear = false;
            Nearby_Flower = null;
        }
        else if (other.tag == "Plant_Pot")
        {
            isPlantPotNear = false;
            Nearby_Plant_Pot = null;
        }
    }

    public Animator animControl;
    public GameObject model;

    private GameObject Resource_Mngr;
    private GameObject Spell_Mngr;
    private GameObject Plant_Mngr;

    public float Move_Speed;
    private float Current_Move_Speed;

    private bool isFlowerNear;
    private GameObject Nearby_Flower;

    private bool isPlantPotNear;
    private GameObject Nearby_Plant_Pot;
}
