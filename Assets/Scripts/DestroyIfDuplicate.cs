using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfDuplicate : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (GameObject.Find("EventSystem"))
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
