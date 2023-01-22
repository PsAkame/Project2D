using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grouned : MonoBehaviour
{
    PLayermovment Script;
    public GameObject Player;
    public Collider2D platform;

    // Start is called before the first frame update
    void Start()
    {
        Script = Player.GetComponent<PLayermovment>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

       

    }

     public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Grouned")
        {

            platform = collision;
            Script.grouned = true;
            
            


        }
        
    }

     void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Grouned")
        {

            
            Script.grouned = false;
            
        }
    }

}
