using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class world_ui : MonoBehaviour
{

    Camera camRef;
    Canvas canvasRef;
    public Transform target;
    public Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        camRef = Camera.main;
        canvasRef = FindObjectOfType<Canvas>();
        transform.SetParent(canvasRef.transform);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = camRef.WorldToScreenPoint(target.position +offset);

        if(transform.position!=pos)
            transform.position = pos;
    }
}
