﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//The class for controlling the player. WASD and arrow keys. The basic movement of player.
public class PlayerController : MonoBehaviour
{
    
    public float baseSpeed = 100;
    public float speed;
    //private bool isHost = false;
    public bool noBackwards = true;
    public RotateAbout camScript;
    private float moveHorizontal = 0;
    private int count;
    public float maxCamera = 0.5f;
    private Movement ms;

    public void OnDeath()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    

    void Start()
    {
    camScript = GameObject.Find("Main Camera").GetComponent<RotateAbout>();
        ms = GetComponent<Movement>();
        Invoke("StartingWeapon",1);
    }
    void StartingWeapon()
    {

        Create.AddLoadout("Swordy", gameObject, true);
    }

    void FixedUpdate()
    {

        bool slow = Input.GetKey(KeyCode.LeftShift);
        if (slow)
        {
            Movement.Slow(rb:ms.rb,speed:ms.grip*10);
        }
        float moveVertical = Input.GetAxis("Vertical");
        ms.defaultMovement(transform.forward*moveVertical, ms.rb, ms.speed);
    }
    void Update()
    {
        float  newDistance = camScript.distance - Input.GetAxis("Mouse ScrollWheel") * 5;
        if (newDistance < 0.5f)
        {
            newDistance = 0.5f;
        }
        if(newDistance > maxCamera)
        {

            newDistance = maxCamera;
        }
        camScript.distance =newDistance;
    }
}