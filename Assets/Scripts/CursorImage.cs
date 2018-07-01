using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CursorImage : MonoBehaviour {
    RectTransform location;
	// Use this for initialization
	void Start () {
        location = gameObject.GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float mouseY = Input.GetAxis("secondCursorY");
        float mouseX = Input.GetAxis("secondCursorX");
        location.anchoredPosition += new Vector2(mouseX*15,mouseY*15);
    }
    public void Click()
    {
        try
        {
            Physics2D.OverlapCircle(location.gameObject.transform.position, 1).GetComponent<ClickableObject>().leftClick();
        }
        catch (NullReferenceException ex)
        {
            print("no button under mouse");
        }
    }
}
