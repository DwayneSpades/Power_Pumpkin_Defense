using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

    public float speed;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");

        float targetAngle = Mathf.Atan2(dx, dz) * Mathf.Rad2Deg;
         
        Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * transform.forward;
        moveDirection.Normalize();
        transform.position = moveDirection * speed  * Time.deltaTime;
       // transform.forward = moveDirection;

    }
}
