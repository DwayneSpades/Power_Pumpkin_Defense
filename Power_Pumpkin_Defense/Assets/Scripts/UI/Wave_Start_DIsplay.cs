using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wave_Start_DIsplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Wave_Start_Test.text = "Wave Start!";
        StartCoroutine(Time_To_Destroy(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Time_To_Destroy(float time)
    {
        yield return new WaitForSeconds(time);

        //this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }

    [SerializeField] private Text Wave_Start_Test;
}
