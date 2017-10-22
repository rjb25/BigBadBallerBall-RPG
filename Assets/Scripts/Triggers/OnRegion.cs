using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnRegion : MonoBehaviour {
    public UnityEvent enter;
    public UnityEvent stay;
    public UnityEvent exit;
    public Vector3 center;
    public float range;
    private bool inside;
    void Start()
    {

    }

	void Update () {

	}
}
