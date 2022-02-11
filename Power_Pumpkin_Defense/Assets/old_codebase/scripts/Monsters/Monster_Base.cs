using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Base : MonoBehaviour
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
        Debug.Log("Monster Base class TakeDamage()");
    }

    public virtual void GainHealth(float h)
    {
        Debug.Log("Monster Base class Gain health()");
    }

    public virtual void Modify_AttackSpeed(float modifier, float time)
    {
        Debug.Log("Monster Base class modify attack speed()");
    }

    public virtual void Modify_MoveSpeed(float modifier, float time)
    {
        Debug.Log("Monster Base class modify move speed()");
    }

    public virtual void Modify_DamageDone(float modifier, float time)
    {
        Debug.Log("Monster Base class modify damage done()");
    }

    public virtual void Take_DamageOverTime(float d, float time)
    {
        Debug.Log("Monster Base class take damage over time()");
    }

    public virtual void Gain_HealthOverTime(float h, float time)
    {
        Debug.Log("Monster Base class gain health over time()");
    }

    public virtual void Assign_Lane_Number(int L_num)
    {
        Debug.Log("Monster Base class assign lane number");
        //Lane_Num = L_num;
    }

    // Movement - Important
    [SerializeField] protected Vector3 ToVector;
    [SerializeField]protected Vector3 TargetPos;

    [SerializeField] protected List<Transform> Path;
    [SerializeField]protected int CurrentPoint;

    // Monster variables
    [SerializeField] protected float Monster_Speed;

    [SerializeField] protected float Monster_Health;

    [SerializeField] protected float Monster_Damage;

    [SerializeField] protected float Monster_Attack_Cooldown;

    protected int Lane_Num;

    protected bool CanAttack;

    protected bool MoveSpeed_Modified;
    protected bool AttackSpeed_Modified;
    protected bool DamageDone_Modified;
    protected bool DoT_Active;
    protected bool HoT_Active;
}
