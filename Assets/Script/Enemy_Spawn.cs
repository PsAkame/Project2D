using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Stamina_Bottle;
    public Transform Enemy_Base;
    public Transform Power_Up_Conteiner;
    public GameObject[] SpawnPoint = new GameObject[9];
    public int Point;
    public static int Enemy_Amount = 1; /// MOŻE BYĆ RANDOMOWE LUB ŚCISLE USTALONE
    public static int Wave_Number = 1;
    int Wave_Enemy;
    // Start is called before the first frame update
    void Start()
    {
        Wave(Enemy_Amount);
        Wave_Enemy = 0;
        Power_Up();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Enemy_Amount == 0)
        {
            Wave_Number += 1;
            Enemy_Amount += 1 + Wave_Enemy;
            Wave(Enemy_Amount);
            UI_Controler.TextModifer();



        }





    }



    void Wave(int Enemy_Amount)
    {
        for (int i = 0; i < Enemy_Amount; i++)
        {
            Point = UnityEngine.Random.Range(0, 9);
            Instantiate(Enemy, SpawnPoint[Point].transform.position, SpawnPoint[Point].transform.rotation, Enemy_Base);
            
            
           
            

        }
       
        Wave_Enemy += UnityEngine.Random.Range(0,4); /// MOŻE BYĆ RANDOMOWO LUB ŚCISLE USTALONE
       

    }

    void Power_Up()
    {
        if (Random.Range(0, 2) == 1)
        {

            Point = UnityEngine.Random.Range(0, 9);
            Instantiate(Stamina_Bottle, SpawnPoint[Point].transform.position, SpawnPoint[Point].transform.rotation, Power_Up_Conteiner);
            StartCoroutine(WaitforSpawn());
        }
        else
        {
            StartCoroutine(WaitforSpawn());
        }





    }
    IEnumerator WaitforSpawn()
    {
        yield return new WaitForSecondsRealtime(10);
        {
            Power_Up();

        
        
        }



    }

    //int Spawn_Or_Not()
    //{
    //    return Random.Range(0, 2);
    //}
    
   
}
