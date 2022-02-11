using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{

    public player player;
    Camera cam;

    Vector3 controlDir;
    Vector3 camDir;

    public float distance;
    public float maxDistance = 4.3f;

    public float phi = 0;
    public float theta = 0;

    public float targetAngleH;
    public float targetAngleV;

    public float trackSpeed;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        player = FindObjectOfType<player>();

        controlDir = player.transform.forward;

        targetAngleH = theta;
        targetAngleV = phi;
    }

    public float hOffset = 3;
    public float vOffset = 2;

    public Vector3 targetPosition;
    public Transform target;
    public Transform weapon;
    
    public float weaponPhi = 0.21f;
    public float weaponTheta = 0;

    private Vector3 focusPosition;
    public float camTrackRate = 0.05f;
    public float camSphereRate = 0.5f;

    public float focusPhi = 0.21f;
    public float focusTheta = 0;
    public float setCamHeight = 3;


    // Update is called once per frame
    void FixedUpdate()
    {

        // cam shoot directions
        //look at the player

        //to get a cam controller that goes over the shoulder
        // the cam focus position has to rotate around the player 
        // this allows for the player character to be offset from the camera's center and stay in the position of the camera during gameplay movement
        float targetXPos = player.transform.position.x - distance * Mathf.Sin(focusPhi) * Mathf.Cos(( Mathf.Deg2Rad) + theta);
        float targetZPos = player.transform.position.z - distance * Mathf.Sin(focusPhi) * Mathf.Sin((  Mathf.Deg2Rad) + theta);
        target.position = new Vector3(targetXPos,player.transform.position.y + setCamHeight,targetZPos);

        float targetXPos2 = player.transform.position.x - distance * Mathf.Sin(weaponPhi) * Mathf.Cos((Mathf.Deg2Rad) + theta);
        float targetZPos2 = player.transform.position.z - distance * Mathf.Sin(weaponPhi) * Mathf.Sin((Mathf.Deg2Rad) + theta);
        weapon.position = new Vector3(targetXPos2, player.transform.position.y + setCamHeight, targetZPos2);

        targetPosition = Vector3.Lerp(targetPosition, target.position, camSphereRate);

        cameraCollision();

        
        //focusPosition = targetPosition;
        
        Vector3 camDir = focusPosition - cam.transform.position;
        //lerp this to make this seem fancy
        cam.transform.forward = camDir;

       
        theta = Mathf.LerpAngle(theta, targetAngleH, trackSpeed);
        phi = Mathf.LerpAngle(phi, targetAngleV, trackSpeed);

        float xPos = focusPosition.x - distance * Mathf.Sin(phi) * Mathf.Cos((90 * Mathf.Deg2Rad ) + theta);
        float zPos = focusPosition.z - distance * Mathf.Sin(phi) * Mathf.Sin((90 * Mathf.Deg2Rad ) + theta);
        float yPos = focusPosition.y - distance * Mathf.Cos(phi);

        Vector3 sphereCoordinate = new Vector3(xPos, yPos, zPos);
        cam.transform.position = sphereCoordinate;
    }

    Ray ray;
    RaycastHit hit;
    public float length = 5f;

    void cameraCollision()
    {

        Vector3 camDir = transform.position - focusPosition;

        ray = new Ray(focusPosition, transform.position - focusPosition);

        Debug.DrawRay(focusPosition, transform.position - focusPosition, Color.green, length);
        if (Physics.Raycast(ray, out hit, length))
        {
            Debug.DrawRay(ray.origin, hit.point);
            //Debug.Log(hit.collider.name);
            distance =  Vector3.Distance(focusPosition, hit.point)-0.5f;
            
            Debug.Log("Camera Collision");
        }
        else
        {
            distance = maxDistance;
        }

        Ray leftRay = new Ray(transform.position, Vector3.Cross(camDir,transform.up));
        Ray rightRay = new Ray(transform.position, Vector3.Cross(camDir, transform.up));

        Debug.DrawRay(transform.position, Vector3.Cross(camDir, transform.up), Color.blue, length/2);

        Debug.DrawRay(transform.position, -Vector3.Cross(camDir, transform.up), Color.red, length/2);

        /*
        //right left ray
        if (Physics.Raycast(leftRay, out hit, length/2))
        {
            Debug.DrawRay(ray.origin, hit.point);
           // targetPosition = targetPosition - Vector3.Cross(camDir, transform.up) * Vector3.Distance(focusPosition, hit.point);
        }
        else if (Physics.Raycast(rightRay, out hit, length/2))
        {
            Debug.DrawRay(ray.origin, hit.point);
            //targetPosition = targetPosition + Vector3.Cross(camDir, transform.up) * Vector3.Distance(focusPosition, hit.point);
        }
        else
        {
            //calacaulate vector between player and camera
        }
        */

        focusPosition = Vector3.Lerp(focusPosition,targetPosition,camTrackRate);
    }
}
