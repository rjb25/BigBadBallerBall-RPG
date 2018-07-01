using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyMenuSettings : MonoBehaviour {

    public PlayerController ps1;
    public GameObject p2;
    public GameObject p2Cam;
    public Camera p1Cam;
    public GameObject UIgo;
    public GameObject UITwo;
    public RectTransform health;
    public RectTransform interaction;

    public RectTransform balance;
    public RectTransform score;
    public GameObject saveData;
    private bool started = false;

    public RectTransform playerText;
    private void Start()
    {
        StartMenu menuData = GameObject.Find("MenuData").GetComponent<StartMenu>();
        if (menuData.twoPlayer)
        {
            p2.SetActive(true);
            p2Cam.SetActive(true);
            UITwo.SetActive(true);
            if (!menuData.dualMonitor)
            {
                p2Cam.GetComponent<Camera>().targetDisplay = 0;
                p2Cam.GetComponent<Camera>().rect = new Rect(0, 0.5f, 1, 0.5f);
                p1Cam.rect = new Rect(0, 0, 1, 0.5f);
                health.anchorMax = new Vector2(0.5f, 0.5f);
                health.anchorMin = new Vector2(0.5f, 0.5f);
                interaction.anchorMax = new Vector2(1, 0.5f);
                interaction.anchorMin = new Vector2(1, 0.5f);
                interaction.localScale *= .7f;
                balance.anchorMax = new Vector2(0, 0.5f);
                balance.anchorMin = new Vector2(0, 0.5f);
                playerText.anchorMax = new Vector2(0.5f, 0.5f);
                playerText.anchorMin = new Vector2(0.5f, 0.5f);
                score.anchorMax = new Vector2(0, 0.5f);
                score.anchorMin = new Vector2(0, 0.5f);

            }
        }
        
            //UIgo.SetActive(true);
            //		AudioListener.pause = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            ps1.enabled = true;
        
    }
}
