using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PLayermovment : MonoBehaviour
{
    [Header("Float")]
    public float x;
    public float speed;
    public float jumpforce;
    public float jumpforce2;
    public float colornumber2;
    private float ColldownDoubleJump = 20f;


    [Header("Bool")]
    [Space(10)]
    public bool grouned;
    public bool Dead;
    public bool Bpause;


    [Header("Image")]
    [Space(10)]
    public Image DoubleJumpImage;


    [Header("Transform")]
    [Space(10)]
    public Transform Camera;
    public Transform PLayer;


    [Header("Animator")]
    [Space(10)]
    public Animator anim;
    public Animator animmenu;

    [Header("Material")]
    [Space(10)]
    public Material Red;
    public Material green;
    public Material yellow;
    public Material blue;
    public Material black;
    public Material Grey;    

    [Header("GameObject")]
    [Space(10)]
    public GameObject platform;
    public GameObject PlayeraGO;
    public GameObject Cameracontrol;
    public GameObject Pause;
    public GameObject Ground;

    [Header("AudioSorce")]
    [Space(10)]
    public AudioSource jump;
    public AudioSource Mainmusic;

    [Header("AnotherScript")]
    [Space(10)]
    PLatfromcolorrandomize script;
    Bank script2;
    Grouned script3;
    // Start is called before the first frame update
    void Start()
    {
        script = platform.GetComponent<PLatfromcolorrandomize>();
        script3 = Ground.GetComponent<Grouned>();
        Mainmusic.GetComponent<AudioSource>().pitch = 1;
        Mainmusic.Play();




       




    }

    // Update is called once per frame
    void Update()
    {



        









        if(Input.GetKey(KeyCode.Escape))
        {
            Bpause = true;
            Pause.SetActive(true);
            Time.timeScale = 0.2f;


        }



        





        /////////////////////////////////PLAYER MOVMENT/////////////////////////////////////////////////////////////////
        x = Input.GetAxis("Horizontal");

        PLayer.Translate(x * speed * Time.deltaTime, 0, 0);




        //////////////////////////////////////////////////////////////////////////////////////////////////////////////






        ////////////////////////////////DEAD OTHER COLOR///////////////////////////////////////////////////////////////////
        ///
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1) || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            if (colornumber2 != script.colornumber && grouned)
            {
                Mainmusic.GetComponent<AudioSource>().pitch = 0.7f;
                PlayeraGO.SetActive(false);
                Camera.transform.parent = Cameracontrol.transform;
                Dead = true;
                animmenu.SetBool("Dead", Dead);
                
           


            }
        }




        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(4) || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(5))
        {
            if (grouned)
            {
                if (script3.platform.gameObject.name == "Mapa1" && colornumber2 != script.colornumberH1)
                {
                    Mainmusic.GetComponent<AudioSource>().pitch = 0.7f;
                    PlayeraGO.SetActive(false);
                    Camera.transform.parent = Cameracontrol.transform;
                    Dead = true;
                    animmenu.SetBool("Dead", Dead);
                   
                }

                if (script3.platform.gameObject.name == "Mapa2" && colornumber2 != script.colornumberH2)
                {
                    Mainmusic.GetComponent<AudioSource>().pitch = 0.7f;
                    PlayeraGO.SetActive(false);
                    Camera.transform.parent = Cameracontrol.transform;
                    Dead = true;
                    animmenu.SetBool("Dead", Dead);
                  


                }

                if (script3.platform.gameObject.name == "Mapa3" && colornumber2 != script.colornumberH3)
                {
                    Mainmusic.GetComponent<AudioSource>().pitch = 0.7f;
                    PlayeraGO.SetActive(false);
                    Camera.transform.parent = Cameracontrol.transform;
                    Dead = true;
                    animmenu.SetBool("Dead", Dead);
                   



                }

                if (script3.platform.gameObject.name == "Mapa4" && colornumber2 != script.colornumberH4)
                {

                    Mainmusic.GetComponent<AudioSource>().pitch = 0.7f;
                    PlayeraGO.SetActive(false);
                    Camera.transform.parent = Cameracontrol.transform;
                    Dead = true;
                    animmenu.SetBool("Dead", Dead);
                  

                }




            }


        }









        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
















        ////////////////////////////////JUMP /////////////////////////////////////////////////////////////////
        if (Input.GetKey(KeyCode.Space) && grouned)
        {
            PLayer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpforce);
            jump.Play();
            

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        











        //////////////////////////////DOUBLE JUMP/////////////////////////////////////////////////////////////////
        
        
        
            DoubleJumpImage.fillAmount += 1 / ColldownDoubleJump * Time.deltaTime;
           
        


        if (Input.GetKey(KeyCode.W)&&  DoubleJumpImage.fillAmount >= 1)
        {
            PLayer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpforce2);
            jump.Play();
            DoubleJumpImage.fillAmount = 0;
        }





        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        






















        /////////////////////// Random number = Random color/////////////////////////////////


        if (Input.GetKey(KeyCode.Alpha1))
        {
            colornumber2 = 5;
            
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            colornumber2 = 4;
            
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            colornumber2 = 3;
            
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            colornumber2 = 2;
           
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            colornumber2 = 1;
           
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            colornumber2 = 0;
            
        }

        switch(colornumber2)
        {
            case 5:
                PLayer.GetComponent<SpriteRenderer>().material = Red;
                break;
            case 4:
                PLayer.GetComponent<SpriteRenderer>().material = green;
                break;
            case 3:
                PLayer.GetComponent<SpriteRenderer>().material = yellow;
                break;
            case 2:
                PLayer.GetComponent<SpriteRenderer>().material = blue;
                break;
            case 1:
                PLayer.GetComponent<SpriteRenderer>().material = black;
                break;
            case 0:
                PLayer.GetComponent<SpriteRenderer>().material = Grey;
                break;
        }


        /////////////////////////////////////////////////////////////////////////////////////
    }











    ////////// Enter to DEAD collider ////////////////////////////

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "DeadTag")
        {
            PlayeraGO.SetActive(false);
            Camera.transform.parent = Cameracontrol.transform;
            Dead = true;
            animmenu.SetBool("Dead", Dead);
            
        }
    }

    //////////////////////////////////////////////////////////////

    



    
}
