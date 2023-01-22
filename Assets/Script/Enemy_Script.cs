using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Enemy_Script : MonoBehaviour
{
    [Header("int")]
    int Enemy_Health = 100;
    int Chose;

    public int Eyes_Range;


    [Header("GameObject")]
    public GameObject Eyes;
    public GameObject Attack_Point;

    public GameObject Lost_Mark;
    public GameObject Chase_Mark;


    public GameObject Blood_Particle;

    GameObject GOPlayer;

    //   GameObject Player;

    public static GameObject Health_Bar;



    [Header("Vector3")]
    Vector3 Point;
    Vector3 PointSizeCube = new Vector3(1, 1, 1);
    Vector3 Rotate_Strenght;






    [Header("LayerMask")]
    public LayerMask Player;
    public LayerMask Ground;
    public LayerMask PointMask;

    [Header("Float")]
    float EnemyWait;

    public float Attack_Range;

    float Wait = 0;

    public static float Recorvery = 0;


    [Header("Arrays")]
    Vector3 RandPoint;
    public GameObject[] Enemy_Child;



    [Header("Bool")]
    public bool Arrive = true;
    public bool LostP = true;




    [Header("NavMesh")]
    public NavMeshAgent Enemy;

    [Header("Material")]

    public Material Status;


    [Header("Animator")]

    public Animator Enemy_Anim;


    Player_Movment script;

    [Header("AudioSorce")]
    public AudioSource Death_Sound;




















    // Start is called before the first frame update



    void Start()
    {
        Recorvery = Mathf.Clamp(Recorvery, 0, 1);


        Enemy = GetComponent<NavMeshAgent>();


        Rotate_Strenght = new Vector3(0, 0.7f, 0);

        script = FindObjectOfType<Player_Movment>();

        GOPlayer = GameObject.Find("Player");
        Health_Bar = GameObject.Find("HFrame_Bar");





    }

    // Update is called once per frame
    void Update()
    {








        bool Player_Chaseing = Physics.CheckSphere(Eyes.transform.position, Eyes_Range, Player);





        if (!Player_Chaseing && LostP)
        {

            if (Chose == 0)
            {
                Patrol2(ref Point);
            }
            else if (Chose == 1)
            {
                PatrolStatic(ref Point);
            }

        }

        if (Player_Chaseing)
        {

            Chase();
            Attack();

        }
        else
        {

            Recorvery += Time.deltaTime;




        }



        if ((Enemy.transform.position.x == Point.x || Enemy.transform.position.z == Point.z) && !LostP)
        {

            Enemy_Anim.SetBool("Chase", false);
            Chase_Mark.SetActive(false);
            Losted();



        }



        





    }

















    //// ŻYCIE PRZECIWNIKA I WSZYSTKO CO Z NIM ZWIĄZANE
    public void EnemyHealth(int Attack_Point)
    {

        Enemy_Health -= Attack_Point;
        Instantiate(Blood_Particle, Enemy.transform.position, Quaternion.identity);
        Death_Sound.Play();
        Player_Movment.Kills += 1;
        if (PlayerPrefs.GetInt("Score") < Player_Movment.Kills)
        {
            PlayerPrefs.SetInt("Score", Player_Movment.Kills);
            PlayerPrefs.Save();

        }
        ///Animacja////////////////////





        if (Enemy_Health <= 0)
        {
            //Śmierc czy coś ogarnąć :)//////////////////////////
            ////Poprawić toooooo///
            for (int i = 0; i < Enemy_Child.Length; i++)
            {
                Destroy(Enemy_Child[i]);
            }


            //////////////
            Time.timeScale = 1;
            Enemy.GetComponent<NavMeshAgent>().enabled = false;
            Enemy.GetComponent<Rigidbody>().freezeRotation = false;
            Enemy.GetComponent<Enemy_Script>().enabled = false;
            Enemy.GetComponent<Rigidbody>().AddForce(60, 60, 60);
            StartCoroutine(DestroyEnemy());
            Enemy_Anim.SetBool("Lost", false);

            Enemy_Spawn.Enemy_Amount -= 1;

        }
        else
        {
            Enemy.SetDestination(GOPlayer.transform.position);
        }



    }
    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSecondsRealtime(5);
        {
            Destroy(gameObject);


        }


    }






    ////// Patrolowanie okolicy (Randomowe Punkty)
    void Patrol2(ref Vector3 Point_Patrol)
    {

        if (Arrive)
        {
            float PositionZ = Random.Range(-40, 40);
            float PositionX = Random.Range(-40, 40);



            Point_Patrol = new Vector3(transform.position.x + PositionX, 1f, transform.position.z + PositionZ);


            if (Physics.Raycast(Point_Patrol, Vector3.down * 30, Ground) == true)
            {

                Enemy.SetDestination(Point_Patrol);


            }
            else
            {
                Patrol2(ref Point);

            }


            ////Cube sprawdzający zamiast kreski na wszelki wypadek w problemie działania skryptu

            //if (Physics.BoxCast(Point_Patrol, PointSizeCube, Vector3.down * 2f, Quaternion.Euler(0, 0, 0), Ground) == true)
            //{

            //    Enemy.SetDestination(Point_Patrol);

            //}
            //else
            //{
            //    Patrol2(ref Point);

            //}





        }

        if (Enemy.transform.position.x == Point_Patrol.x || Enemy.transform.position.z == Point_Patrol.z)
        {

            Arrive = true;
            Chose = Random.Range(0, 2);



        }

        else
        {

            Arrive = false;
        }















    }




    /////////////Patro do specjalnych punktów
    void PatrolStatic(ref Vector3 Point_Patrol, int Chose_Point = 0)
    {
        if (Arrive)
        {
            Chose_Point = Random.Range(0, 9);
            switch (Chose_Point)
            {
                case 0:
                    RandPoint = GameObject.Find("Spawn_1").transform.position;

                    break;

                case 1:
                    RandPoint = GameObject.Find("Spawn_2").transform.position;

                    break;

                case 2:
                    RandPoint = GameObject.Find("Spawn_3").transform.position;

                    break;

                case 3:
                    RandPoint = GameObject.Find("Spawn_4").transform.position;

                    break;

                case 4:
                    RandPoint = GameObject.Find("Spawn_5").transform.position;

                    break;

                case 5:
                    RandPoint = GameObject.Find("Spawn_6").transform.position;

                    break;

                case 6:
                    RandPoint = GameObject.Find("Spawn_7").transform.position;

                    break;

                case 7:
                    RandPoint = GameObject.Find("Spawn_8").transform.position;
                    break;

                case 8:
                    RandPoint = GameObject.Find("Spawn_9").transform.position;

                    break;


            }
            Point_Patrol = RandPoint;
            Enemy.SetDestination(Point_Patrol);




        }
        if (Enemy.transform.position.x == Point_Patrol.x || Enemy.transform.position.z == Point_Patrol.z)
        {

            Arrive = true;
            Chose = Random.Range(0, 2);


        }

        else
        {

            Arrive = false;
        }



    }





    /////////// Pościg za Graczem
    void Chase()
    {
        ///// Przeciwnik podąża do Gracza aż do jego ostatniego miejsca pobytu
        Point = GOPlayer.transform.position;
        Enemy.SetDestination(Point);


        //// Zapobieganie włączenia się skryptu szukania punktu
        LostP = false;

        //// Reset czekania na koniec poszukiwań, rzeczy potrzebne do Losted()
        Wait = 0;
        //  Rotate_Strenght.y = Random.Range(-0.9f, 0.9f);
        Rotate_Strenght.y = Random.Range(-0.9f, 0.9f);

        //// Znaki stanu pościgu
        Enemy_Anim.SetBool("Lost", false);
        Enemy_Anim.SetBool("Chase", true);
















    }



    void Losted()
    {

        if (Physics.CheckSphere(Eyes.transform.position, Eyes_Range, Player) == false)
        {

            Enemy_Anim.SetBool("Lost", true);
            Enemy.transform.rotation *= Quaternion.Euler(Rotate_Strenght);
            Wait += Time.deltaTime;


            if (Wait >= 7)
            {
                Enemy_Anim.SetBool("Lost", false);
                Lost_Mark.SetActive(false);
                LostP = true;
                Chose = Random.Range(0, 2);


            }


        }





    }




    /////////////////////////////////////////

    ///// Atak gracza /////////////////////////////////////
    void Attack()
    {

        if (script.Hp_Blind.TryGet(out script.Vignette))
        {
            script.Vignette.intensity.value = Player_Movment.Damage;

        }

        Recorvery = 0;
        Healt_And_Damgae_Mathf(10f, 0.1f);
        UI_Controler.TextModifer();
        




    }




    ////////////////////////////////////////////////////////



    public static void Healt_And_Damgae_Mathf(float _Health, float _Damage)
    {

        // Na wrazie co 
        //UI_Controler.HealthAndStamina(0);

        Health_Bar.GetComponent<Slider>().value = Player_Movment.Health;

        Player_Movment.Health = Mathf.Clamp(Player_Movment.Health, 0, 100);
        Player_Movment.Damage = Mathf.Clamp(Player_Movment.Damage, 0f, 1f);
        Player_Movment.Health -= _Health * Time.deltaTime;
        Player_Movment.Damage += _Damage * Time.deltaTime;


    }

   
        




    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(Eyes.transform.position, Eyes_Range);
    //    Gizmos.DrawWireSphere(Attack_Point.transform.position, Attack_Range);
    //    //Gizmos.DrawWireSphere(Enemy.transform.position, 60);
    //    Gizmos.DrawRay(Point, Vector3.down * 2f);
    //    //Gizmos.DrawCube(Point, PointSizeCube);

    //}

















































}
