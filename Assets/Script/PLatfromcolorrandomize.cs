using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PLatfromcolorrandomize : MonoBehaviour
{
    [Header("Other Variable")]
    public int colornumber;
    public bool Startime;
    public float CoolDownClock = 10;
    public Image Clock;
   
    [Header("Platform 'Map'")]
    public GameObject Map1;
    public GameObject Map2;
    public GameObject Map3;
    public GameObject Map4;

    [Header("Color Platform")]
    public Material Red;
    public Material green;
    public Material yellow;
    public Material blue;
    public Material black;
    public Material Grey;


    [Header("Variable for HardMode")]
    public int colornumberH1;
    public int colornumberH2;
    public int colornumberH3;
    public int colornumberH4;

    int[] colornumberH = new int[4];
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Randomizenumber());
        Clock.fillAmount = 0;
        
        
      
    }

    // Update is called once per frame
    void Update()
    {








       

        ///////////////////////////////////////  TIMER TO CHANGE COLOR PLATFORM   /////////////////////////////////////////////////////////////////////
            Clock.fillAmount += 1 / CoolDownClock * Time.deltaTime;


        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1) || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            if (Clock.fillAmount >= 1)
            {
               
                colornumber = UnityEngine.Random.Range(0, 5);
                Clock.fillAmount = 0;

            }
        }


        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(4) || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(5))
        {
            if (Clock.fillAmount >= 1)
            {
              
                colornumberH1 = UnityEngine.Random.Range(0, 5);
                colornumberH2 = UnityEngine.Random.Range(0, 5);
                colornumberH3 = UnityEngine.Random.Range(0, 5);
                colornumberH4 = UnityEngine.Random.Range(0, 5);

                Clock.fillAmount = 0;

            }

            


        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////














        /////////////////////////////////////////Random color select and platform change color/////////////////////////////////////
        ///

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1) || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            CoolDownClock = 10f;

            switch (colornumber)
            {
                case 5:
                    Map1.GetComponent<SpriteRenderer>().material = Red;
                    Map2.GetComponent<SpriteRenderer>().material = Red;
                    Map3.GetComponent<SpriteRenderer>().material = Red;
                    Map4.GetComponent<SpriteRenderer>().material = Red;
                    break;
                case 4:
                    Map1.GetComponent<SpriteRenderer>().material = green;
                    Map2.GetComponent<SpriteRenderer>().material = green;
                    Map3.GetComponent<SpriteRenderer>().material = green;
                    Map4.GetComponent<SpriteRenderer>().material = green;
                    break;
                case 3:
                    Map1.GetComponent<SpriteRenderer>().material = yellow;
                    Map2.GetComponent<SpriteRenderer>().material = yellow;
                    Map3.GetComponent<SpriteRenderer>().material = yellow;
                    Map4.GetComponent<SpriteRenderer>().material = yellow;
                    break;
                case 2:
                    Map1.GetComponent<SpriteRenderer>().material = blue;
                    Map2.GetComponent<SpriteRenderer>().material = blue;
                    Map3.GetComponent<SpriteRenderer>().material = blue;
                    Map4.GetComponent<SpriteRenderer>().material = blue;
                    break;
                case 1:
                    Map1.GetComponent<SpriteRenderer>().material = black;
                    Map2.GetComponent<SpriteRenderer>().material = black;
                    Map3.GetComponent<SpriteRenderer>().material = black;
                    Map4.GetComponent<SpriteRenderer>().material = black;
                    break;
                case 0:
                    Map1.GetComponent<SpriteRenderer>().material = Grey;
                    Map2.GetComponent<SpriteRenderer>().material = Grey;
                    Map3.GetComponent<SpriteRenderer>().material = Grey;
                    Map4.GetComponent<SpriteRenderer>().material = Grey;
                    break;
            }
        }

        if(SceneManager.GetActiveScene()== SceneManager.GetSceneByBuildIndex(4) || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(5))
        {
            CoolDownClock = 5f;

            switch(colornumberH1)
            {

                case 5:
                    Map1.GetComponent<SpriteRenderer>().material = Red;


                    break;

                case 4:
                    Map1.GetComponent<SpriteRenderer>().material = green;


                    break;

                case 3:
                    Map1.GetComponent<SpriteRenderer>().material = yellow;


                    break;

                case 2:
                    Map1.GetComponent<SpriteRenderer>().material = blue;


                    break;

                case 1:
                    Map1.GetComponent<SpriteRenderer>().material = black;


                    break;


                case 0:

                    Map1.GetComponent<SpriteRenderer>().material = Grey;


                    break;



            }

            switch (colornumberH2)
            {

                case 5:
                    Map2.GetComponent<SpriteRenderer>().material = Red;


                    break;

                case 4:
                    Map2.GetComponent<SpriteRenderer>().material = green;


                    break;

                case 3:
                    Map2.GetComponent<SpriteRenderer>().material = yellow;


                    break;

                case 2:
                    Map2.GetComponent<SpriteRenderer>().material = blue;


                    break;

                case 1:
                    Map2.GetComponent<SpriteRenderer>().material = black;


                    break;


                case 0:

                    Map2.GetComponent<SpriteRenderer>().material = Grey;


                    break;



            }

            switch (colornumberH3)
            {

                case 5:
                    Map3.GetComponent<SpriteRenderer>().material = Red;


                    break;

                case 4:
                    Map3.GetComponent<SpriteRenderer>().material = green;


                    break;

                case 3:
                    Map3.GetComponent<SpriteRenderer>().material = yellow;


                    break;

                case 2:
                    Map3.GetComponent<SpriteRenderer>().material = blue;


                    break;

                case 1:
                    Map3.GetComponent<SpriteRenderer>().material = black;


                    break;


                case 0:

                    Map3.GetComponent<SpriteRenderer>().material = Grey;


                    break;



            }

            switch (colornumberH4)
            {

                case 5:
                    Map4.GetComponent<SpriteRenderer>().material = Red;


                    break;

                case 4:
                    Map4.GetComponent<SpriteRenderer>().material = green;


                    break;

                case 3:
                    Map4.GetComponent<SpriteRenderer>().material = yellow;


                    break;

                case 2:
                    Map4.GetComponent<SpriteRenderer>().material = blue;


                    break;

                case 1:
                    Map4.GetComponent<SpriteRenderer>().material = black;


                    break;


                case 0:

                    Map4.GetComponent<SpriteRenderer>().material = Grey;


                    break;



            }









        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       


        






    }

   

}
