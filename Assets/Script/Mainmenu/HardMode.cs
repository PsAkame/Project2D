using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardMode : MonoBehaviour
{

    public Animator PlaybuttonHM;
    public GameObject PlayButtonHM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void PlayHM()
    {


        PlaybuttonHM.SetTrigger("HardModeplay");




    }

    public void DisableButtonHM()
    {
        PlayButtonHM.SetActive(false);

    }
}
