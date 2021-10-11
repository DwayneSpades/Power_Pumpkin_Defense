using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

    
    Camera cam;
    public GameObject model;

    public float speed;

    public float distanceFromPlayer;
    public float angleAroundPlayer;
    public float pitch;
    public float yaw;
    public float roll;
    public float sensitivity = 1;

    float horizontalDistance;
    float verticalDistance;

    float offsetX;
    float offsetZ;

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

        //update ouse

        angleAroundPlayer += Input.GetAxis("Mouse X") * sensitivity;
        pitch += Input.GetAxis("Mouse Y");
        distanceFromPlayer += Input.GetAxis("Mouse ScrollWheel");

        Vector3 moveDirection = new Vector3(dx, 0, dz);
        moveDirection.Normalize();

        if (moveDirection.x != 0 || moveDirection.z != 0)
        {
            model.transform.forward = Quaternion.Euler(0, angleAroundPlayer, 0)*moveDirection;
            model.GetComponent<Animator>().Play("run");
        }
        else
        {
            model.GetComponent<Animator>().Play("idle");
        }

        //move player in direction relative to camera direction
        transform.position = transform.position + Quaternion.Euler(0,angleAroundPlayer,0) * moveDirection * speed  * Time.deltaTime;
         
    }
    void LateUpdate()
    {
        //claclulate camera position and orientation around player
        horizontalDistance = distanceFromPlayer * Mathf.Cos(Mathf.Deg2Rad * pitch);
        verticalDistance = distanceFromPlayer * Mathf.Sin(Mathf.Deg2Rad * pitch);

        offsetX = horizontalDistance * Mathf.Sin(Mathf.Deg2Rad * angleAroundPlayer);
        offsetZ = horizontalDistance * Mathf.Cos(Mathf.Deg2Rad * angleAroundPlayer);

        Vector3 camPos = new Vector3(transform.position.x - offsetX, transform.position.y + verticalDistance, transform.position.z - offsetZ);
        cam.transform.position = camPos;
        cam.transform.LookAt(transform.position, Vector3.up);
    }
}
