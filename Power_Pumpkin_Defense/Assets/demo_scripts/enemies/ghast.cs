using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghast : MonoBehaviour
{


    public float health = 20;


    void OnCollisionEnter(Collision collision)
    {
        
        
        if (collision.gameObject.tag == "pumpkin")
        {
            Debug.Log("HIT");
            health -= collision.gameObject.GetComponent<pumpkinBlast>().damageAmaount;

            if(health<=0)
                Destroy(gameObject);
        }
    }
}
