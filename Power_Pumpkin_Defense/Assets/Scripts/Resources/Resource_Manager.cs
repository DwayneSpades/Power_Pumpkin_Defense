using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UI_Mngr = GameObject.Find("UI_Manager");
        m_CanWater = true;
        m_CanPlant_FireFlower = true;
        m_CanPlant_PunchCactus = true;
        m_CanPlant_ShriekRoot = true;

        m_Current_Water_Amount = m_Starting_Water_Amount;
        m_Current_Mana_Amount = m_Starting_Mana_Amount;

        UI_Mngr.GetComponent<UI_Manager>().Update_Max_Mana(m_Max_Mana_Amount);
        UI_Mngr.GetComponent<UI_Manager>().Update_Max_Water(m_Max_Water_Amount);

        UI_Mngr.GetComponent<UI_Manager>().Update_Current_Mana(m_Current_Mana_Amount);
        UI_Mngr.GetComponent<UI_Manager>().Update_Current_Water(m_Current_Water_Amount);
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
            UI_Mngr.GetComponent<UI_Manager>().Update_Current_Water(m_Current_Water_Amount);
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
            if (F.tag == "Plant")
            {
                m_CanWater = false;
                UI_Mngr.GetComponent<UI_Manager>().Update_WaterReady_Icon_Status(false);
                StartCoroutine(Watering_Cooldown());
                F.gameObject.GetComponent<Plant_Base>().Water_Plant(m_Water_To_Give_Plant);
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
            UI_Mngr.GetComponent<UI_Manager>().Update_Current_Water(m_Current_Water_Amount);
            Debug.Log("Used Water, Water Left: " + m_Current_Water_Amount);
        }
    }

    IEnumerator Watering_Cooldown()
    {
        yield return new WaitForSeconds(m_Water_Cooldown_Time);

        Debug.Log("Can Water Again");
        m_CanWater = true;
        UI_Mngr.GetComponent<UI_Manager>().Update_WaterReady_Icon_Status(true);
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
        UI_Mngr.GetComponent<UI_Manager>().Update_Current_Mana(m_Current_Mana_Amount);

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
        UI_Mngr.GetComponent<UI_Manager>().Update_Current_Mana(m_Current_Mana_Amount);

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

    public int Get_Punch_Cactus_Mana_Cost()
    {
        return m_Mana_Cost_PunchCactus;
    }

    public int Get_Fire_Flower_Mana_Cost()
    {
        return m_Mana_Cost_FireFlower;
    }

    public int Get_Shriek_Root_Mana_Cost()
    {
        return m_Mana_Cost_ShriekRoot;
    }

    // Get Resource Amounts
    public int Get_Current_Mana()
    {
        return m_Current_Mana_Amount;
    }

    public int Get_Current_Water()
    {
        return m_Current_Water_Amount;
    }

    [SerializeField] private int m_Starting_Water_Amount;
    [SerializeField] private int m_Max_Water_Amount;
    private int m_Current_Water_Amount;

    [SerializeField] private int m_Starting_Mana_Amount;
    [SerializeField] private int m_Max_Mana_Amount;
    private int m_Current_Mana_Amount;

    // Generic number for water given to all plants
    [SerializeField] private int m_Water_To_Give_Plant;

    [SerializeField] private float m_Water_Cooldown_Time;
    private bool m_CanWater;

    [SerializeField] private int m_Mana_Cost_PunchCactus;
    [SerializeField] private int m_Mana_Cost_FireFlower;
    [SerializeField] private int m_Mana_Cost_ShriekRoot;

    private bool m_CanPlant_PunchCactus;
    private bool m_CanPlant_FireFlower;
    private bool m_CanPlant_ShriekRoot;

    private GameObject UI_Mngr;
}
