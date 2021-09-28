using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Plant_Lanes = new List<List<GameObject>>();
        Monster_Lanes = new List<List<GameObject>>();

        Lane_1_Plants = new List<GameObject>();
        Lane_2_Plants = new List<GameObject>();
        Lane_3_Plants = new List<GameObject>();

        Lane_1_Monsters = new List<GameObject>();
        Lane_2_Monsters = new List<GameObject>();
        Lane_3_Monsters = new List<GameObject>();

        Plant_Lanes.Add(Lane_1_Plants);
        Plant_Lanes.Add(Lane_2_Plants);
        Plant_Lanes.Add(Lane_3_Plants);

        Monster_Lanes.Add(Lane_1_Monsters);
        Monster_Lanes.Add(Lane_2_Monsters);
        Monster_Lanes.Add(Lane_3_Monsters);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Called when game is over
    public void All_Cleanup()
    {
        foreach (List<GameObject> L in Plant_Lanes)
        {
            foreach (GameObject P in L)
            {
                L.Remove(P);
                Destroy(P);
            }

            Plant_Lanes.Remove(L);
        }

        foreach (List<GameObject> M in Monster_Lanes)
        {
            foreach (GameObject Mx in M)
            {
                M.Remove(Mx);
                Destroy(Mx);
            }

            Monster_Lanes.Remove(M);
        }
    }

    public void Add_Monster_To_Lane(GameObject M, int index)
    {
        Debug.Log("Added Monster: " + M.name);
        Monster_Lanes[index].Add(M);
    }

    public void Remove_Monster_In_Lane(GameObject M, int index)
    {
        Debug.Log("Removed Monster: " + M.name);
        Monster_Lanes[index].Remove(M);
    }

    public void Add_Plant_To_Lane(GameObject P, int index)
    {
        Debug.Log("Added Plant: " + P.name);
        Plant_Lanes[index - 1].Add(P);
    }

    public void Remove_Plant_In_Lane(GameObject P, int index)
    {
        Debug.Log("Removed Plant: " + P.name);
        Plant_Lanes[index - 1].Remove(P);
    }

    public List<Transform> GetPath(GameObject Monster, Vector3 t)
    {
        List<Transform> ret;

        if (Vector3.Distance(t, Lane_Starting_List[0].transform.position) == 0)
        {
            ret = Lane_1_List;
            Monster.GetComponent<Monster_Base>().Assign_Lane_Number(0);
        }
        else if (Vector3.Distance(t, Lane_Starting_List[1].transform.position) == 0)
        {
            ret = Lane_2_List;
            Monster.GetComponent<Monster_Base>().Assign_Lane_Number(1);
        }
        else
        {
            ret = Lane_3_List;
            Monster.GetComponent<Monster_Base>().Assign_Lane_Number(2);
        }

        return ret;
    }

    public Transform Get_Lane_Start_Pos(int Lane_Range)
    {
        int tmp = Random.Range(0, Lane_Range);

        return Lane_Starting_List[tmp];
    }

    //
    // Variables and containers
    // 

    // List of lane positions
    [SerializeField] private List<Transform> Lane_1_List;
    [SerializeField] private List<Transform> Lane_2_List;
    [SerializeField] private List<Transform> Lane_3_List;

    [SerializeField] private List<Transform> Lane_Starting_List;

    // List of lane plants
    [SerializeField] private List<GameObject> Lane_1_Plants;
    [SerializeField] private List<GameObject> Lane_2_Plants;
    [SerializeField] private List<GameObject> Lane_3_Plants;

    // Lists of lane ghosts? // give ghosts a number then it asks lane manager for starting position and path using that number
    [SerializeField] private List<GameObject> Lane_1_Monsters;
    [SerializeField] private List<GameObject> Lane_2_Monsters;
    [SerializeField] private List<GameObject> Lane_3_Monsters;

    // List of lists of lane plants and monsters
    [SerializeField] private List<List<GameObject>> Plant_Lanes;
    [SerializeField] private List<List<GameObject>> Monster_Lanes;
}
