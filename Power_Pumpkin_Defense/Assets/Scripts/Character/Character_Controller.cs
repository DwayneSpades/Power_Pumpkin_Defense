using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Resource_Mngr = GameObject.Find("Resource_Manager");

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


        if (Input.GetKey(KeyCode.Z) )
        {
            if (isFlowerNear && Nearby_Flower && Resource_Mngr.GetComponent<Resource_Manager>().Can_Water()) // Can take out nearby_flower check, prob dont need but will leave it for now
            {
                animControl.Play("water");

                Resource_Mngr.GetComponent<Resource_Manager>().Water_Flower(Nearby_Flower);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Punch_Cactus")
        {
            isFlowerNear = true;
            Nearby_Flower = other.gameObject;
        }
        else if (other.tag == "Fire_Flower")
        {
            isFlowerNear = true;
            Nearby_Flower = other.gameObject;
        }
        else if (other.tag == "Shriek_Root")
        {
            isFlowerNear = true;
            Nearby_Flower = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Punch_Cactus")
        {
            isFlowerNear = false;
            Nearby_Flower = null;
        }
        else if (other.tag == "Fire_Flower")
        {
            isFlowerNear = false;
            Nearby_Flower = null;
        }
        else if (other.tag == "Shriek_Root")
        {
            isFlowerNear = false;
            Nearby_Flower = null;
        }
    }

    public Animator animControl;
    public GameObject model;

    private GameObject Resource_Mngr;

    public float Move_Speed;
    private float Current_Move_Speed;

    private bool isFlowerNear;
    private GameObject Nearby_Flower;
}
