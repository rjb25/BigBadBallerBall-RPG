using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithVelocity : MonoBehaviour {
    public Transform match;
    private Rigidbody rb;
    private Rigidbody lookAtRB;
    private Vector3 relativePosition;


    // Update is called once per frame
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lookAtRB = match.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.angularVelocity = lookAtRB.angularVelocity;
        rb.rotation = lookAtRB.rotation;
    }
 
}
