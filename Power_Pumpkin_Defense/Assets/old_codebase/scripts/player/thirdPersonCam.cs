using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonCam : MonoBehaviour
{
    Camera cam;
    public Transform camTransform;
    public Transform lookAt;

    public  float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 4.0f;
    private float sensitvityY = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        camTransform = transform;
        cam = Camera.main;
    }

    void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
        distance += Input.GetAxis("Mouse ScrollWheel");
    }
    // Update is called once per frame
    void LateUpdate()
    {


        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
        //lookAt.forward = new Vector3(lookAt.forward.x, camTransform.forward.y, lookAt.forward.z);
    }
}
