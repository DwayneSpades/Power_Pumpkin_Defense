using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class idlePlayerState : i_PlayerState
{
    public float walkingSpeedLimit = 8;

    public void onEnter(player p)
    {

        p.animController.Play("idle");
        //register action
        p.velocityHLmit = walkingSpeedLimit;
    }

    public void onExit(player p)
    {
        //do something here    
        //deregister the actions for this input
    }

    public void update(player p)
    {
        //do something here
        //Read Input From Player
        
        if(p.leftStick != Vector2.zero)
        {
            Debug.Log("walking");
            p.switchStates(playerStates.walking);
        }

        //slow player down to halt
        p.velocityFWD -= p.deccelerationH * Time.deltaTime;
        if (p.velocityFWD <= 0)
        {
            p.velocityFWD = 0;
        }

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
                p.transform.position = Vector3.Lerp(p.transform.position, new Vector3(p.transform.position.x, p.hit.point.y + p.footResponce, p.transform.position.z), p.footResponceRate);
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
