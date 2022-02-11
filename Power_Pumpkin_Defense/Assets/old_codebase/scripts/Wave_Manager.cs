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

        Lane_Mngr = GameObject.Find("Lane_Manager");
        Monster_Mngr = GameObject.Find("Monster_Manager");
        UI_Mngr = GameObject.Find("UI_Manager");

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
                //UI_Mngr.GetComponent<UI_Manager>().Display_Wave_Num(Current_Wave_Num + 1);

                // Update Wave Object
                Current_Wave_Obj = Wave_Data_List[Current_Wave_Num];

                // Spawn Ghasts
                int Num_Monsters = Current_Wave_Obj.GetComponent<Wave_Data>().Num_Ghasts;
                float Interval = Current_Wave_Obj.GetComponent<Wave_Data>().Ghast_Spawn_Interval;
                int Avail_Lanes = Current_Wave_Obj.GetComponent<Wave_Data>().Available_Ghast_Lanes;

                Monster_Mngr.GetComponent<Monster_Manager>().Spawn_Ghasts(Avail_Lanes, Num_Monsters, Interval);

                // Spawn Polters
                Num_Monsters = Current_Wave_Obj.GetComponent<Wave_Data>().Num_Polters;
                Interval = Current_Wave_Obj.GetComponent<Wave_Data>().Polter_Spawn_Interval;
                Avail_Lanes = Current_Wave_Obj.GetComponent<Wave_Data>().Available_Polter_Lanes;

                Monster_Mngr.GetComponent<Monster_Manager>().Spawn_Polters(Avail_Lanes, Num_Monsters, Interval);

                // Spawn Hexers
                Num_Monsters = Current_Wave_Obj.GetComponent<Wave_Data>().Num_Hexers;
                Interval = Current_Wave_Obj.GetComponent<Wave_Data>().Hexer_Spawn_Interval;
                Avail_Lanes = Current_Wave_Obj.GetComponent<Wave_Data>().Available_Hexer_Lanes;

                Monster_Mngr.GetComponent<Monster_Manager>().Spawn_Hexers(Avail_Lanes, Num_Monsters, Interval);


                // Check Boss data
                if (Current_Wave_Obj.GetComponent<Wave_Data>().Wave_Boss_Modifiers.Count != 0)
                {
                    GameObject Boss;
                    float Time_To_Boss;

                    // Boss Spawning
                    if (Current_Wave_Obj.GetComponent<Wave_Data>().Wave_Boss_Modifiers.Count == 1)
                    {
                        Boss = Current_Wave_Obj.GetComponent<Wave_Data>().Wave_Boss_Modifiers[0];
                        Time_To_Boss = Current_Wave_Obj.GetComponent<Wave_Data>().Time_Until_Boss_Active;

                        Monster_Mngr.GetComponent<Monster_Manager>().Spawn_Boss_Modifier(Boss, Time_To_Boss);
                    }
                    else if (Current_Wave_Obj.GetComponent<Wave_Data>().Wave_Boss_Modifiers.Count > 1)
                    {
                        int Random_Boss_Pick = Random.Range(0, Current_Wave_Obj.GetComponent<Wave_Data>().Wave_Boss_Modifiers.Count);
                        Boss = Current_Wave_Obj.GetComponent<Wave_Data>().Wave_Boss_Modifiers[Random_Boss_Pick];
                        Time_To_Boss = Current_Wave_Obj.GetComponent<Wave_Data>().Time_Until_Boss_Active;

                        Monster_Mngr.GetComponent<Monster_Manager>().Spawn_Boss_Modifier(Boss, Time_To_Boss);
                    }
                }

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
                UI_Mngr.GetComponent<UI_Manager>().Display_Win_Text();
                Debug.Log("Great Pumpkin Survived. You Win!");
                // Call Game Controller. Game Win
            }
            else
            {
                StartCoroutine(WaveCooldown());
            }
        }
    }

    // Called when game over
    public void Clean_Up_Wave()
    {
        // This call is necessary to stop the spawners
        StopAllCoroutines();

        // Tell Monster manager and lane manager to clean up active monsters / plants
        Monster_Mngr.GetComponent<Monster_Manager>().All_Cleanup();
        Lane_Mngr.GetComponent<Lane_Manager>().All_Cleanup();

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
        UI_Mngr.GetComponent<UI_Manager>().Display_Wave_Cooldown();
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

    public float Get_Wave_Cooldown_Time()
    {
        return Wave_Cooldown_Timer;
    }

    private GameObject Monster_Mngr;
    private GameObject Lane_Mngr;
    private GameObject UI_Mngr;

    [SerializeField] private List<GameObject> Wave_Data_List;

    private GameObject Current_Wave_Obj;
    private int Current_Wave_Num;
    private bool Great_Pumpkin_Alive;

    // Wave cooldown/control variables
    [SerializeField] private float Wave_Cooldown_Timer;
    //private bool IsWaveActive;
    private bool ReadyForNewWave;

    [SerializeField] private int Num_Enemy_SpawnTypes;
    private bool ReadyForWaveCooldown;
    private int Num_Enemy_SpawnTypes_Done;
}
