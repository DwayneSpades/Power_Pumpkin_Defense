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

    public virtual void GainHealth(float d)
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

    public virtual void Assign_Lane_Number(int L_num)
    {
        Debug.Log("Monster Base class assign lane number");
        //Lane_Num = L_num;
    }

    // Movement - Important
    protected Vector3 ToVector;
    protected Vector3 TargetPos;

    protected List<Transform> Path;
    protected int CurrentPoint;

    // Monster variables
    public float Monster_Speed;

    public float Monster_Health;

    public float Monster_Damage;

    public float Monster_Attack_Cooldown;

    protected int Lane_Num;

    protected bool CanAttack;
}
