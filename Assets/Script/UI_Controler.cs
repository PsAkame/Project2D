using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class UI_Controler : MonoBehaviour
{
    public static GameObject Wave;
    public static GameObject Enemy_Arrive;
    public static GameObject Kills_Amount;

    public static GameObject Stamina_Bar;
    public static Slider Stamina_Fill;

    public static GameObject Health_Bar;
    public static Slider Health_Fill;


    public static GameObject Pause;

    public static GameObject Stamina_Wheel;
    public static Image Stamina_Wheel_Fill;






    // Start is called before the first frame update
    void Start()
    {
        Wave = GameObject.Find("Wave");
        Enemy_Arrive = GameObject.Find("Enemy_Amount");
        Kills_Amount = GameObject.Find("Kill_Amount");

      

        Stamina_Bar = GameObject.Find("SFrame_Bar");
        Stamina_Fill =Stamina_Bar.GetComponent<Slider>();

        Health_Bar = GameObject.Find("HFrame_Bar");
        Health_Fill = Health_Bar.GetComponent<Slider>();


        Pause = GameObject.Find("Menu");
        Pause.SetActive(false);

        Stamina_Wheel = GameObject.Find("Stamina_Effect");
        Stamina_Wheel_Fill = Stamina_Wheel.GetComponent<Image>();






    }

    // Update is called once per frame
    void Update()
    {
     




    }


    public static void TextModifer()
    {
        Wave.GetComponent<TextMeshProUGUI>().text = "Fala:" + Enemy_Spawn.Wave_Number;
        Enemy_Arrive.GetComponent<TextMeshProUGUI>().text = "Przeciwnicy:" + Enemy_Spawn.Enemy_Amount;
        Kills_Amount.GetComponent<TextMeshProUGUI>().text = "Zabójstwa:" + Player_Movment.Kills;

      
      



    }
    // Na razie co
    //public static void HealthAndStamina(float max)
    //{
    //    Stamina_Fill.value -= max * Time.deltaTime;
    //    Health_Fill.value = Player_Movment.Health;

    //}
}
