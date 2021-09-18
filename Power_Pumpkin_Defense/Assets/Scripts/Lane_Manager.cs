using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GetLanes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Transform> Lane_1_List;
    public List<Transform> Lane_2_List;
    public List<Transform> Lane_3_List;

    public List<Transform> GetAPath()
    {
        List<Transform> ret;

        int LaneNum = Random.Range(0, 3);

        if (LaneNum == 0)
        {
            ret = Lane_1_List;
        }
        else if (LaneNum == 1)
        {
            ret = Lane_2_List;
        }
        else
        {
            ret = Lane_3_List;
        }

        return ret;
    }

    void GetLanes()
    {
        //Transform Lane2 = GameObject.Find("Lane2_Positions").GetComponent<Transform>();

        //for (int i = 0; i < Lane2.childCount; i++)
        //{
        //    Lane_2_List.Add(Lane2.GetChild(i));
        //}

        //Debug.Log("Lane 2 list size: " + Lane_2_List.Count);
    }
}
