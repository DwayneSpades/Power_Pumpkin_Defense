using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Wave_Mngr = GameObject.Find("Wave_Manager");
        Lane_Mngr = GameObject.Find("Lane_Manager");

        Active_Monsters = new List<GameObject>();
        Active_Ghasts = new List<GameObject>();
        Active_Polters = new List<GameObject>();
        Active_Hexers = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //
    //  Cleanup / Active list functions
    //

    public void All_Cleanup()
    {
        StopAllCoroutines();

        foreach (GameObject M in Active_Ghasts)
        {
            Remove_ActiveGhast(M);
        }

        foreach (GameObject M in Active_Polters)
        {
            Remove_ActivePolter(M);
        }

        foreach (GameObject M in Active_Hexers)
        {
            Remove_ActiveHexer(M);
        }

        foreach (GameObject M in Active_Monsters)
        {
            Active_Monsters.Remove(M);
            Destroy(M);
        }
    }

    public bool Check_Empty_Active_Monsters()
    {
        bool ans;

        if (Active_Monsters.Count == 0)
        {
            ans = true;
        }
        else
        {
            ans = false;
        }

        return ans;
    }

    public List<GameObject> Get_Monster_List(GameObject M)
    {
        List<GameObject> Monster_List;

        if (M.name == "Ghast")
        {
            Monster_List = Active_Ghasts;
        }
        else if (M.name == "Polter")
        {
            Monster_List = Active_Polters;
        }
        else if (M.name == "Hexer")
        {
            Monster_List = Active_Hexers;
        }
        else
        {
            Monster_List = null;
        }

        return Monster_List;
    }

    // Get monster list functions
    public List<GameObject> Get_Active_Monsters()
    {
        return Active_Monsters;
    }

    public List<GameObject> Get_Active_Ghasts()
    {
        return Active_Ghasts;
    }

    public List<GameObject> Get_Active_Polters()
    {
        return Active_Polters;
    }

    public List<GameObject> Get_Active_Hexers()
    {
        return Active_Hexers;
    }

    public void Remove_ActiveMonster(GameObject M, int Lane_Num)
    {
        Active_Monsters.Remove(M);
        Lane_Mngr.GetComponent<Lane_Manager>().Remove_Monster_In_Lane(M, Lane_Num);
    }

    public void Remove_ActiveGhast(GameObject M)
    {
        Active_Ghasts.Remove(M);
    }

    public void Remove_ActivePolter(GameObject M)
    {
        Active_Polters.Remove(M);
    }

    public void Remove_ActiveHexer(GameObject M)
    {
        Active_Hexers.Remove(M);
    }

    //
    //  Monster Spawning
    //

    public void Spawn_Ghasts(int Available_Lanes, int Num_Ghasts, float Spawn_Interval)
    {
        StartCoroutine(Ghast_Spawner(Available_Lanes, Num_Ghasts, Spawn_Interval));
    }

    public void Spawn_Polters(int Available_Lanes, int Num_Polters, float Spawn_Interval)
    {
        StartCoroutine(Polter_Spawner(Available_Lanes, Num_Polters, Spawn_Interval));
    }

    public void Spawn_Hexers(int Available_Lanes, int Num_Hexers, float Spawn_Interval)
    {
        StartCoroutine(Hexer_Spawner(Available_Lanes, Num_Hexers, Spawn_Interval));
    }


    IEnumerator Ghast_Spawner(int Available_Lanes, int Num_Ghasts, float Spawn_Interval)
    {
        int GhastNum = Num_Ghasts;

        if (GhastNum > 0)
        {
            GameObject M;

            // Get starting position from lane manager
            Transform start_pos = Lane_Mngr.GetComponent<Lane_Manager>().Get_Lane_Start_Pos(Available_Lanes);

            M = Instantiate(Ghast, start_pos.position, start_pos.rotation);
            Active_Monsters.Add(M);
            Active_Ghasts.Add(M);

            GhastNum--;

            yield return new WaitForSeconds(Spawn_Interval);

            StartCoroutine(Ghast_Spawner(Available_Lanes, GhastNum, Spawn_Interval));
        }
        else
        {
            Wave_Mngr.GetComponent<Wave_Manager>().Update_Enemy_SpawnType_Status();
            // End Coroutine
        }
    }

    IEnumerator Polter_Spawner(int Available_Lanes, int Num_Polters, float Spawn_Interval)
    {
        int PolterNum = Num_Polters;

        if (PolterNum > 0)
        {
            GameObject M;

            // Get starting position from lane manager
            Transform start_pos = Lane_Mngr.GetComponent<Lane_Manager>().Get_Lane_Start_Pos(Available_Lanes);

            M = Instantiate(Polter, start_pos.position, start_pos.rotation);
            Active_Monsters.Add(M);
            Active_Polters.Add(M);

            PolterNum--;

            yield return new WaitForSeconds(Spawn_Interval);

            StartCoroutine(Polter_Spawner(Available_Lanes, PolterNum, Spawn_Interval));
        }
        else
        {
            Wave_Mngr.GetComponent<Wave_Manager>().Update_Enemy_SpawnType_Status();
            // End Coroutine
        }
    }

    IEnumerator Hexer_Spawner(int Available_Lanes, int Num_Hexers, float Spawn_Interval)
    {
        int HexerNum = Num_Hexers;

        if (HexerNum > 0)
        {
            GameObject M;

            // Get starting position from lane manager
            Transform start_pos = Lane_Mngr.GetComponent<Lane_Manager>().Get_Lane_Start_Pos(Available_Lanes);

            M = Instantiate(Hexer, start_pos.position, start_pos.rotation);
            Active_Monsters.Add(M);
            Active_Hexers.Add(M);

            HexerNum--;

            yield return new WaitForSeconds(Spawn_Interval);

            StartCoroutine(Hexer_Spawner(Available_Lanes, HexerNum, Spawn_Interval));
        }
        else
        {
            Wave_Mngr.GetComponent<Wave_Manager>().Update_Enemy_SpawnType_Status();
            // End Coroutine
        }
    }

    //
    //  Variables and stuff
    //

    private GameObject Wave_Mngr;
    private GameObject Lane_Mngr;

    [SerializeField] private List<GameObject> Active_Monsters;
    [SerializeField] private List<GameObject> Active_Ghasts;
    [SerializeField] private List<GameObject> Active_Polters;
    [SerializeField] private List<GameObject> Active_Hexers;

    public GameObject Ghast;
    public GameObject Polter;
    public GameObject Hexer;

    public GameObject BloodWitch;
}
