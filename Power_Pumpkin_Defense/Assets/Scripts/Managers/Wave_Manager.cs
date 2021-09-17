using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(Ghast, StartPos.transform.position, StartPos.transform.rotation);
        }
    }

    public GameObject Ghast;
    public GameObject StartPos;
}
