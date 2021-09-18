using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ActiveMonsters = new List<GameObject>();

        Instantiate(GreatPumpkin, EndPos.transform.position, EndPos.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject M;
            M = Instantiate(Ghast, StartPos.transform.position, StartPos.transform.rotation);
            Add_ActiveMonster(M);
        }
    }

    void Add_ActiveMonster(GameObject M)
    {
        ActiveMonsters.Add(M);
    }

    public void Remove_ActiveMonster(GameObject M)
    {
        ActiveMonsters.Remove(M);
    }

    public void Clean_Up_Wave()
    {
        GameObject[] Monsters;

        Monsters = GameObject.FindGameObjectsWithTag("Ghast");

        foreach (GameObject M in Monsters)
        {
            Destroy(M);
        }
    }

    private List<GameObject> ActiveMonsters;

    public GameObject Ghast;
    public GameObject Polter;
    public GameObject Hexer;
    public GameObject GreatPumpkin;

    public GameObject StartPos;
    public GameObject EndPos;
}
