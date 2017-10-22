using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTargetDeath : MonoBehaviour {
    public UnityEvent myUnityEvent;
    // Use this for initialization
    public Targeting ts;
	void Start () {
        ts = GetComponent<Targeting>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!ts.target)
        {
           myUnityEvent.Invoke();
        }

    }
}
