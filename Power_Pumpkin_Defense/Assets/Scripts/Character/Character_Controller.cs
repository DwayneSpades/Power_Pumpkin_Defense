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

        isFlowerNear = false;

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
        if (Input.GetKey(KeyCode.Z) )
        {
            if (isFlowerNear && Nearby_Flower && Resource_Mngr.GetComponent<Resource_Manager>().Can_Water()) // Can take out nearby_flower check, prob dont need but will leave it for now
            {
                animControl.Play("water");

                Resource_Mngr.GetComponent<Resource_Manager>().Water_Flower(Nearby_Flower);
            }
        }

        // Cycle through available spells
        if (Input.GetKey(KeyCode.C))
        {
            Spell_Mngr.GetComponent<Spell_Manager>().Cycle_Spell();
        }

        // Use selected spell
        if (Input.GetKey(KeyCode.X))
        {
            Spell_Mngr.GetComponent<Spell_Manager>().Use_Selected_Spell();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plant")
        {
            isFlowerNear = true;
            Nearby_Flower = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Plant")
        {
            isFlowerNear = false;
            Nearby_Flower = null;
        }
    }

    public Animator animControl;
    public GameObject model;

    private GameObject Resource_Mngr;
    private GameObject Spell_Mngr;

    public float Move_Speed;
    private float Current_Move_Speed;

    private bool isFlowerNear;
    private GameObject Nearby_Flower;
}
