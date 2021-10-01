using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Resource_Mngr = GameObject.Find("Resource_Manager");
        Plant_Mngr = GameObject.Find("Plant_Manager");
        Spell_Manager = GameObject.Find("Spell_Manager");
        Effect_Manager = GameObject.Find("Effect_Manager");

        Game_PauseMenu_Active = false;

        Spell_Icon_Index = 0;
        Plant_Icon_Index = 0;

        WaterReady_Check = true;
        SpellReady_Check = true;

        // Set Active gameobjects for plant/spell icons to show first one
        //Spell_Icon_List[Spell_Icon_Index].SetActive(true);
        //Plant_Icon_List[Plant_Icon_Index].SetActive(true);

        Current_Mana = Resource_Mngr.GetComponent<Resource_Manager>().Get_Current_Mana();
        Current_Water = Resource_Mngr.GetComponent<Resource_Manager>().Get_Current_Water();

        //Update_Current_Mana(Current_Mana);
        //Update_Current_Water(Current_Water);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            // If menu is up, close menu - If menu is not up, open menu
            if (Game_PauseMenu_Active)
            {
                Game_PauseMenu_Active = false;
                InGame_Pause_Menu.GetComponent<InGame_PauseMenu_Script>().UnPause_Game();
                InGame_Pause_Menu.SetActive(false);
            }
            else
            { 
                Game_PauseMenu_Active = true;
                InGame_Pause_Menu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public int Get_Current_Mane()
    {
        return Current_Mana;
    }

    public int Get_Current_Water()
    {
        return Current_Water;
    }

    public void Update_Current_Mana(int m)
    {
        Current_Mana = m;
        ManaBar.GetComponent<Mana_Bar>().Update_Mana_Value(m);
    }

    public void Update_Max_Mana(int m)
    {
        ManaBar.GetComponent<Mana_Bar>().Update_Max_Mana_Value(m);
    }

    public void Update_Current_Water(int w)
    {
        Current_Water = w;
        WaterBar.GetComponent<Water_Bar>().Update_Water_Value(w);
    }

    public void Update_Max_Water(int w)
    {
        WaterBar.GetComponent<Water_Bar>().Update_Max_Water_Value(w);
    }

    public void Update_Current_GreatPumpkinHealth(float h)
    {
        GreatPumpkin_HealthBar.GetComponent<GreatPumpkin_HealthBar>().Update_Health_Value(h);
    }

    public void Update_Max_GreatPumpkinHealth(float h)
    {
        GreatPumpkin_HealthBar.GetComponent<GreatPumpkin_HealthBar>().Update_Max_Health_Value(h);
    }



    public void Cycle_Plant_Icon()
    {
        // Set old icon object to false so it doesn't show
        Plant_Icon_List[Plant_Icon_Index].SetActive(false);

        if (Plant_Icon_Index >= (Plant_Icon_List.Count - 1))
        {
            Plant_Icon_Index = 0;
        }
        else
        {
            Plant_Icon_Index++;
        }

        // Set new icon object to true so it now shows
        Plant_Icon_List[Plant_Icon_Index].SetActive(true);
    }

    public void Cycle_Spell_Icon()
    {
        Spell_Icon_List[Spell_Icon_Index].SetActive(false);

        if (Spell_Icon_Index >= (Spell_Icon_List.Count - 1))
        {
            Spell_Icon_Index = 0;
        }
        else
        {
            Spell_Icon_Index++;
        }

        Spell_Icon_List[Spell_Icon_Index].SetActive(true);
    }

    public void Update_WaterReady_Icon_Status(bool status)
    {
        WaterReady_Check = status;

        if (WaterReady_Check)
        {
            WaterReady_Icon.SetActive(WaterReady_Check);
        }
        else
        {
            WaterReady_Icon.SetActive(WaterReady_Check);
        }
    }

    public void Update_SpellReady_Icon_Status(bool status)
    {
        SpellReady_Check = status;

        if (SpellReady_Check)
        {
            SpellReady_Icon.SetActive(SpellReady_Check);
        }
        else
        {
            SpellReady_Icon.SetActive(SpellReady_Check);
        }
    }

    public void Display_Win_Text()
    {
        Win_Text.SetActive(true);
    }

    public void Display_Wave_Cooldown()
    {
        //Time_To_Next_Wave_Display.SetActive(true);
        Text test = Instantiate(Time_To_Next_Wave_Display) as Text;
        test.transform.SetParent(UI_Canvas_Ref.transform, false);
        test.GetComponent<Time_Until_Next_Wave>().Set_Canvas_Ref(UI_Canvas_Ref);
        //GameObject.Find("UI_Canvas")
    }

    public void Display_Wave_Num(int wave)
    {
        Wave_Num_Display.GetComponent<Wave_Display>().Update_Display_Current_Wave(wave);
    }

    private GameObject Resource_Mngr;
    private GameObject Plant_Mngr;
    private GameObject Spell_Manager;
    private GameObject Effect_Manager;

    [SerializeField] private List<GameObject> Spell_Icon_List;
    private int Spell_Icon_Index;

    [SerializeField] private List<GameObject> Plant_Icon_List;
    private int Plant_Icon_Index;

    private int Current_Mana;
    private int Current_Water;

    [SerializeField] private Canvas UI_Canvas_Ref;

    [SerializeField] private GameObject ManaBar;
    [SerializeField] private GameObject WaterBar;
    [SerializeField] private GameObject GreatPumpkin_HealthBar;

    [SerializeField] private GameObject Wave_Num_Display;
    [SerializeField] private Text Time_To_Next_Wave_Display;

    [SerializeField] private GameObject WaterReady_Icon;
    [SerializeField] private GameObject SpellReady_Icon;

    [SerializeField] private GameObject InGame_Pause_Menu;
    private bool Game_PauseMenu_Active;

    [SerializeField] private GameObject Win_Text;

    private bool WaterReady_Check;
    private bool SpellReady_Check;
}
