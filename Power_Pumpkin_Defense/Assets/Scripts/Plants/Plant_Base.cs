using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Base : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void TakeDamage(float d)
    {
        Debug.Log("Plant Base class TakeDamage()");
    }

    public virtual void GainHealth(float d)
    {
        Debug.Log("Plant Base class Gain health()");
    }

    public virtual void Water_Plant(int w)
    {
        Debug.Log("Plant Base class water plant()");
    }

    public virtual void Modify_AttackSpeed(float modifier)
    {
        Debug.Log("Plant Base class modify attack speed()");
    }

    public virtual void Modify_DamageDone(float modifier, float time)
    {
        Debug.Log("Plant Base class modify damage done()");
    }

    public void Assign_Lane(int L)
    {
        Lane_Num = L;
    }

    public void Assign_Plant_Pot(GameObject P)
    {
        My_Plant_Pot = P;
    }

    // Water / Level
    [SerializeField] protected int Water_To_Upgrade_Level;  
    [SerializeField] protected bool isMaxLevel;
    [SerializeField] protected int Flower_Level;

    // Plant variables
    [SerializeField] protected float Plant_Health;
    [SerializeField] protected float Plant_Damage;
    [SerializeField] protected float Plant_Attack_Cooldown;

    [SerializeField] protected GameObject Plant_Next_Lvl;

    protected GameObject My_Plant_Pot;

    protected int Lane_Num;

    protected bool CanAttack;
    protected int Water_Level;
}
