using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

    
    Camera cam;
    public GameObject model;

    public float speed;

    public float distanceFromPlayer;

    public float dx;
    public float dz;

    public float lastDX;
    public float lastDZ;

    public float angleOfPlayer;

    public float angleAroundPlayer;
    public float pitch =45;
    public float yaw;
    public float roll;
    public float sensitivity = 1;
    public float zoomSensitivity = 1;

    float horizontalDistance;
    float verticalDistance;

    float offsetX;
    float offsetZ;

    float targetAngle=0;
    float targetPitch = 45;

    float targetZoom = 15;

    public Vector3 crossProduct;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        pitch = 45;
        distanceFromPlayer = 15;
    }

    // Update is called once per frame
    void Update()
    {
        dx = Input.GetAxis("Horizontal");
        dz = Input.GetAxis("Vertical");
        
        //update ouse

        //angleAroundPlayer += Input.GetAxis("Mouse X") * sensitivity;
        //pitch += Input.GetAxis("Mouse Y")*sensitivity;

        
        targetZoom -= Input.GetAxis("Mouse ScrollWheel")* zoomSensitivity;


        Vector3 moveDirection = new Vector3(dx, 0, dz);
        moveDirection.Normalize();

        //claculate player facing position
        angleOfPlayer = Vector3.Angle(model.transform.forward,new Vector3(cam.transform.forward.x,0, cam.transform.forward.z));

        if (Input.GetKeyDown(KeyCode.E))
        {
            targetAngle += 45;

        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            targetAngle -= 45;

        }
        if (targetZoom < 5)
        {
            targetZoom = 5;
        }
        else if (targetZoom > 40)
        {
            targetZoom = 40;

        }

        //interpolate camposition and rotation
        pitch = Mathf.Lerp(pitch, targetPitch, 0.05f);
        targetPitch = targetZoom + 15;
        distanceFromPlayer = Mathf.Lerp(distanceFromPlayer, targetZoom, 0.05f);
        angleAroundPlayer = Mathf.Lerp(angleAroundPlayer, targetAngle, 0.05f);

        if (moveDirection.x != 0 || moveDirection.z != 0)
        {
            lastDX = dx;
            lastDZ = dz;

            model.transform.forward = Quaternion.Euler(0,angleAroundPlayer, 0)*moveDirection;
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
