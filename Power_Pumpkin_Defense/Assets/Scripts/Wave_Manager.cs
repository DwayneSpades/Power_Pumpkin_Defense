using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Current_Wave_Num = 0;
        //IsWaveActive = false;
        ReadyForNewWave = false;
        ReadyForWaveCooldown = false;

        Num_Enemy_Types_Done = 0;

        Active_Monsters = new List<GameObject>();
        Active_Ghasts = new List<GameObject>();
        Active_Polters = new List<GameObject>();
        Active_Hexers = new List<GameObject>();

        Instantiate(GreatPumpkin, EndPos.transform.position, EndPos.transform.rotation);
        Great_Pumpkin_Alive = true;

        StartCoroutine(WaveCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        if (ReadyForNewWave)
        {
            ReadyForNewWave = false;

            if (Current_Wave_Num < Wave_Data_List.Count)
            {
                Debug.Log("Wave Start - Wave: " + (Current_Wave_Num + 1)); // Displays current wave + 1, so wave 0 is wave 1

                // Update Wave Object
                Current_Wave_Obj = Wave_Data_List[Current_Wave_Num];

                // Ghast Spawner
                int Num_Monsters = Current_Wave_Obj.GetComponent<Wave_Data>().Num_Ghasts;
                float Interval = Current_Wave_Obj.GetComponent<Wave_Data>().Ghast_Spawn_Interval;

                StartCoroutine(Ghast_Spawner(Num_Monsters, Interval));

                // Polter Spawner
                Num_Monsters = Current_Wave_Obj.GetComponent<Wave_Data>().Num_Polters;
                Interval = Current_Wave_Obj.GetComponent<Wave_Data>().Polter_Spawn_Interval;

                StartCoroutine(Polter_Spawner(Num_Monsters, Interval));

                // Hexer Spawner
                Num_Monsters = Current_Wave_Obj.GetComponent<Wave_Data>().Num_Hexers;
                Interval = Current_Wave_Obj.GetComponent<Wave_Data>().Hexer_Spawn_Interval;

                StartCoroutine(Hexer_Spawner(Num_Monsters, Interval));

                Current_Wave_Num++;

                // Starts a coroutine that checks if there are no active monsters every second, If true then the wave cooldown can begin
                // Need this to make sure the cooldown timer is starting more consistently without checking every single frame
                StartCoroutine(Check_Wave_Status());
            }
                   
        }

        if (ReadyForWaveCooldown)
        {
            ReadyForWaveCooldown = false;

            // Moved this check here so that the game ends faster instead of triggering a cooldown before ending
            if (Current_Wave_Num >= Wave_Data_List.Count && Great_Pumpkin_Alive)
            {
                Debug.Log("Great Pumpkin Survived. You Win!");
                // Call Game Controller. Game Win
            }
            else
            {
                StartCoroutine(WaveCooldown());
            }
        }
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

    public void Clean_Up_Wave()
    {
        // This call is necessary to stop the spawners
        StopAllCoroutines();

        GameObject[] Monsters;

        // Ghast Clean up
        Monsters = GameObject.FindGameObjectsWithTag("Ghast");

        foreach (GameObject M in Monsters)
        {
            Remove_ActiveGhast(M);
            Remove_ActiveMonster(M);
            Destroy(M);
        }

        // Polter Clean up
        Monsters = GameObject.FindGameObjectsWithTag("Polter");

        foreach (GameObject M in Monsters)
        {
            Remove_ActivePolter(M);
            Remove_ActiveMonster(M);
            Destroy(M);
        }

        // Hexer Clean up
        Monsters = GameObject.FindGameObjectsWithTag("Hexer");

        foreach (GameObject M in Monsters)
        {
            Remove_ActiveHexer(M);
            Remove_ActiveMonster(M);
            Destroy(M);
        }

        // Call Game Controller - Game over
    }

    public void GreatPumpkin_Dead()
    {
        Great_Pumpkin_Alive = false;
    }

    IEnumerator Check_Wave_Status()
    {
        yield return new WaitForSeconds(1);

        if (Num_Enemy_Types_Done == Num_Enemy_Types && Active_Monsters.Count == 0)
        {
            ReadyForWaveCooldown = true;

            // Tell game controller to notify player that wave X has ended. Break starts
        }
        else
        {
            StartCoroutine(Check_Wave_Status());
        }
    }

    IEnumerator WaveCooldown()
    {
        yield return new WaitForSeconds(Wave_Cooldown_Timer);

        Debug.Log("Wave Cooldown Done");
        Num_Enemy_Types_Done = 0;
        //IsWaveActive = true;
        ReadyForNewWave = true;
    }

    IEnumerator Ghast_Spawner(int Num_Ghasts, float Spawn_Interval)
    {
        int GhastNum = Num_Ghasts;

        if (GhastNum > 0)
        {
            GameObject M;
            M = Instantiate(Ghast, StartPos.transform.position, StartPos.transform.rotation);
            Active_Monsters.Add(M);
            Active_Ghasts.Add(M);

            GhastNum--;

            yield return new WaitForSeconds(Spawn_Interval);

            StartCoroutine(Ghast_Spawner(GhastNum, Spawn_Interval));
        }
        else
        {
            Num_Enemy_Types_Done++;
            // End Coroutine
        }
    }

    IEnumerator Polter_Spawner(int Num_Polters, float Spawn_Interval)
    {
        int PolterNum = Num_Polters;

        if (PolterNum > 0)
        {
            GameObject M;
            M = Instantiate(Polter, StartPos.transform.position, StartPos.transform.rotation);
            Active_Monsters.Add(M);
            Active_Polters.Add(M);

            PolterNum--;

            yield return new WaitForSeconds(Spawn_Interval);

            StartCoroutine(Polter_Spawner(PolterNum, Spawn_Interval));
        }
        else
        {
            Num_Enemy_Types_Done++;
            // End Coroutine
        }
    }

    IEnumerator Hexer_Spawner(int Num_Hexers, float Spawn_Interval)
    {
        int HexerNum = Num_Hexers;

        if (HexerNum > 0)
        {
            GameObject M;
            M = Instantiate(Hexer, StartPos.transform.position, StartPos.transform.rotation);
            Active_Monsters.Add(M);
            Active_Hexers.Add(M);

            HexerNum--;

            yield return new WaitForSeconds(Spawn_Interval);

            StartCoroutine(Hexer_Spawner(HexerNum, Spawn_Interval));
        }
        else
        {
            Num_Enemy_Types_Done++;
            // End Coroutine
        }
    }

    public List<GameObject> Wave_Data_List;

    [SerializeField] private List<GameObject> Active_Monsters;
    [SerializeField] private List<GameObject> Active_Ghasts;
    [SerializeField] private List<GameObject> Active_Polters;
    [SerializeField] private List<GameObject> Active_Hexers;

    private GameObject Current_Wave_Obj;
    private int Current_Wave_Num;
    private bool Great_Pumpkin_Alive;

    public GameObject Ghast;
    public GameObject Polter;
    public GameObject Hexer;
    public GameObject GreatPumpkin;

    public GameObject StartPos;
    public GameObject EndPos;

    // Wave cooldown/control variables
    public float Wave_Cooldown_Timer;
    //private bool IsWaveActive;
    private bool ReadyForNewWave;

    [SerializeField] private int Num_Enemy_Types;
    private bool ReadyForWaveCooldown;
    private int Num_Enemy_Types_Done;
}
