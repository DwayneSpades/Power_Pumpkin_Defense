using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{

    public Animator animControl;
    public GameObject model;
    // Start is called before the first frame update
    void Start()
    {
        CanWater = true;
        isFlowerNear = false;

        Current_Move_Speed = Move_Speed;
        Current_Water_Amount = Starting_Water_Amount;
    }

    // Update is called once per frame
    void Update()
    {
        float X_Direction = Input.GetAxis("Horizontal");
        float Z_Direction = Input.GetAxis("Vertical");

        Vector3 Move_Dir = new Vector3(X_Direction, 0.0f, Z_Direction);
        Move_Dir.Normalize();

        model.transform.forward = Move_Dir;
        if (Move_Dir.x != 0 || Move_Dir.z != 0)
        {
            animControl.Play("run");
        }
        else
        {
            animControl.Play("idle");
        }
        transform.position += Move_Dir * Move_Speed * Time.deltaTime;


        if (isFlowerNear && Nearby_Flower)
        {
            if (Input.GetKeyDown(KeyCode.Z) && CanWater)
            {
                if (Nearby_Flower.tag == "Punch_Cactus")
                {
                    if (Current_Water_Amount > 0)
                    {
                        // Play Animation

                        // Water Stuff
                        CanWater = false;
                        StartCoroutine(Watering_Cooldown());
                        Nearby_Flower.gameObject.GetComponent<Punch_Cactus>().Water_Punch_Cactus(Water_To_Give_Plant);
                        Use_Water(Water_To_Give_Plant);
                    }
                    else
                    {
                        Debug.Log("Not enough Water");
                    }
                }

                if (Nearby_Flower.tag == "Fire_Flower")
                {
                    if (Current_Water_Amount > 0)
                    {
                        // Play Animation

                        // Water Stuff
                        CanWater = false;
                        StartCoroutine(Watering_Cooldown());
                        Nearby_Flower.gameObject.GetComponent<Fire_Flower>().Water_Fire_Flower(Water_To_Give_Plant);
                        Use_Water(Water_To_Give_Plant);
                    }
                    else
                    {
                        Debug.Log("Not enough Water");
                    }
                }

                if (Nearby_Flower.tag == "Shriek_Root")
                {
                    if (Current_Water_Amount > 0)
                    {
                        // Play Animation

                        // Water Stuff
                        CanWater = false;
                        StartCoroutine(Watering_Cooldown());
                        Nearby_Flower.gameObject.GetComponent<Shriek_Root>().Water_Shriek_Root(Water_To_Give_Plant);
                        Use_Water(Water_To_Give_Plant);
                    }
                    else
                    {
                        Debug.Log("Not enough Water");
                    }
                }
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

    public void Refill_Water()
    {
        if (Current_Water_Amount < Max_Water_Amount)
        {
            Current_Water_Amount = Max_Water_Amount;
            Debug.Log("Watering can refilled: " + Current_Water_Amount);
        }
        else
        {
            Debug.Log("Watering can is full");
        }
    }

    private void Use_Water(int w_amount)
    {
        if (Current_Water_Amount >= 0)
        {
            Current_Water_Amount -= w_amount;
            Debug.Log("Used Water, Water Left: " + Current_Water_Amount);
        }
    }

    IEnumerator Watering_Cooldown()
    {
        yield return new WaitForSeconds(Water_Cooldown_Time);

        Debug.Log("Can Water Again");
        CanWater = true;
    }

    public int Starting_Water_Amount;
    public int Max_Water_Amount;
    private int Current_Water_Amount;

    public float Move_Speed;
    private float Current_Move_Speed;

    // Generic number for water given to all plants
    public int Water_To_Give_Plant;

    public float Water_Cooldown_Time;
    private bool CanWater;

    private bool isFlowerNear;
    private GameObject Nearby_Flower;
}
