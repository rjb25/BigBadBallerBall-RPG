using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoVelocity : MonoBehaviour {
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
	}
}
