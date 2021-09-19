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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float dmg)
    {
        GreatPumpkin_CurrentHealth -= dmg;

        //Debug.Log("Great Pumpkin Health: " + GreatPumpkin_CurrentHealth);

        if (GreatPumpkin_CurrentHealth <= 0)
        {
            Debug.Log("Great Pumpkin Destroyed. Game Over");
            Wave_Mngr.GetComponent<Wave_Manager>().GreatPumpkin_Dead();
            Wave_Mngr.GetComponent<Wave_Manager>().Clean_Up_Wave();

            Destroy(gameObject);
        }
    }

    public float GreatPumpkin_Health;
    private float GreatPumpkin_CurrentHealth;

    private GameObject Wave_Mngr;
}
