using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpkinBlast : MonoBehaviour
{

    float throwDirectionX;
 
    float velocitySide = 0;
    float velocityUp = 0;
    float velocityFWD = 0;

    float deccelerationRate = 50;

    float scale = 1;
    public float growthRate = 0.05f;

    public GameObject arm;
    bool released = false;
    // Start is called before the first frame update
    void Start()
    {
        released = false;
    }


    

    void grow()
    {
        transform.position = arm.transform.position;
        transform.localScale = new Vector3(scale,scale,scale);
        scale += growthRate*Time.deltaTime;

    }

    public void shoot()
    {
        released = true;
    }

    // Update is called once per frame
    void Update()
    {
        //decrease all tradjectories
        //slow player down to halt
        if(!released)
        {
            grow();
        } 
        else
        {
            velocityUp -= deccelerationRate * Time.deltaTime;
            transform.position += transform.forward * 80 * Time.deltaTime;
            transform.position += transform.up * velocityUp * Time.deltaTime;
        }

        
        //transform.position += new Vector3(throwDirectionX,0,0) * velocitySide * Time.deltaTime;


    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag!="Player" )
            Destroy(gameObject);
    }
}
