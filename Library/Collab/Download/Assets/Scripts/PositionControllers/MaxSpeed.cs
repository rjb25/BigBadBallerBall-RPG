using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxSpeed : MonoBehaviour {
    public float maxSpeed = 50;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 direction = Vector3.Normalize(rb.velocity);
		if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = maxSpeed * direction;
        }
	}
}
