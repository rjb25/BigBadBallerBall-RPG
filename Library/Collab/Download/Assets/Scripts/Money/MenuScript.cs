using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {
    public GameObject Menu;
    public GameObject Player;

    // Use this for initialization
    public void Toggle() {
           
        if (Menu.activeInHierarchy)
        {
            Time.timeScale = 1;
            Menu.SetActive(false);
            Player.GetComponent<PlayerController>().enabled = true;
        }
        else{
            Time.timeScale = 0;
            Menu.SetActive(true);
            Player.GetComponent<PlayerController>().enabled = false;
        }
    }


}
