using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_highlight : MonoBehaviour
{
    public Vector3 targetPos;
    public Transform initialPosition;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = initialPosition.position;
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       transform.position =
            Vector3.Lerp(transform.position,targetPos, speed);
    }
}
