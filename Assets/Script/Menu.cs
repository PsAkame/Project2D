using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public Button Play;
    public Button Option;
    public Button Tutorial;
    public Button Exit;


    public Animator Canvas;

    public GameObject MaxScore;






    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        MaxScore.GetComponent<TextMeshProUGUI>().text = "High Score: " + PlayerPrefs.GetInt("Score");


    }



   public void Play_Action()
    {
        SceneManager.LoadScene(1);
        Enemy_Spawn.Wave_Number = 1;
        // musi byæ tyle ile w skrypcie "Enemy_Spawn"
        Enemy_Spawn.Enemy_Amount = 1;
        Player_Movment.Kills = 0;


        //if (PlayerPrefs.GetInt("Score") == 0)
        //{
        //    SceneManager.LoadScene(6);
        //    Enemy_Spawn.Wave_Number = 1;
        //    // musi byæ tyle ile w skrypcie "Enemy_Spawn"
        //    Enemy_Spawn.Enemy_Amount = 1;
        //    Player_Movment.Kills = 0;
        //}
        //else
        //{
            
        //}


    }


   public void Option_Action()
    {
        Time.timeScale = 1f;
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
           
          
            SceneManager.LoadScene(3);

        }
        else
        {
            SceneManager.LoadScene(2);

        }

   

    }

   public void Tutorial_Action()
    {
        Time.timeScale = 1f;

        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            SceneManager.LoadScene(5);


        }
        else
        {
            SceneManager.LoadScene(4);
        }
        

    }
   

    public void Exit_Action()
    {
        Time.timeScale = 1;
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            SceneManager.LoadScene(0);

        }
        else
        {
            Application.Quit();

        }
       


    }


    public void Continue()
    {
        Time.timeScale = 1f;
        UI_Controler.Pause.SetActive(false);


    }

}
