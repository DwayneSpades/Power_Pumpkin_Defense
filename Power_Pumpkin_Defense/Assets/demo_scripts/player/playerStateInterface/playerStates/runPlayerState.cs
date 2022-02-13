using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class runPlayerState : i_PlayerState
{

    public void onEnter(player p)
    {
        p.animController.Play("run");
        //register action
        p.velocityHLmit = p.runningSpeedLimit;
        p.animController.speed = 1.5f;
    }

    public void onExit(player p)
    {
        //do something here    
        p.animController.speed = 1f;

        p.model.transform.localRotation = Quaternion.Euler(0,p.transform.rotation.y, 0);
        //deregister the actions for this input
    }
    Vector3 oldForward;
    float angleDif;
    public void update(player p)
    {

        //I want directional movemnet based on controller stick direction
        Matrix4x4 camRot = Matrix4x4.Rotate(Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0));

        //do something here


        if (p.leftStick != Vector2.zero)
        {
            p.velocityFWD += p.accelerationH * Time.deltaTime;

            if (p.velocityFWD >= p.velocityHLmit)
            {
                p.velocityFWD = p.velocityHLmit;
            }

            if (p.leftStick.x != 0)
            {
                //DP adventures style camera turning
                // not good if the player is supposed to shoot on the move for 3rd person shooter game
                //cam.targetAngleH += -(leftStick.x*camSpeed) * Time.deltaTime;
            }


            //the current forward needs to be relative to the camera's orientation

           
            p.currentForward = new Vector3(p.leftStick.x, 0, p.leftStick.y);
            p.currentForward.Normalize();

            

            float c2pAngle = Vector3.Angle(new Vector3(0, 0, 1), new Vector3(p.transform.forward.x, 0, p.transform.forward.z));

            if (Vector3.Dot(new Vector3(1, 0, 0), new Vector3(p.transform.forward.x, 0, p.transform.forward.z)) < 0)
            {
                p.targetAngle = (c2pAngle);
            }
            else
            {
                p.targetAngle = (360 - c2pAngle);
            }
            
            
            //new Matrix4x4(new Vector4(), transform.localToWorldMatrix.GetColumn(1), new Vector4(),new Vector4());
            p.transform.forward = camRot * p.currentForward;
          
        }
        else
        {
            p.switchStates(playerStates.idle); 
        }

        //remember the last direction input by the stick to keep facing that direction
        Vector3 direction = camRot * p.currentForward * p.velocityFWD * Time.deltaTime;
        
        // _rotation = Quaternion.Euler(direction);

        //_position = _position + direction ;

        //move horizontally
        p.transform.Translate(direction, Space.World);



        //falling
        falling(p);
    }

    public void falling(player p)
    {
        p.ray = new Ray(p.transform.position, -p.transform.up);
        Debug.DrawRay(p.transform.position, -p.transform.up, Color.blue);


        p.velocityUP -= p.deccelerationV * Time.deltaTime;
        if (p.velocityUP <= p.fallSpeed)
        {
            p.velocityUP = p.fallSpeed;
        }


        p.ray = new Ray(p.transform.position, -p.transform.up);



        if (Physics.Raycast(p.ray, out p.hit, p.footSensor))
        {
            Debug.DrawLine(p.ray.origin, p.hit.point);
            //Debug.Log(hit.collider.name);

            if (p.hit.collider.tag == "ground" && p.velocityUP <= 0)
            {
                p.transform.position = new Vector3(p.transform.position.x, p.hit.point.y + p.footResponce, p.transform.position.z);
                //p.transform.position = Vector3.Lerp(p.transform.position, new Vector3(p.transform.position.x, p.hit.point.y + p.footResponce, p.transform.position.z), p.footResponceRate * Time.deltaTime);
                p.velocityUP = 0;
                p.onGround = true;

                
            }
        }
        else
        {
            Debug.Log("not touching ground");
            p.switchStates(playerStates.activeAir);
        }

        Vector3 directionUp = new Vector3(0, 1, 0) * p.velocityUP * Time.deltaTime;

        //move vertically
        p.transform.Translate(directionUp, Space.World);
    }
}
