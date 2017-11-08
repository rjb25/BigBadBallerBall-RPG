using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UNUSED might still use it at some point though. Anything that used RotateAbout could benefit from this.
//This was used for realistic collisions of objects that were using RotateAbout. Because their position is set, even if they are moving it is as if
//they are simply appearing wherever they are every iteration. This adds the velocity effect to them. Could be adapted to include more than
//just the player.
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
