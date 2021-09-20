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

        Num_Enemy_SpawnTypes_Done = 0;

        Monster_Mngr = GameObject.Find("Monster_Manager");

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

                // Spawn Ghasts
                int Num_Monsters = Current_Wave_Obj.GetComponent<Wave_Data>().Num_Ghasts;
                float Interval = Current_Wave_Obj.GetComponent<Wave_Data>().Ghast_Spawn_Interval;

                Monster_Mngr.GetComponent<Monster_Manager>().Spawn_Ghasts(StartPos, Num_Monsters, Interval);

                // Spawn Polters
                Num_Monsters = Current_Wave_Obj.GetComponent<Wave_Data>().Num_Polters;
                Interval = Current_Wave_Obj.GetComponent<Wave_Data>().Polter_Spawn_Interval;

                Monster_Mngr.GetComponent<Monster_Manager>().Spawn_Polters(StartPos, Num_Monsters, Interval);

                // Spawn Hexers
                Num_Monsters = Current_Wave_Obj.GetComponent<Wave_Data>().Num_Hexers;
                Interval = Current_Wave_Obj.GetComponent<Wave_Data>().Hexer_Spawn_Interval;

                Monster_Mngr.GetComponent<Monster_Manager>().Spawn_Hexers(StartPos, Num_Monsters, Interval);


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

    public void Clean_Up_Wave()
    {
        // This call is necessary to stop the spawners
        StopAllCoroutines();

        // Tell Monster manager to clean up active monsters
        Monster_Mngr.GetComponent<Monster_Manager>().All_Cleanup();

        // Call Game Controller - Game over

    }

    public void GreatPumpkin_Dead()
    {
        Great_Pumpkin_Alive = false;
    }

    IEnumerator Check_Wave_Status()
    {
        yield return new WaitForSeconds(1);

        if (Num_Enemy_SpawnTypes_Done == Num_Enemy_SpawnTypes && Monster_Mngr.GetComponent<Monster_Manager>().Check_Empty_Active_Monsters())
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

        //Debug.Log("Wave Cooldown Done");
        Num_Enemy_SpawnTypes_Done = 0;
        //IsWaveActive = true;
        ReadyForNewWave = true;
    }

    public void Update_Enemy_SpawnType_Status()
    {
        Num_Enemy_SpawnTypes_Done++;
    }

    private GameObject Monster_Mngr;

    public List<GameObject> Wave_Data_List;

    private GameObject Current_Wave_Obj;
    private int Current_Wave_Num;
    private bool Great_Pumpkin_Alive;

    public GameObject StartPos;
    public GameObject EndPos;

    // Wave cooldown/control variables
    public float Wave_Cooldown_Timer;
    //private bool IsWaveActive;
    private bool ReadyForNewWave;

    [SerializeField] private int Num_Enemy_SpawnTypes;
    private bool ReadyForWaveCooldown;
    private int Num_Enemy_SpawnTypes_Done;
}
