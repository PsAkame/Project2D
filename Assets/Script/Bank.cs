using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
   

    public static GameObject Coin_Amount_Normal;
    public static GameObject Coin_Amount_Shop;

    public static GameObject Platform_Score;

    public static int MaxScore;
    public static int MaxScore_HardMode;



    // Start is called before the first frame update
    void Start()
    {
        
    

        Coin_Amount_Normal = GameObject.Find("Coin_Amount_Normal");
        Coin_Amount_Shop = GameObject.Find("Coin_Amount_Shop");
        CoinUpdate();


    }

    // Update is called once per frame
    void Update()
    {
        MaxScore = MonetPickUp.Coinamount;
        MaxScore_HardMode = MonetPickUp.Coinamount;

      
    }

    


    public static void CoinUpdate()
    {
        Coin_Amount_Normal.GetComponent<TextMeshProUGUI>().text = "=" + MonetPickUp.Coinamount;
        Coin_Amount_Shop.GetComponent<TextMeshProUGUI>().text = "=" + MonetPickUp.Coinamount;
      

    }

    public static void PointSave()
    {

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1) || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            if (PlayerPrefs.GetInt("punktyZapis") < MonetPickUp.Coinamount)
            {

                PlayerPrefs.SetInt("punktyZapis", MaxScore);
                PlayerPrefs.Save();


            }
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(4) || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(5))
        {
            if (PlayerPrefs.GetInt("HardModeScore") < MonetPickUp.Coinamount)
            {
                PlayerPrefs.SetInt("HardModeScore", MaxScore_HardMode);
                PlayerPrefs.Save();


            }

        }



    }




}
