using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseAim : MonoBehaviour
{



    public Vector3 targetPosition;
    public Vector3 newDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnDrawGizmos()
    {
       

        Gizmos.DrawSphere(targetPosition, 0.5f);
    }
    // Update is called once per frame
    void Update()
    {
        
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(r, out hit, 100.0f))
        {
            //draw invisible ray cast/vector
            Debug.DrawLine(r.origin, hit.point,Color.yellow);
        }
        targetPosition = hit.point;

        RaycastHit hit2;

        newDir =  hit.point-transform.position;
        newDir.Normalize();

        if (Physics.Raycast(transform.position,newDir, out hit2,100.0f))
        {
            //draw invisible ray cast/vector
            Debug.DrawLine(transform.position, hit2.point,Color.red);
            
        }

        //Vector3 mouseRayPos = Ray()
    }
}
