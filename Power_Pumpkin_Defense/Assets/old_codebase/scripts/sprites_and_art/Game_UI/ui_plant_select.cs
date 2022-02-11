using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_plant_select : MonoBehaviour
{
    public GameObject highlight;
    

    // Start is called before the first frame update
    void Start()
    {
        highlight = FindObjectOfType<ui_highlight>().gameObject;    
    }

    public void select()
    {
        highlight.GetComponent<ui_highlight>().targetPos = transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
