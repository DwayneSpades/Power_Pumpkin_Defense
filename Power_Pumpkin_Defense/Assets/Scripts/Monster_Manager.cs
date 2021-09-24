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

        Ghast_Cleanup();
        Polter_Cleanup();
        Hexer_Cleanup();
    }

    public void Ghast_Cleanup()
    {
        GameObject[] Monsters;

        // Ghast Clean up
        Monsters = GameObject.FindGameObjectsWithTag("Ghast");

        foreach (GameObject M in Monsters)
        {
            Remove_ActiveGhast(M);
            Remove_ActiveMonster(M);
            Destroy(M);
        }
    }

    public void Polter_Cleanup()
    {
        GameObject[] Monsters;

        // Polter Clean up
        Monsters = GameObject.FindGameObjectsWithTag("Polter");

        foreach (GameObject M in Monsters)
        {
            Remove_ActivePolter(M);
            Remove_ActiveMonster(M);
            Destroy(M);
        }
    }

    public void Hexer_Cleanup()
    {
        GameObject[] Monsters;

        // Hexer Clean up
        Monsters = GameObject.FindGameObjectsWithTag("Hexer");

        foreach (GameObject M in Monsters)
        {
            Remove_ActiveHexer(M);
            Remove_ActiveMonster(M);
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

    public void Remove_ActiveMonster(GameObject M)
    {
        Active_Monsters.Remove(M);
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
            Transform start_pos = Lane_Mngr.GetComponent<Lane_Manager>().Get_Lane_Pos(Available_Lanes);

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
            Transform start_pos = Lane_Mngr.GetComponent<Lane_Manager>().Get_Lane_Pos(Available_Lanes);

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
            Transform start_pos = Lane_Mngr.GetComponent<Lane_Manager>().Get_Lane_Pos(Available_Lanes);

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
}
