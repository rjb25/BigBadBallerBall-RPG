using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public bool twoPlayer;
    public bool dualMonitor;
    public bool coop;
    public bool resumeable;
    void Start()
    {
        /*
        instructionMenu = instructionMenu.GetComponent<Canvas>();
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        
        quitMenu.enabled = false;
        instructionMenu.enabled = false;
        */
        if (GameObject.Find("MenuData"))
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.name = "MenuData";
            DontDestroyOnLoad(gameObject);
        }


    }
    public void SetCoop(bool value)
    {
        coop = value;
    }
    public void SetMonitors(bool value)
    {
        dualMonitor= value;
    }
    public void SetTwoPlayer(bool value)
    {
        twoPlayer = value;
    }
    
    public void StartGame()
    {
        print("called");
        SceneManager.LoadScene("Game");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}