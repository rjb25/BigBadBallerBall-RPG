using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    Movement ms;
	// Use this for initialization
	void Start () {
        ms = GetComponent<Movement>();
        
	}
	
	// Update is called once per frame
	public void Update () {
        ms.moveFunc(transform.forward);
    }
}
