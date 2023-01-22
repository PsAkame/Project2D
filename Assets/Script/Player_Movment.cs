using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Player_Movment : MonoBehaviour
{

    [Header("GameObject")]

    public Transform Player;
    public GameObject Check_Point;
    public GameObject Attack_Point;
    public GameObject Effect_Speed;

    public GameObject Camera;
    public GameObject Normal_Camera_Position;
    public GameObject Attack_Camera_Position;

    public GameObject Camera_Xray;

    public static GameObject Stamina_Bar;

    public static GameObject Light_Power;




    [Header("int")]
    public static int Kills = 0;
    



    [Header("Float")]

    public static float Health;
    public static float Damage;

    public float x;
    public float y;

    public float MouseX;
    public float MouseY;
    public static float MouseSpeed;

    public float Speed_Walk;
    public float Speed_Sprint;
    public float Attack_Size;

    float Waiting;

  


    [Header("LayerMask")]

    public LayerMask Enemy_50;
    public LayerMask Enemy_100;


    [Header("Sprites")]

    public Sprite X;
    public Sprite Y;


    [Header("Collider")]

    public Collider BackColid;
    public Collider FrontColid;

    [Header("Material")]

    public Material Enemy_Mat;
    public Material Player_Mat;

    [Header("Postprocessing")]

    public VolumeProfile Hp_Blind;
    public Vignette Vignette;


    [Header("Animator")]

    public Animator Knife_Anim;
    public Animator Player_Anim;

    [Header("Slider")]

    Slider Stamina_Fill;


    [Header("Image")]

    public Image Fill_Image;


    [Header("Color")]
    Color Normal_Color = new Color(255, 255, 255);
    Color Exhaust_Color = new Color(255, 0, 14);
 

    [Header("AudioSorce")]

    public AudioSource[] Audio_Conteiner = new AudioSource[4];




    [Header("Component")]

    public Component BeatHeard;

    




    [Header("Bool")]
    // Power_Up
    bool Stamina_Endless;


    // Start is called before the first frame update
    void Start()
    {
        Health = 100;
        Damage = 0;
        Stamina_Bar = GameObject.Find("SFrame_Bar");
        Stamina_Fill = Stamina_Bar.GetComponent<Slider>();
        Light_Power = GameObject.Find("Directional Light");
        MouseSpeed = PlayerPrefs.GetInt("Mouse_Sens");

        Light_Power.GetComponent<Light>().intensity = PlayerPrefs.GetInt("Gamma");
        Postprocessing_On_Off();


    }

    // Update is called once per frame
    void Update()
    {

        if((x>0 || y>0) ||(x<0 || y<0))
        {
            Player_Anim.SetBool("Walk", true);

        }
        else
        {
            Player_Anim.SetBool("Walk", false);
        }

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        Player.Translate(0, 0, -x * Speed_Walk * Time.deltaTime);
        Player.Translate(y * Speed_Walk * Time.deltaTime, 0, 0);


        MouseX = Input.GetAxis("Mouse X");
        Player.localEulerAngles += new Vector3(0, MouseX * MouseSpeed * Time.deltaTime, 0);




        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            UI_Controler.Pause.SetActive(true);



        }


        if (Input.GetKey(KeyCode.LeftShift) && Waiting > 0.2f && Stamina_Fill.value > 0 && (x != 0 || y != 0) && (Fill_Image.color == Normal_Color || Stamina_Endless))
        {
            Effect_Speed.SetActive(true);
            if (!Stamina_Endless)
            {
                Speed_Sprint = Health * 0.12f;
                Stamina_Fill.value -= 16 * Time.deltaTime;
            }
          
            Player.Translate(0, 0, -x * Speed_Sprint * Time.deltaTime);
            Player.Translate(y * Speed_Sprint * Time.deltaTime, 0, 0);
            Player_Anim.SetBool("Run", true);
            UI_Controler.Stamina_Wheel_Fill.fillAmount -= 0.17f * Time.deltaTime;



            //
            // na wrazie co
            //UI_Controler.HealthAndStamina(12);
            //




        }
        else if (Stamina_Fill.value < 100 || Stamina_Endless)
        {

            Effect_Speed.SetActive(false);
            Player_Anim.SetBool("Run", false);
            Stamina_Fill.value += 12 * Time.deltaTime;
            UI_Controler.Stamina_Wheel_Fill.fillAmount -= 0.17f * Time.deltaTime;



            //
            // na wrazie co
            // UI_Controler.HealthAndStamina(-12);
            //

        }



        switch (Stamina_Fill.value)
        {
            case <= 0:
                Fill_Image.color = Exhaust_Color;


                break;

            case >= 100:
                Fill_Image.color = Normal_Color;
                break;




        }







        if (Input.GetKey(KeyCode.Mouse1) && Health >= 99)
        {
            Camera.transform.position = Attack_Camera_Position.transform.position;
            Camera.transform.rotation = Attack_Camera_Position.transform.rotation;
            Camera.GetComponent<Camera>().fieldOfView = 53;
            Knife_Anim.SetBool("Prepare_Attack", true);




        }
        else
        {
            Camera.transform.position = Normal_Camera_Position.transform.position;
            Camera.transform.rotation = Normal_Camera_Position.transform.rotation;
            Camera.GetComponent<Camera>().fieldOfView = 60;
            Knife_Anim.SetBool("Prepare_Attack", false);

        }


        if (Input.GetKeyDown(KeyCode.Mouse1) && Health >= 99)
        {
            Audio_Conteiner[0].Play();

        }
        else if (Input.GetKeyUp(KeyCode.Mouse1) && Health >= 99)
        {
            Audio_Conteiner[1].Play();



        }






        if (Enemy_Script.Recorvery >= 1 && Health<100)
        {

            if (Hp_Blind.TryGet(out Vignette))
            {
                Vignette.intensity.value = Damage;
            }
            Enemy_Script.Healt_And_Damgae_Mathf(-7f, -0.07f);
            UI_Controler.TextModifer();
            Audio_Conteiner[3].enabled = true;
            Audio_Conteiner[3].volume = Health * 0.01f;




        }
        else if(Health<100)
        {
            Audio_Conteiner[3].enabled = true;
            Audio_Conteiner[3].volume = Health * 0.01f;

        }
        else
        {

            Audio_Conteiner[3].enabled = false;
            Audio_Conteiner[3].volume = Health * 0.01f;
        }

       

        if (Input.GetKey(KeyCode.F) && x == 0 && y == 0)
        {

            Camera.SetActive(false);
            Camera_Xray.SetActive(true);
            Waiting = 0;

        }
        else if (Waiting >= 0.3f)
        {
            Camera.SetActive(true);
            Camera_Xray.SetActive(false);
        }
        else
        {
            
            Waiting += Time.deltaTime;

        }





        

       
















        if (Physics.CheckSphere(Check_Point.transform.position, Attack_Size) == true && Health >= 99 && Input.GetKey(KeyCode.Mouse1))
        {

            Collider[] Enemy_Side_50 = Physics.OverlapSphere(Check_Point.transform.position, Attack_Size, Enemy_50);
            {

                foreach (Collider Side in Enemy_Side_50)
                {
                    FrontColid = Side;
                    Check_Point.GetComponent<SpriteRenderer>().sprite = X;
                    Attack_Point.transform.position = FrontColid.transform.position;
                    Time.timeScale = 0.3f;

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Knife_Anim.SetTrigger("Attack");
                        Side.GetComponentInParent<Enemy_Script>().EnemyHealth(50);



                    }
                }


                Collider[] Enemy_Side_100 = Physics.OverlapSphere(Check_Point.transform.position, Attack_Size, Enemy_100);
                {

                    foreach (Collider Side in Enemy_Side_100)
                    {

                        BackColid = Side;
                        Check_Point.GetComponent<SpriteRenderer>().sprite = X;
                        Attack_Point.transform.position = BackColid.transform.position;
                        Time.timeScale = 0.3f;


                        if (Input.GetKeyDown(KeyCode.Mouse0) && Health >= 99)
                        {
                            Knife_Anim.SetTrigger("Attack");
                            Side.GetComponentInParent<Enemy_Script>().EnemyHealth(100);





                        }


                    }



                }




            }




        }
        else if (UI_Controler.Pause.activeInHierarchy == false)
        {
            Check_Point.GetComponent<SpriteRenderer>().sprite = Y;
            Attack_Point.transform.position = Camera.transform.position;
            Time.timeScale = 1;

        }










   








    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stamina_Bottle")
        {
            Destroy(other.gameObject);
            Stamina_Endless = true;
            Stamina_Fill.value = 100;
            UI_Controler.Stamina_Wheel_Fill.fillAmount = 1;
            Audio_Conteiner[2].Play();
            StartCoroutine(Endless_Stamina_End());



        }


    }


    IEnumerator Endless_Stamina_End()
    {

        yield return new WaitUntil(()=> UI_Controler.Stamina_Wheel_Fill.fillAmount <=0);
        {
            Stamina_Endless = false;
      
        }

    }



   public static void Postprocessing_On_Off()
    {
        GameObject Camera;
        Camera = GameObject.Find("Main Camera");
        if (PlayerPrefs.GetInt("PostP") == 1)
        {
            Camera.GetComponent<Volume>().enabled = true;
            
        }
        else if(PlayerPrefs.GetInt("PostP") == 0)
        {
            Camera.GetComponent<Volume>().enabled = false;
          
        }



    }



    





    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Attack_Point.transform.position, Attack_Size);





    }
}
