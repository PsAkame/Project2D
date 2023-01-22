using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Shop : MonoBehaviour
{
    public GameObject Nogold;
    public GameObject Player;
    public GameObject BCylinder;
    public GameObject PCylinder;
    public bool TCylinder;
    public GameObject BOkulary;
    public GameObject POkulary;
    public bool TOkulary;
    public GameObject BNos;
    public GameObject PNos;
    public bool TNos;
    public GameObject BUsmiech;
    public GameObject PUsmiech;
    public bool TUsmiech;
    MonetPickUp script;
    PLayermovment script2;
    public GameObject Wingame;
    public static bool HardMode;
    
    
    // Start is called before the first frame update
    void Start()
    {
        script = Player.GetComponent<MonetPickUp>();
        script2 = Player.GetComponent<PLayermovment>();
        Nogold.SetActive(false);

       


       
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!script2.Dead && TCylinder && TOkulary && TNos && TUsmiech && !script2.Bpause)
        {
            Time.timeScale = 0f;
            Wingame.SetActive(true);
            HardMode = true;
            PlayerPrefs.SetString("HardMode", "Unlock");
            


        }



    }

    public void Continue()
    {
        Time.timeScale = 1f;
        Wingame.SetActive(false);
        script2.Bpause = true;

    }





    public void Cylinder ()
    {
        if(MonetPickUp.Coinamount >=50)
        {
            MonetPickUp.Coinamount -= 50;
            Bank.CoinUpdate();
            BCylinder.SetActive(false);
            PCylinder.SetActive(true);
            TCylinder = true;

        }
        if(MonetPickUp.Coinamount < 50)
        {
            Nogold.SetActive(true);
            StartCoroutine(Comunication());


        }





    }


    public void Okulary()
    {
        if(MonetPickUp.Coinamount >=30)
        {
            MonetPickUp.Coinamount -= 30;
            Bank.CoinUpdate();
            BOkulary.SetActive(false);
            POkulary.SetActive(true);
            TOkulary = true;


        }
       else if (MonetPickUp.Coinamount < 30)
        {
            Nogold.SetActive(true);
            StartCoroutine(Comunication());

        }

    }

    public void Nos()
    {
        if(MonetPickUp.Coinamount >= 15)
        {
            MonetPickUp.Coinamount -= 15;
            Bank.CoinUpdate();
            BNos.SetActive(false);
            PNos.SetActive(true);
            TNos = true;
        }

        else if(MonetPickUp.Coinamount < 15)
        {

            Nogold.SetActive(true);
            StartCoroutine(Comunication());

        }



    }


    public void usmiech()
    {
        if(MonetPickUp.Coinamount >= 10)
        {
            MonetPickUp.Coinamount -= 10;
            Bank.CoinUpdate();
            BUsmiech.SetActive(false);
            PUsmiech.SetActive(true);
            TUsmiech = true;



        }

       else if(MonetPickUp.Coinamount < 10)
        {
            Nogold.SetActive(true);
            StartCoroutine(Comunication());


        }    


    }

    IEnumerator Comunication()
    {
        yield return new WaitForSeconds(0.3f);
        {
            Nogold.SetActive(false);


        }

    }




}
