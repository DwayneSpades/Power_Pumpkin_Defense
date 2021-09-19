using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angleFromCamera : MonoBehaviour
{

    public GameObject target;
    public mouseAim aim;
    public float influence=1;
    public bool follow;

    private Vector3 pos_1;

    public Vector3 pos_2;

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationX = 0F;
    float rotationY = 0F;
    Quaternion originalRotation;

    private bool camView;
    // Start is called before the first frame update
    void Start()
    {
        camView = true;
        pos_1 = transform.position;
        

        originalRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {

        
        /*
        if (axes == RotationAxes.MouseXAndY)
        {
            // Read the mouse input axis
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);
            transform.localRotation = originalRotation * xQuaternion * yQuaternion;
        }
        else if (axes == RotationAxes.MouseX)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation = originalRotation * xQuaternion;
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
            Quaternion yQuaternion = Quaternion.AngleAxis(-rotationY, Vector3.right);
            transform.localRotation = originalRotation * yQuaternion;
        }
        */
        
    }
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.T) && camView)
        {
            camView = false;
            transform.position = pos_1;
        }
        else if (Input.GetKeyDown(KeyCode.T) && !camView)
        {
            camView = true;
            transform.position = pos_2;
        }
        if (follow)
        {
            if(transform.position.z < target.transform.position.z)
                GetComponent<Camera>().transform.LookAt(new Vector3(target.transform.position.x, target.transform.position.y + 2, target.transform.position.z + 2 + Mathf.Abs(target.transform.position.x)), Vector3.up);
            if (transform.position.z > target.transform.position.z)
                GetComponent<Camera>().transform.LookAt(new Vector3(target.transform.position.x, target.transform.position.y + 2, target.transform.position.z - 2 - Mathf.Abs(target.transform.position.x)), Vector3.up);

        }

    }

    public static float ClampAngle(float angle, float min, float max)
    {
        
        return Mathf.Clamp(angle, min, max);
    }
}
