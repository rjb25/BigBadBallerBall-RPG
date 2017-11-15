using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
//This is a class that simply controls menu toggling.
public class MenuScript : MonoBehaviour {
    public GameObject Menu;
    public GameObject Player;
    public NetworkManagerHUD NetworkHUD;
    public Interact playerInteract;
    public GameObject interactionGrid;
    public GameObject playerRotation;
  
    public bool haveHud = false;

    // Use this for initialization
    public void Start()
    {
        playerInteract = Player.GetComponent<Interact>();
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
            playerInteract.RefreshInteractables();
            Player.GetComponent<PlayerController>().enabled = false;
        }
    }


}
