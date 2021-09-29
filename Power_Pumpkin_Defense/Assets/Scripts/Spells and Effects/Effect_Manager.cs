using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Monster_Mngr = GameObject.Find("Monster_Manager");
        Plant_Mngr = GameObject.Find("Plant_Manager");
        Lane_Mngr = GameObject.Find("Lane_Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //
    // MONSTERS
    //

    //
    // Monster TAKE DAMAGE Functions
    //

    // All monsters take damage, optional parameter for specific type of monster
    public void Monsters_Take_Damage(float d, GameObject M = null)
    {
        List<GameObject> Monsters;

        if (M != null)
        {
            Monsters = Monster_Mngr.GetComponent<Monster_Manager>().Get_Monster_List(M);
        }
        else
        {
            Monsters = Monster_Mngr.GetComponent<Monster_Manager>().Get_Active_Monsters();
        }

        foreach (GameObject Mx in Monsters)
        {
            Mx.GetComponent<Monster_Base>().TakeDamage(d);
        }
    }

    // All monsters in a specific lane take damage
    public void Monsters_Take_Damage(float d, int Lane_Num)
    {
        List<GameObject> Monsters;
        Monsters = Lane_Mngr.GetComponent<Lane_Manager>().Get_Lane_Monsters(Lane_Num);

        foreach (GameObject Mx in Monsters)
        {
            Mx.GetComponent<Monster_Base>().TakeDamage(d);
        }
    }

    // All monsters take damage over time, optional parameter for specific type of monster
    public void Monsters_Take_Damage(float d, float time, GameObject M = null)
    {
        List<GameObject> Monsters;

        if (M != null)
        {
            Monsters = Monster_Mngr.GetComponent<Monster_Manager>().Get_Monster_List(M);
        }
        else
        {
            Monsters = Monster_Mngr.GetComponent<Monster_Manager>().Get_Active_Monsters();
        }

        foreach (GameObject Mx in Monsters)
        {
            Mx.GetComponent<Monster_Base>().Take_DamageOverTime(d, time);
        }
    }

    // All monsters take damage over time in a specific lane
    public void Monsters_Take_Damage(float d, float time, int Lane_Num)
    {
        List<GameObject> Monsters;
        Monsters = Lane_Mngr.GetComponent<Lane_Manager>().Get_Lane_Monsters(Lane_Num);

        foreach (GameObject Mx in Monsters)
        {
            Mx.GetComponent<Monster_Base>().Take_DamageOverTime(d, time);
        }
    }

    //
    // Monster GAIN HEALTH Functions
    //

    // All monsters gain health, optional parameter for specific type of monster 
    public void Monsters_Gain_Health(float h, GameObject M = null)
    {
        List<GameObject> Monsters;

        if (M != null)
        {
            Monsters = Monster_Mngr.GetComponent<Monster_Manager>().Get_Monster_List(M);
        }
        else
        {
            Monsters = Monster_Mngr.GetComponent<Monster_Manager>().Get_Active_Monsters();
        }

        foreach (GameObject Mx in Monsters)
        {
            Mx.GetComponent<Monster_Base>().GainHealth(h);
        }
    }

    // All monsters in a specific lane gain health
    public void Monsters_Gain_Health(float h, int Lane_Num)
    {
        List<GameObject> Monsters;
        Monsters = Lane_Mngr.GetComponent<Lane_Manager>().Get_Lane_Monsters(Lane_Num);

        foreach (GameObject Mx in Monsters)
        {
            Mx.GetComponent<Monster_Base>().GainHealth(h);
        }
    }

    // All monsters gain health over time, optional parameter for specific type of monster
    public void Monsters_Gain_Health(float h, float time, GameObject M = null)
    {
        List<GameObject> Monsters;

        if (M != null)
        {
            Monsters = Monster_Mngr.GetComponent<Monster_Manager>().Get_Monster_List(M);
        }
        else
        {
            Monsters = Monster_Mngr.GetComponent<Monster_Manager>().Get_Active_Monsters();
        }

        foreach (GameObject Mx in Monsters)
        {
            Mx.GetComponent<Monster_Base>().Gain_HealthOverTime(h, time);
        }
    }

    // All monsters gain health over time in a specific lane
    public void Monsters_Gain_Health(float h, float time, int Lane_Num)
    {
        List<GameObject> Monsters;
        Monsters = Lane_Mngr.GetComponent<Lane_Manager>().Get_Lane_Monsters(Lane_Num);

        foreach (GameObject Mx in Monsters)
        {
            Mx.GetComponent<Monster_Base>().Gain_HealthOverTime(h, time);
        }
    }

    //
    // Monster Damage Done Functions
    //

    // All monsters damage modified 
    public void Monsters_Modify_Damage_Done(float mod, float time)
    {
        List<GameObject> Monsters;
        Monsters = Monster_Mngr.GetComponent<Monster_Manager>().Get_Active_Monsters();

        foreach (GameObject Mx in Monsters)
        {
            Mx.GetComponent<Monster_Base>().Modify_DamageDone(mod, time);
        }
    }

    // All monsters in a specific lane damage modified
    public void Monsters_Modify_Damage_Done(float mod, float time, int Lane_Num)
    {
        List<GameObject> Monsters;
        Monsters = Lane_Mngr.GetComponent<Lane_Manager>().Get_Lane_Monsters(Lane_Num);

        foreach (GameObject Mx in Monsters)
        {
            Mx.GetComponent<Monster_Base>().Modify_DamageDone(mod, time);
        }
    }

    // All monsters of a specific type damage modified
    public void Monsters_Modify_Damage_Done(float mod, float time, GameObject M)
    {
        List<GameObject> Monsters;

        if (M != null)
        {
            Monsters = Monster_Mngr.GetComponent<Monster_Manager>().Get_Monster_List(M);

            foreach (GameObject Mx in Monsters)
            {
                Mx.GetComponent<Monster_Base>().Modify_DamageDone(mod, time);
            }
        }
        else
        {
            Debug.Log("Monsters_Modify_Damage_Done - Game object parameter is null");
        }
    }

    //
    // Monster Move Speed Functions
    //

    // All monsters move speed modified 
    public void Monsters_Modify_Move_Speed(float mod, float time)
    {
        List<GameObject> Monsters;
        Monsters = Monster_Mngr.GetComponent<Monster_Manager>().Get_Active_Monsters();

        foreach (GameObject Mx in Monsters)
        {
            Mx.GetComponent<Monster_Base>().Modify_MoveSpeed(mod, time);
        }
    }

    // All monsters in a specific lane move speed modified
    public void Monsters_Modify_Move_Speed(float mod, float time, int Lane_Num)
    {
        List<GameObject> Monsters;
        Monsters = Lane_Mngr.GetComponent<Lane_Manager>().Get_Lane_Monsters(Lane_Num);

        foreach (GameObject Mx in Monsters)
        {
            Mx.GetComponent<Monster_Base>().Modify_MoveSpeed(mod, time);
        }
    }

    // All monsters of a specific type move speed modified
    public void Monsters_Modify_Move_Speed(float mod, float time, GameObject M)
    {
        List<GameObject> Monsters;

        if (M != null)
        {
            Monsters = Monster_Mngr.GetComponent<Monster_Manager>().Get_Monster_List(M);

            foreach (GameObject Mx in Monsters)
            {
                Mx.GetComponent<Monster_Base>().Modify_MoveSpeed(mod, time);
            }
        }
        else
        {
            Debug.Log("Monsters_Modify_Move_Speed - Game object parameter is null");
        }
    }

    //
    // Monster Attack Speed Functions
    //

    // All monsters attack speed modified 
    public void Monsters_Modify_Attack_Speed(float mod, float time)
    {
        List<GameObject> Monsters;
        Monsters = Monster_Mngr.GetComponent<Monster_Manager>().Get_Active_Monsters();

        foreach (GameObject Mx in Monsters)
        {
            Mx.GetComponent<Monster_Base>().Modify_AttackSpeed(mod, time);
        }
    }

    // All monsters in a specific lane attack speed modified
    public void Monsters_Modify_Attack_Speed(float mod, float time, int Lane_Num)
    {
        List<GameObject> Monsters;
        Monsters = Lane_Mngr.GetComponent<Lane_Manager>().Get_Lane_Monsters(Lane_Num);

        foreach (GameObject Mx in Monsters)
        {
            Mx.GetComponent<Monster_Base>().Modify_AttackSpeed(mod, time);
        }
    }

    // All monsters of a specific type attack speed modified
    public void Monsters_Modify_Attack_Speed(float mod, float time, GameObject M)
    {
        List<GameObject> Monsters;

        if (M != null)
        {
            Monsters = Monster_Mngr.GetComponent<Monster_Manager>().Get_Monster_List(M);

            foreach (GameObject Mx in Monsters)
            {
                Mx.GetComponent<Monster_Base>().Modify_AttackSpeed(mod, time);
            }
        }
        else
        {
            Debug.Log("Monsters_Modify_Attack_Speed - Game object parameter is null");
        }
    }


    //
    //  PLANTS
    //

    //
    // Plant TAKE DAMAGE Functions
    //

    // All plants take damage, optional parameter for specific type of plant
    public void Plants_Take_Damage(float d, GameObject P = null)
    {
        List<GameObject> Plants;

        if (P != null)
        {
            Plants = Plant_Mngr.GetComponent<Plant_Manager>().Get_Plant_List(P);
        }
        else
        {
            Plants = Plant_Mngr.GetComponent<Plant_Manager>().Get_Active_Plants();
        }

        foreach (GameObject Px in Plants)
        {
            Px.GetComponent<Plant_Base>().TakeDamage(d);
        }
    }

    // All plants in a specific lane take damage
    public void Plants_Take_Damage(float d, int Lane_Num)
    {
        List<GameObject> Plants;
        Plants = Lane_Mngr.GetComponent<Lane_Manager>().Get_Lane_Plants(Lane_Num);

        foreach (GameObject Px in Plants)
        {
            Px.GetComponent<Plant_Base>().TakeDamage(d);
        }
    }

    // All plants take damage over time, optional parameter for specific type of plant
    public void Plants_Take_Damage(float d, float time, GameObject P = null)
    {
        List<GameObject> Plants;

        if (P != null)
        {
            Plants = Plant_Mngr.GetComponent<Plant_Manager>().Get_Plant_List(P);
        }
        else
        {
            Plants = Plant_Mngr.GetComponent<Plant_Manager>().Get_Active_Plants();
        }

        foreach (GameObject Px in Plants)
        {
            Px.GetComponent<Plant_Base>().Take_DamageOverTime(d, time);
        }
    }

    // All plants take damage over time in a specific lane
    public void Plants_Take_Damage(float d, float time, int Lane_Num)
    {
        List<GameObject> Plants;
        Plants = Lane_Mngr.GetComponent<Lane_Manager>().Get_Lane_Plants(Lane_Num);

        foreach (GameObject Px in Plants)
        {
            Px.GetComponent<Plant_Base>().Take_DamageOverTime(d, time);
        }
    }

    //
    // Plant GAIN HEALTH Functions
    //

    // All plants gain health, optional parameter for specific type of plant 
    public void Plants_Gain_Health(float h, GameObject P = null)
    {
        List<GameObject> Plants;

        if (P != null)
        {
            Plants = Plant_Mngr.GetComponent<Plant_Manager>().Get_Plant_List(P);
        }
        else
        {
            Plants = Plant_Mngr.GetComponent<Plant_Manager>().Get_Active_Plants();
        }

        foreach (GameObject Px in Plants)
        {
            Px.GetComponent<Plant_Base>().GainHealth(h);
        }
    }

    // All plants in a specific lane gain health
    public void Plants_Gain_Health(float h, int Lane_Num)
    {
        List<GameObject> Plants;
        Plants = Lane_Mngr.GetComponent<Lane_Manager>().Get_Lane_Plants(Lane_Num);

        foreach (GameObject Px in Plants)
        {
            Px.GetComponent<Plant_Base>().GainHealth(h);
        }
    }

    // All plants gain health over time, optional parameter for specific type of plant
    public void Plants_Gain_Health(float h, float time, GameObject P = null)
    {
        List<GameObject> Plants;

        if (P != null)
        {
            Plants = Plant_Mngr.GetComponent<Plant_Manager>().Get_Plant_List(P);
        }
        else
        {
            Plants = Plant_Mngr.GetComponent<Plant_Manager>().Get_Active_Plants();
        }

        foreach (GameObject Px in Plants)
        {
            Px.GetComponent<Plant_Base>().Gain_HealthOverTime(h, time);
        }
    }

    // All plants gain health over time in a specific lane
    public void Plants_Gain_Health(float h, float time, int Lane_Num)
    {
        List<GameObject> Plants;
        Plants = Lane_Mngr.GetComponent<Lane_Manager>().Get_Lane_Plants(Lane_Num);

        foreach (GameObject Px in Plants)
        {
            Px.GetComponent<Plant_Base>().Gain_HealthOverTime(h, time);
        }
    }

    //
    // Plant Damage Done Functions
    //

    // All plants damage modified 
    public void Plants_Modify_Damage_Done(float mod, float time)
    {
        List<GameObject> Plants;
        Plants = Plant_Mngr.GetComponent<Plant_Manager>().Get_Active_Plants();

        foreach (GameObject Px in Plants)
        {
            Px.GetComponent<Plant_Base>().Modify_DamageDone(mod, time);
        }
    }

    // All plants in a specific lane damage modified
    public void Plants_Modify_Damage_Done(float mod, float time, int Lane_Num)
    {
        List<GameObject> Plants;
        Plants = Lane_Mngr.GetComponent<Lane_Manager>().Get_Lane_Plants(Lane_Num);

        foreach (GameObject Px in Plants)
        {
            Px.GetComponent<Plant_Base>().Modify_DamageDone(mod, time);
        }
    }

    // All plants of a specific type damage modified
    public void Plants_Modify_Damage_Done(float mod, float time, GameObject P)
    {
        List<GameObject> Plants;

        if (P != null)
        {
            Plants = Plant_Mngr.GetComponent<Plant_Manager>().Get_Plant_List(P);

            foreach (GameObject Px in Plants)
            {
                Px.GetComponent<Plant_Base>().Modify_DamageDone(mod, time);
            }
        }
        else
        {
            Debug.Log("Plants_Modify_Damage_Done - Game object parameter is null");
        }
    }

    //
    // Plant Attack Speed Functions
    //

    // All plants attack speed modified 
    public void Plants_Modify_Attack_Speed(float mod, float time)
    {
        List<GameObject> Plants;
        Plants = Plant_Mngr.GetComponent<Plant_Manager>().Get_Active_Plants();

        foreach (GameObject Px in Plants)
        {
            Px.GetComponent<Plant_Base>().Modify_AttackSpeed(mod, time);
        }
    }

    // All plants in a specific lane attack speed modified
    public void Plants_Modify_Attack_Speed(float mod, float time, int Lane_Num)
    {
        List<GameObject> Plants;
        Plants = Lane_Mngr.GetComponent<Lane_Manager>().Get_Lane_Plants(Lane_Num);

        foreach (GameObject Px in Plants)
        {
            Px.GetComponent<Plant_Base>().Modify_AttackSpeed(mod, time);
        }
    }

    // All plants of a specific type attack speed modified
    public void Plants_Modify_Attack_Speed(float mod, float time, GameObject P)
    {
        List<GameObject> Plants;

        if (P != null)
        {
            Plants = Plant_Mngr.GetComponent<Plant_Manager>().Get_Plant_List(P);

            foreach (GameObject Px in Plants)
            {
                Px.GetComponent<Plant_Base>().Modify_AttackSpeed(mod, time);
            }
        }
        else
        {
            Debug.Log("Plants_Modify_Attack_Speed - Game object parameter is null");
        }
    }

    private GameObject Monster_Mngr;
    private GameObject Plant_Mngr;
    private GameObject Lane_Mngr;
}
