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

    public List<Transform> Lane_Starting_List;

    public List<Transform> GetPath(Vector3 t)
    {
        List<Transform> ret;

        float test = Vector3.Distance(t, Lane_Starting_List[0].transform.position);
        float test2 = Vector3.Distance(t, Lane_Starting_List[1].transform.position);
        float test3 = Vector3.Distance(t, Lane_Starting_List[2].transform.position);
        // (test < 1.0f)
        if (Vector3.Distance(t, Lane_Starting_List[0].transform.position) == 0)
        {
            ret = Lane_1_List;
        }
        else if (Vector3.Distance(t, Lane_Starting_List[1].transform.position) == 0)
        {
            ret = Lane_2_List;
        }
        else
        {
            ret = Lane_3_List;
        }

        return ret;
    }

    public Transform Get_Lane_Pos(int Lane_Range)
    {
        int tmp = Random.Range(0, Lane_Range);

        return Lane_Starting_List[tmp];
    }
}
