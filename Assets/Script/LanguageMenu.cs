using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LanguageMenu : MonoBehaviour
{
    public bool Polish;
    public bool English;
    public GameObject Polski;
    public GameObject Angieslki;
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void England()
    {
        SceneManager.LoadScene(1);


    }

    public void Poland()
    {
        SceneManager.LoadScene(2);


    }


    public void EnglandHM()
    {
        SceneManager.LoadScene(4);


    }


    public void PolandHM()
    {
        SceneManager.LoadScene(5);


    }
}
