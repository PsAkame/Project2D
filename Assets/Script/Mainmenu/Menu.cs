using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    public Animator Playbutton;
    public Animator Polishbutton;
    public Animator Englishbutton;
    public AudioSource Menumusic;
    public GameObject Language;
    public GameObject LanguageHM;
    public GameObject PlayButton;
    public GameObject HardModeButton;

    public static GameObject MaxScoreText;
    public static GameObject MaxScoreHardModeText;

    // Start is called before the first frame update
    void Start()
    {
        
        if (PlayerPrefs.GetString("HardMode") == "Unlock")
        {
            Shop.HardMode = true;

        }



        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            Menumusic.Play();


        }

        MaxScoreText = GameObject.Find("HighScore");
        MaxScoreHardModeText = GameObject.Find("HighScoreHardMode");

        Bank.MaxScore = PlayerPrefs.GetInt("punktyZapis");
        Bank.MaxScore_HardMode = PlayerPrefs.GetInt("HardModeScore");

    }

    // Update is called once per frame
    void Update()
    {
       


        if (Shop.HardMode == true)
        {
            HardModeButton.SetActive(true);
            MaxScoreHardModeText.SetActive(true);


        }

        else
        {

            HardModeButton.SetActive(false);
            MaxScoreHardModeText.SetActive(false);
        }



        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            Time.timeScale = 1f;

        }

        MaxScoreText.GetComponent<TextMeshProUGUI>().text = "Maxscore: " + Bank.MaxScore;
        MaxScoreHardModeText.GetComponent<TextMeshProUGUI>().text = "Maxscore: " + Bank.MaxScore_HardMode;



    }






   public void Play()
    {
        
        
        Playbutton.SetTrigger("Playbutton");
        Polishbutton.SetTrigger("Polishbutton");
        Englishbutton.SetTrigger("Englishbutton");
        



    }



    public void Tutorial()
    {
        SceneManager.LoadScene(3);
        

    }




    public void Exit()
    {
        Application.Quit();


    }


    


   

    



}
