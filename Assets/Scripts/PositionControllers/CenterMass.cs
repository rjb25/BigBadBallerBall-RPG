using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterMass : MonoBehaviour {
    public Transform center;
    // Use this for initialization
    public void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = (center.position-transform.position);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
