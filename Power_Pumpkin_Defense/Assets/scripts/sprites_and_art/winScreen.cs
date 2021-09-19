using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        curTime = initialTime;
    }

    public float curTime;
    public float initialTime = 10.5f;

    public void runTimer()
    {
        curTime -= 1 * Time.deltaTime;

        if (curTime <= 0)
        {
            curTime = initialTime;
            execute();
        }
    }


    public int levelLimit = 4;
    public void execute()
    {
        Debug.Log("speed up!!!");

        
     
       gameManager.Instance.restartGame();
    }

    // Update is called once per frame
    void Update()
    {
        runTimer();
    }
}
