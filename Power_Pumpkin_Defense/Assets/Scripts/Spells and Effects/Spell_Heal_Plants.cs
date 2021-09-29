using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Heal_Plants : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Effect_Mngr = GameObject.Find("Effect_Manager");
    }

    // Update is called once per frame
    void Update()
    {
        Effect_Mngr.GetComponent<Effect_Manager>().Plants_Gain_Health(Spell_Heal_Amount);
    }

    private GameObject Effect_Mngr;

    [SerializeField] private float Spell_Heal_Amount;
}
