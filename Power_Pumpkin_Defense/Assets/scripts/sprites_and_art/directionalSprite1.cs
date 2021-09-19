using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class directionalSprite1 : MonoBehaviour
{


    public GameObject carRef;
    public Animator animController;
    public bool zRotate;

    public bool hasGun;
    public Vector3 lookDir;

    public GameObject sightPoint;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {

        transform.LookAt(Camera.main.transform);
        if(zRotate)
            transform.rotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y,0);

        if (hasGun)
        {
            //lookDir = gameObject.GetComponent<mouseAim>().newDir;
            lookDir =  sightPoint.transform.position - transform.position;
            lookDir.Normalize();

            float angle = Vector3.Angle(lookDir, Camera.main.transform.forward);
            //Debug.Log(angle);
            changeSprite3(angle);
        }
        else
        {
            

            float angle = Vector3.Angle(carRef.transform.forward, Camera.main.transform.forward);
            Debug.Log(angle);
            changeSprite(angle);
        }
        
    }
    void changeSprite2(float angle)
    {

        //front
        if (angle >= 0 && angle < 22.5)
        {
            animController.Play("back");
        }
        //left side
        else if (angle >= 22.5 && angle < 67.5 && transform.position.x < gameObject.GetComponent<mouseAim>().targetPosition.x)
        {
            animController.Play("back_L");
        }
        else if (angle >= 67.5 && angle < 112.5 && transform.position.x < gameObject.GetComponent<mouseAim>().targetPosition.x)
        {
            animController.Play("side_L");
        }
        else if (angle >= 112.5 && angle < 157.5 && transform.position.x < gameObject.GetComponent<mouseAim>().targetPosition.x)
        {
            animController.Play("front_L");
        }
        //right side
        else if (angle >= 22.5 && angle < 67.5 && transform.position.x > gameObject.GetComponent<mouseAim>().targetPosition.x)
        {
            animController.Play("back_R");
        }
        else if (angle >= 67.5 && angle < 112.5 && transform.position.x > gameObject.GetComponent<mouseAim>().targetPosition.x)
        {
            animController.Play("side_R");
        }
        else if (angle >= 112.5 && angle < 157.5 && transform.position.x > gameObject.GetComponent<mouseAim>().targetPosition.x)
        {
            animController.Play("front_R");
        }
        //front
        else if (angle >= 157.5 && angle < 180)
        {
            animController.Play("front");
        }


    }
    void changeSprite3(float angle)
    {

        //front
        if (angle >= 0 && angle < 22.5)
        {
            animController.Play("back");
        }
        //left side
        else if (angle >= 22.5 && angle < 67.5 && transform.position.x < sightPoint.transform.position.x)
        {
            animController.Play("back_L");
        }
        else if (angle >= 67.5 && angle < 112.5 && transform.position.x < sightPoint.transform.position.x)
        {
            animController.Play("side_L");
        }
        else if (angle >= 112.5 && angle < 157.5 && transform.position.x < sightPoint.transform.position.x)
        {
            animController.Play("front_L");
        }
        //right side
        else if (angle >= 22.5 && angle < 67.5 && transform.position.x > sightPoint.transform.position.x)
        {
            animController.Play("back_R");
        }
        else if (angle >= 67.5 && angle < 112.5 && transform.position.x > sightPoint.transform.position.x)
        {
            animController.Play("side_R");
        }
        else if (angle >= 112.5 && angle < 157.5 && transform.position.x > sightPoint.transform.position.x)
        {
            animController.Play("front_R");
        }
        //front
        else if (angle >= 157.5 && angle < 180)
        {
            animController.Play("front");
        }


    }
    void changeSprite(float angle)
    {
        
        //front
        if(angle >= 0 && angle < 22.5)
        {
            animController.Play("back");
        }
        //left side
        else if (angle >= 22.5 && angle < 67.5 && transform.position.x < Camera.main.transform.position.x)
        {
            animController.Play("back_L");
        }
        else if (angle >= 67.5 && angle < 112.5 && transform.position.x < Camera.main.transform.position.x)
        {
            animController.Play("side_L");
        }
        else if (angle >= 112.5 && angle < 157.5 && transform.position.x < Camera.main.transform.position.x)
        {
            animController.Play("front_L");
        }
        //right side
        else if (angle >= 22.5 && angle < 67.5 && transform.position.x > Camera.main.transform.position.x)
        {
            animController.Play("back_R");
        }
        else if (angle >= 67.5 && angle < 112.5 && transform.position.x > Camera.main.transform.position.x)
        {
            animController.Play("side_R");
        }
        else if (angle >= 112.5 && angle < 157.5 && transform.position.x > Camera.main.transform.position.x)
        {
            animController.Play("front_R");
        }
        //front
        else if (angle >= 157.5 && angle < 180)
        {
            animController.Play("front");
        }
      

    }
}
