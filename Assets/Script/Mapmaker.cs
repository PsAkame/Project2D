using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapmaker : MonoBehaviour
{
    public GameObject Platform1;
    public GameObject Platform2;
    public GameObject Detected1;
    public GameObject Detected2;
    public float x;
    public float y;
    public float ran;
    // Start is called before the first frame update
    void Start()
    {
        ran = 1;








    }

    // Update is called once per frame
    void Update()
    {
        switch (ran)
        {
            case 1:
                x = 81.2f;
                y = 0;


                break;

            case 2:
                x = 81.2f;
                y = 6.0f;




                break;


            case 3:

                x = 81.2f;
                y = -4.3f;
                
                break;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Grouned2")
        {
            Createplatfrom2();



        }

        if (collision.gameObject.tag == "Grouned3")
        {
            Creatplatfrom1();

        }



    }




    void Createplatfrom2()
    {

            Detected1.SetActive(false);
            Detected2.SetActive(true);
            Platform2.transform.position += new Vector3(x, y, 0);


        
    }

    void Creatplatfrom1()
    {
     
        Detected2.SetActive(false);
        Detected1.SetActive(true);
        Platform1.transform.position += new Vector3(x, y, 0);
    
    }
  


}

