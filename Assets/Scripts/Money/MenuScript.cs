using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {
    public GameObject Menu;
    public GameObject Player;
    public NetworkManagerHUD NetworkHUD;
    //name of button "Charger"   "price","level"
  
    public bool haveHud = false;

    // Use this for initialization
    public void Start()
    {
 
    NetworkHUD = GameObject.Find("Networking").GetComponent<NetworkManagerHUD>();

    }
    //BUTTONS ARE IN PURCHASES
    public void Toggle() {
           
        if (Menu.activeInHierarchy)
        {
            AudioListener.pause = false;
            NetworkHUD.enabled = false;
            Time.timeScale = 1;
            Menu.SetActive(false);
            Player.GetComponent<PlayerController>().enabled = true;
        }
        else{
            if (haveHud)
            {
                NetworkHUD.enabled = true;
            }
            AudioListener.pause = true;
            Time.timeScale = 0;
            Menu.SetActive(true);
            Player.GetComponent<PlayerController>().enabled = false;
        }
    }


}
