using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonetPickUp : MonoBehaviour
{
    public GameObject Player;
    public GameObject Coin1;
    public GameObject Coin2;
    public GameObject Coin3;
    public GameObject Coin4;

    public static int Coinamount;
    public Animator anim;
    public AudioSource Impact;
    // Start is called before the first frame update
    void Start()
    {
        Coinamount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            
            Coin1.SetActive(false);
            Coin3.SetActive(true);
            Coinamount += 1;
            Impact.Play();
            Bank.CoinUpdate();
            Bank.PointSave();



        }
        if (collision.gameObject.tag == "Coin2")
        {
           
            Coin2.SetActive(false);
            Coin4.SetActive(true);
            Coinamount += 1;
            Impact.Play();
            Bank.CoinUpdate();
            Bank.PointSave();

        }
        if (collision.gameObject.tag == "Coin3")
        {
         
            Coin3.SetActive(false);
            Coin1.SetActive(true);
            Coinamount += 1;
            Impact.Play();
            Bank.CoinUpdate();
            Bank.PointSave();
           


        }
        if (collision.gameObject.tag == "Coin4")
        {
          
            Coin4.SetActive(false);
            Coin2.SetActive(true);
            Coinamount += 1;
            Impact.Play();
            Bank.CoinUpdate();
            Bank.PointSave();


        }

       


    }

    
}
