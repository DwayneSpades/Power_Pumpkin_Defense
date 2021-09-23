using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        m_CanWater = true;
        m_CanPlant_FireFlower = true;
        m_CanPlant_PunchCactus = true;
        m_CanPlant_ShriekRoot = true;

        m_Current_Water_Amount = m_Starting_Water_Amount;
        m_Current_Mana_Amount = m_Starting_Mana_Amount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //
    // Watering Functions
    //

    public void Refill_Water()
    {
        if (m_Current_Water_Amount < m_Max_Water_Amount)
        {
            m_Current_Water_Amount = m_Max_Water_Amount;
            Debug.Log("Watering can refilled: " + m_Current_Water_Amount);
        }
        else
        {
            Debug.Log("Watering can is full");
        }
    }

    public void Water_Flower(GameObject F)
    {
        if (m_Current_Water_Amount > 0)
        {
            if (F.tag == "Punch_Cactus")
            {
                m_CanWater = false;
                StartCoroutine(Watering_Cooldown());
                F.gameObject.GetComponent<Punch_Cactus>().Water_Punch_Cactus(m_Water_To_Give_Plant);
                Use_Water(m_Water_To_Give_Plant);
            }
            else if (F.tag == "Fire_Flower")
            {
                m_CanWater = false;
                StartCoroutine(Watering_Cooldown());
                F.gameObject.GetComponent<Fire_Flower>().Water_Fire_Flower(m_Water_To_Give_Plant);
                Use_Water(m_Water_To_Give_Plant);
            }
            else if (F.tag == "Shriek_Root")
            {
                m_CanWater = false;
                StartCoroutine(Watering_Cooldown());
                F.gameObject.GetComponent<Shriek_Root>().Water_Shriek_Root(m_Water_To_Give_Plant);
                Use_Water(m_Water_To_Give_Plant);
            }
        }
        else
        {
            Debug.Log("Not enough Water");
        }
    }

    public bool Can_Water()
    {
        return m_CanWater;
    }

    private void Use_Water(int w_amount)
    {
        if (m_Current_Water_Amount >= 0)
        {
            m_Current_Water_Amount -= w_amount;
            Debug.Log("Used Water, Water Left: " + m_Current_Water_Amount);
        }
    }

    IEnumerator Watering_Cooldown()
    {
        yield return new WaitForSeconds(m_Water_Cooldown_Time);

        Debug.Log("Can Water Again");
        m_CanWater = true;
    }

    //
    // Mana Functions
    //

    public void Spawn_Mana_Sphere(Transform pos, GameObject MSphere)
    {
        GameObject M;
        M = Instantiate(MSphere, pos.position, pos.rotation);
    }

    public bool Can_Plant_Punch_Cactus()
    {
        return m_CanPlant_PunchCactus;
    }

    public bool Can_Plant_Fire_Flower()
    {
        return m_CanPlant_FireFlower;
    }

    public bool Can_Plant_Shriek_Root()
    {
        return m_CanPlant_ShriekRoot;
    }

    public void GainMana(int M)
    {
        m_Current_Mana_Amount += M;

        Debug.Log("Gained " + M + " Mana, Mana Left: " + m_Current_Mana_Amount);

        if (m_Current_Mana_Amount >= m_Mana_Cost_PunchCactus)
        {
            m_CanPlant_PunchCactus = true;
        }

        if (m_Current_Mana_Amount >= m_Mana_Cost_FireFlower)
        {
            m_CanPlant_FireFlower = true;
        }

        if (m_Current_Mana_Amount >= m_Mana_Cost_ShriekRoot)
        {
            m_CanPlant_ShriekRoot = true;
        }
    }

    public void UseMana(int M)
    {
        m_Current_Mana_Amount -= M;

        Debug.Log("Used " + M + " Mana, Mana Left: " + m_Current_Mana_Amount);

        if (m_Current_Mana_Amount < m_Mana_Cost_PunchCactus)
        {
            m_CanPlant_PunchCactus = false;
        }

        if (m_Current_Mana_Amount < m_Mana_Cost_FireFlower)
        {
            m_CanPlant_FireFlower = false;
        }

        if (m_Current_Mana_Amount < m_Mana_Cost_ShriekRoot)
        {
            m_CanPlant_ShriekRoot = false;
        }
    }

    public int m_Starting_Water_Amount;
    public int m_Max_Water_Amount;
    private int m_Current_Water_Amount;

    public int m_Starting_Mana_Amount;
    public int m_Max_Mana_Amount;
    private int m_Current_Mana_Amount;

    // Generic number for water given to all plants
    public int m_Water_To_Give_Plant;

    public float m_Water_Cooldown_Time;
    private bool m_CanWater;

    public int m_Mana_Cost_PunchCactus;
    public int m_Mana_Cost_FireFlower;
    public int m_Mana_Cost_ShriekRoot;

    private bool m_CanPlant_PunchCactus;
    private bool m_CanPlant_FireFlower;
    private bool m_CanPlant_ShriekRoot;
}
