using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Data : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Num_Ghasts;
    public float Ghast_Spawn_Interval;

    public int Num_Polters;
    public float Polter_Spawn_Interval;

    public int Num_Hexers;
    public float Hexer_Spawn_Interval;

    // bool to indicate if wave has boss modifier, wave manager asks monster manager to randomly pick 1
    public bool Boss_Modifier;

    // 0 up to the number of available lanes
    // If 0, lane is always lane 1
    // If 0, x - lanes are chosen randomly from lane 1 to x
    public int Available_Ghast_Lanes;
    public int Available_Polter_Lanes;
    public int Available_Hexer_Lanes;
}
