using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowMenu : MonoBehaviour {
    
   /* public PlayerController ps1;
    public GameObject p2;
    public GameObject UIgo;
    public GameObject UITwo;*/
    public void Resume()
    {
        AudioListener.pause = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;/*
        ps1.GetComponent<PlayerController>().enabled = false;
        p2.GetComponent<PlayerController>().enabled = false;*/
        SceneManager.UnloadSceneAsync("StartMenu");
    }
    public void PauseMenu()
    {
        //UIgo.SetActive(false);
        AudioListener.pause = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;/*
        ps1.GetComponent<PlayerController>().enabled = false;
        p2.GetComponent<PlayerController>().enabled = false;*/
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Additive);
        GameObject.Find("MenuData").GetComponent<StartMenu>().resumeable = true;
    }
}
