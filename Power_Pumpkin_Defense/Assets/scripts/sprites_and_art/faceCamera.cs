using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceCamera : MonoBehaviour
{

    public bool zRotate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        if (zRotate)
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

    }
}
