using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_Until_Next_Wave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Wave_Mngr = GameObject.Find("Wave_Manager");
        Cooldown_Time = Wave_Mngr.GetComponent<Wave_Manager>().Get_Wave_Cooldown_Time();

        Wave_Cooldown_Timer_Display.text = "Time until next wave: " + Cooldown_Time;

        StartCoroutine(Cooldown_Tick(Cooldown_Time));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set_Canvas_Ref(Canvas c)
    {
        UI_Canvas_Ref = c;
    }

    private void Update_Cooldown_Timer_Display(float Time_Left)
    {
        Cooldown_Time = Time_Left;
        Wave_Cooldown_Timer_Display.text = "Time until next wave: " + Cooldown_Time;
    }

    IEnumerator Cooldown_Tick(float Cooldown_Time)
    {
        yield return new WaitForSeconds(1);

        Cooldown_Time--;

        if (Cooldown_Time < 1.0f)
        {
            Text test = Instantiate(Wave_Start_Display) as Text;
            test.transform.SetParent(UI_Canvas_Ref.transform, false);

            Destroy(this.gameObject);
        }
        else
        {
            Update_Cooldown_Timer_Display(Cooldown_Time);
            StartCoroutine(Cooldown_Tick(Cooldown_Time));
        }
    }

    private Canvas UI_Canvas_Ref;

    [SerializeField] private Text Wave_Cooldown_Timer_Display;

    [SerializeField] private Text Wave_Start_Display;

    private float Cooldown_Time;

    private GameObject Wave_Mngr;

    
}
