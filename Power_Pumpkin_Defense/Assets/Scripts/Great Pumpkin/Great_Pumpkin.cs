using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Great_Pumpkin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GreatPumpkin_CurrentHealth = GreatPumpkin_Health;

        Wave_Mngr = GameObject.Find("Wave_Manager");
        UI_Mngr = GameObject.Find("UI_Manager");
        //UI_Mngr.GetComponent<UI_Manager>().Update_Max_GreatPumpkinHealth(GreatPumpkin_Health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float dmg)
    {
        GreatPumpkin_CurrentHealth -= dmg;
        //UI_Mngr.GetComponent<UI_Manager>().Update_Current_GreatPumpkinHealth(GreatPumpkin_CurrentHealth);

        //Debug.Log("Great Pumpkin Health: " + GreatPumpkin_CurrentHealth);

        if (GreatPumpkin_CurrentHealth <= 0)
        {
            Debug.Log("Great Pumpkin Destroyed. Game Over");
            Wave_Mngr.GetComponent<Wave_Manager>().GreatPumpkin_Dead();
            Wave_Mngr.GetComponent<Wave_Manager>().Clean_Up_Wave();

            Destroy(gameObject);
        }
    }

    [SerializeField] private float GreatPumpkin_Health;
    private float GreatPumpkin_CurrentHealth;

    private GameObject Wave_Mngr;
    private GameObject UI_Mngr;
}
