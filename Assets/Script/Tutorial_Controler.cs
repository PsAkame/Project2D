using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial_Controler : MonoBehaviour
{


  
    public GameObject[] Stages = new GameObject[5];

    int Stage;

    
    // Start is called before the first frame update
    void Start()
    {
        Stage = 1;
       
    }

    // Update is called once per frame
    void Update()
    {
        Stage = Mathf.Clamp(Stage, 1, 5);

        if(Input.GetKey(KeyCode.Escape))
        {
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(5))
            {
                SceneManager.LoadScene(1);
    

            }
            else
            {

                SceneManager.LoadScene(0);
            }

        }



        switch (Stage)
        {

            case 1:
                Stages[0].SetActive(true);
                Stages[1].SetActive(false);
                Stages[2].SetActive(false);
                Stages[3].SetActive(false);
                Stages[4].SetActive(false);
             
                


                break;

            case 2:
                Stages[0].SetActive(false);
                Stages[1].SetActive(true);
                Stages[2].SetActive(false);
                Stages[3].SetActive(false);
                Stages[4].SetActive(false);
             

                break;


            case 3:
                Stages[0].SetActive(false);
                Stages[1].SetActive(false);
                Stages[2].SetActive(true);
                Stages[3].SetActive(false);
                Stages[4].SetActive(false);
             






                break;


            case 4:
                Stages[0].SetActive(false);
                Stages[1].SetActive(false);
                Stages[2].SetActive(false);
                Stages[3].SetActive(true);
                Stages[4].SetActive(false);
              


                break;


            case 5:

                Stages[0].SetActive(false);
                Stages[1].SetActive(false);
                Stages[2].SetActive(false);
                Stages[3].SetActive(false);
                Stages[4].SetActive(true);
                

                break;

        }


        
    }


   public void Left_Action()
    {
        Stage -= 1;



    }

   public void Right_Action()
    {
       
        Stage += 1;



    }
}
