using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuControl : MonoBehaviour
{
    PLayermovment script;
    public bool InShop;
    public GameObject Gshop;
    public GameObject player;
    public new GameObject camera;
    public GameObject shopspot;
    public GameObject Cameracontrol;
    public string LoadsceneRestart;
    // Start is called before the first frame update
    void Start()
    {
        script = player.GetComponent<PLayermovment>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape)&& InShop && !script.Dead)
        {
            camera.transform.parent = player.transform;
            camera.transform.position = player.transform.position;
            InShop = false;


        }
        else if(Input.GetKey(KeyCode.Escape)&& InShop && script.Dead)
        {
            camera.transform.parent = Cameracontrol.transform;
            camera.transform.position = Cameracontrol.transform.position;
            InShop = false;



        }



        
    }


    public void Restart()
    {
        SceneManager.LoadScene(LoadsceneRestart);
        script.Dead = false;
       
    }




    public void Shop()
    {
        camera.transform.parent = shopspot.transform;
        camera.transform.position = shopspot.transform.position;
        InShop = true;

      





    }



    public void Exit()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1) || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            if (PlayerPrefs.GetInt("punktyZapis") < MonetPickUp.Coinamount)
            {
                PlayerPrefs.SetInt("punktyZapis", Bank.MaxScore);
                PlayerPrefs.Save();
            }
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(4) || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(5))
        {
            if (PlayerPrefs.GetInt("HardModeScore") < MonetPickUp.Coinamount)
            {
                PlayerPrefs.SetInt("HardModeScore", Bank.MaxScore_HardMode);
                PlayerPrefs.Save();


            }

        }
        SceneManager.LoadScene("Mainmenu");

        

    }



    public void Resume()
    {
        script.Bpause = false;
        script.Pause.SetActive(false);
        Time.timeScale = 1.0f;



    }


    
}
