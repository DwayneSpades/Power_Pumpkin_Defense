using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenShake : MonoBehaviour
{
    private float shakeTime, shakePower;

    public float _shakeTime,_shakePower;

    public float initialCamPosX;
    public float initialCamPosY;

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;//.GetComponent<GameObject>();
        initialCamPosX = cam.transform.position.x;
        initialCamPosY = cam.transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            startShaking(_shakeTime, _shakePower);
        }
    }

    private void LateUpdate()
    {   
        
        shakeTime -= 1 * Time.deltaTime;
        if (shakeTime >= 0)
        {
            float xShake = Random.Range(-1f, 1f) * shakePower;
            float yShake = Random.Range(-1f, 1f) * shakePower;

            cam.transform.position = new Vector3(initialCamPosX +xShake,initialCamPosY + yShake,  cam.transform.position.z);
            
        }
        else
        {
            cam.transform.position = new Vector3(initialCamPosX, initialCamPosY, cam.transform.position.z);

        }
    }

    public void startShaking(float length, float power)
    {
        shakeTime = length;
        shakePower = power;
    }
}
