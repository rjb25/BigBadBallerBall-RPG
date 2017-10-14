using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HavePlayerVelocity : MonoBehaviour {
    private Rigidbody rb;
    private GameObject match;
    private Rigidbody rbMatch;
    private Rigidbody rbRotation;
    private Vector3 relativePosition;
    void Start() {
        match = GameObject.Find("PlayerBody");
        rbMatch = match.GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        rbRotation = GameObject.Find("PlayerRotation").GetComponent<Rigidbody>();
    }
    private void LateUpdate() {

        relativePosition = match.transform.position - transform.position;
        rb.centerOfMass = relativePosition;
       // print(string.Format("COM {0}", rb.centerOfMass));
       // print(string.Format("{0} mine before, {1} one im matching", rb.velocity, rbMatch.velocity));
        rb.velocity = rbMatch.velocity;
       // print(string.Format("{0} mine, {1} one im matching", rb.velocity, rbMatch.velocity));
        rb.angularVelocity =  rbRotation.angularVelocity;
        //print(string.Format("{0} mine angular {1} their angular", rb.angularVelocity, rbRotation.angularVelocity));
    }
 
}
