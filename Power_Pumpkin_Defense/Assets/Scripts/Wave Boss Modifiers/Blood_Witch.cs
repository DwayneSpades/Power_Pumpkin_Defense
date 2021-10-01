using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood_Witch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Effect_Mngr = GameObject.Find("Effect_Manager");

        Blood_Witch_Lane = Random.Range(0, Available_Lane_Count);

        Effect_Mngr.GetComponent<Effect_Manager>().Plants_Take_Damage(Blood_Witch_DamageOverTime, Blood_Witch_DoT_Duration, Blood_Witch_Lane);  // (float d, float time, int Lane_Num)

        Effect_Mngr.GetComponent<Effect_Manager>().Monsters_Gain_Health(Blood_Witch_Monster_Heal_Amount, Blood_Witch_Lane);

        StartCoroutine(Time_To_Destroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Time_To_Destroy()
    {
        yield return new WaitForSeconds(5);

        Destroy(this.gameObject);
    }

    [SerializeField] private float Blood_Witch_DamageOverTime;
    [SerializeField] private float Blood_Witch_DoT_Duration;

    // Default value to indicate random? or selected by designer
    [SerializeField] private int Blood_Witch_Lane;
    [SerializeField] private int Available_Lane_Count;

    [SerializeField] private float Blood_Witch_Monster_Heal_Amount;

    private GameObject Effect_Mngr;
}
