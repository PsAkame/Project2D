using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Tutorial : MonoBehaviour
{
    public float Tutorialstage;
    public bool Polish;
    public bool English;
    public GameObject Stage1P;
    public GameObject Stage2P;
    public GameObject Stage3P;
    public GameObject Stage4P;
    public GameObject Stage5P;
    public GameObject Stage6P;



    public GameObject Stage1E;
    public GameObject Stage2E;
    public GameObject Stage3E;
    public GameObject Stage4E;
    public GameObject Stage5E;
    public GameObject Stage6E;
    public GameObject BNext;
    public GameObject BBack;
    public GameObject ExittuP;
    public GameObject ExittuE;
    public GameObject Polski;
    public GameObject Angieslki;
  

    // Start is called before the first frame update
    void Start()
    {
        Tutorialstage = 1f;
        Polish = true;
        Polski.SetActive(false);
        Angieslki.SetActive(true);
      
        
    }

    // Update is called once per frame
    void Update()
    {


        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3) && Input.GetKey(KeyCode.Escape))

        {
            SceneManager.LoadScene(0);



        }


        switch (Tutorialstage)
        {
            case 1:
                if (Polish)
                {
                    Stage2P.SetActive(false);
                    Stage3P.SetActive(false);
                    Stage4P.SetActive(false);
                    Stage1P.SetActive(true);

                    Stage2E.SetActive(false);
                    Stage3E.SetActive(false);
                    Stage4E.SetActive(false);
                    Stage1E.SetActive(false);


                    BBack.SetActive(false);
                    BNext.SetActive(true);
                }

                if (English)
                {
                    Stage2E.SetActive(false);
                    Stage3E.SetActive(false);
                    Stage4E.SetActive(false);
                    Stage1E.SetActive(true);



                    Stage2P.SetActive(false);
                    Stage3P.SetActive(false);
                    Stage4P.SetActive(false);
                    Stage1P.SetActive(false);


                    BBack.SetActive(false);
                    BNext.SetActive(true);



                }



                break;

            case 2:
                if (Polish)
                {
                    Stage1P.SetActive(false);
                    Stage3P.SetActive(false);
                    Stage4P.SetActive(false);
                    Stage2P.SetActive(true);

                    Stage1E.SetActive(false);
                    Stage3E.SetActive(false);
                    Stage4E.SetActive(false);
                    Stage2E.SetActive(false);


                    BBack.SetActive(true);
                    BNext.SetActive(true);
                }


                if (English)
                {
                    Stage1E.SetActive(false);
                    Stage3E.SetActive(false);
                    Stage4E.SetActive(false);
                    Stage2E.SetActive(true);

                    Stage1P.SetActive(false);
                    Stage3P.SetActive(false);
                    Stage4P.SetActive(false);
                    Stage2P.SetActive(false);


                    BBack.SetActive(true);
                    BNext.SetActive(true);

                }



                break;


            case 3:

                if (Polish)
                {
                    Stage1P.SetActive(false);
                    Stage2P.SetActive(false);
                    Stage4P.SetActive(false);
                    Stage3P.SetActive(true);

                    Stage1E.SetActive(false);
                    Stage2E.SetActive(false);
                    Stage4E.SetActive(false);
                    Stage3E.SetActive(false);

                    BBack.SetActive(true);
                    BNext.SetActive(true);
                }

                if (English)
                {
                    Stage1E.SetActive(false);
                    Stage2E.SetActive(false);
                    Stage4E.SetActive(false);
                    Stage3E.SetActive(true);

                    Stage1P.SetActive(false);
                    Stage2P.SetActive(false);
                    Stage4P.SetActive(false);
                    Stage3P.SetActive(false);

                    BBack.SetActive(true);
                    BNext.SetActive(true);


                }


                break;



            case 4:
                if (Polish)
                {
                    Stage1P.SetActive(false);
                    Stage2P.SetActive(false);
                    Stage3P.SetActive(false);
                    Stage4P.SetActive(true);
                    Stage5P.SetActive(false);

                    Stage1E.SetActive(false);
                    Stage2E.SetActive(false);
                    Stage3E.SetActive(false);
                    Stage4E.SetActive(false);

                    BBack.SetActive(true);
                    BNext.SetActive(true);
                    ExittuP.SetActive(true);
                    ExittuE.SetActive(false);
                }


                if (English)
                {
                    Stage1E.SetActive(false);
                    Stage2E.SetActive(false);
                    Stage3E.SetActive(false);
                    Stage4E.SetActive(true);
                    Stage5E.SetActive(false);

                    Stage1P.SetActive(false);
                    Stage2P.SetActive(false);
                    Stage3P.SetActive(false);
                    Stage4P.SetActive(false);

                    BBack.SetActive(true);
                    BNext.SetActive(true);
                    ExittuE.SetActive(true);
                    ExittuP.SetActive(false);



                }


                break;



            case 5:

                if (Polish)
                {
                    Stage1P.SetActive(false);
                    Stage2P.SetActive(false);
                    Stage3P.SetActive(false);
                    Stage4P.SetActive(false);
                    Stage5P.SetActive(true);
                    Stage6P.SetActive(false);

                    Stage1E.SetActive(false);
                    Stage2E.SetActive(false);
                    Stage3E.SetActive(false);
                    Stage4E.SetActive(false);
                    Stage5E.SetActive(false);
                    Stage6E.SetActive(false);

                    BBack.SetActive(true);
                    BNext.SetActive(true);
                    ExittuP.SetActive(true);
                    ExittuE.SetActive(false);
                }

                if(English)
                {
                    Stage1E.SetActive(false);
                    Stage2E.SetActive(false);
                    Stage3E.SetActive(false);
                    Stage4E.SetActive(false);
                    Stage5E.SetActive(true);
                    Stage6E.SetActive(false);

                    Stage1P.SetActive(false);
                    Stage2P.SetActive(false);
                    Stage3P.SetActive(false);
                    Stage4P.SetActive(false);
                    Stage5P.SetActive(false);
                    Stage6P.SetActive(false);

                    BBack.SetActive(true);
                    BNext.SetActive(true);
                    ExittuE.SetActive(true);
                    ExittuP.SetActive(false);




                }

                break;



            case 6:
                if(Polish)
                {

                    Stage1P.SetActive(false);
                    Stage2P.SetActive(false);
                    Stage3P.SetActive(false);
                    Stage4P.SetActive(false);
                    Stage5P.SetActive(false);
                    Stage6P.SetActive(true);

                    Stage1E.SetActive(false);
                    Stage2E.SetActive(false);
                    Stage3E.SetActive(false);
                    Stage4E.SetActive(false);
                    Stage5E.SetActive(false);
                    Stage6E.SetActive(false);

                    BBack.SetActive(true);
                    BNext.SetActive(false);
                    ExittuP.SetActive(true);
                    ExittuE.SetActive(false);



                }

                if(English)
                {

                    Stage1E.SetActive(false);
                    Stage2E.SetActive(false);
                    Stage3E.SetActive(false);
                    Stage4E.SetActive(false);
                    Stage5E.SetActive(false);
                    Stage6E.SetActive(true);

                    Stage1P.SetActive(false);
                    Stage2P.SetActive(false);
                    Stage3P.SetActive(false);
                    Stage4P.SetActive(false);
                    Stage5P.SetActive(false);
                    Stage6P.SetActive(false);
                   

                    BBack.SetActive(true);
                    BNext.SetActive(false);
                    ExittuE.SetActive(true);
                    ExittuP.SetActive(false);


                }


                break;
        }


        
    }

    public void Next()
    {
        if (Tutorialstage < 6)
        {
            Tutorialstage += 1;
        }

    }

    public void Back()
    {
        if (Tutorialstage > 0)
        {
            Tutorialstage -= 1;
        }


    }


    public void England()
    {
        English = true;
        Polish = false;

        Polski.SetActive(true);
        Angieslki.SetActive(false);
    }

    public void Poland()
    {
        Polish = true;
        English = false;

        Angieslki.SetActive(true);
        Polski.SetActive(false);


    }
}
