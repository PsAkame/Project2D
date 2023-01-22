using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Option_Controler : MonoBehaviour
{



    public Slider Mouse_Sens_Slider;
    public TextMeshProUGUI Mouse_Sens_Int;


    public Slider Gamma;
    public TextMeshProUGUI Gamma_Text_Int;

    public Toggle PostProcessing;
    
    // Start is called before the first frame update
    void Start()
    {

       
        Mouse_Sens_Slider.value = PlayerPrefs.GetInt("Mouse_Sens", 20);

        PlayerPrefs.GetInt("PostP", 1);

        Gamma.value =  PlayerPrefs.GetInt("Gamma",1);
        

        if (PlayerPrefs.GetInt("PostP") == 1)
        {
            PostProcessing.GetComponent<Toggle>().isOn = true;
        }
        else if(PlayerPrefs.GetInt("PostP") == 0)
        {
            PostProcessing.GetComponent<Toggle>().isOn = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
            {
                SceneManager.LoadScene(1);
                
                


            }
            else
            {

                SceneManager.LoadScene(0);
              
               
            }


        }

    }


    public void Mouse_Sens_Metod()
    {

        Player_Movment.MouseSpeed = Mouse_Sens_Slider.value;
        Mouse_Sens_Int.text = Mouse_Sens_Slider.value.ToString();
        PlayerPrefs.SetInt("Mouse_Sens", (int)Mouse_Sens_Slider.value);
        PlayerPrefs.Save();
    }

    public void Gamma_Metod()
    {
   
        Gamma_Text_Int.text = Gamma.value.ToString();
        PlayerPrefs.SetInt("Gamma", (int)Gamma.value);
        PlayerPrefs.Save();

    }

    public void Postprocessing()
    {
      
        if(PostProcessing.GetComponent<Toggle>().isOn == true)
        {
            PlayerPrefs.SetInt("PostP", 1);
            

        }
        else if(PostProcessing.GetComponent<Toggle>().isOn == false)
        {
            PlayerPrefs.SetInt("PostP", 0);
         
        }
       
        

    }
}
