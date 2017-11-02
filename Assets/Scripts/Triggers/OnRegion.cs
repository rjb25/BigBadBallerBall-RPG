using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class OnRegion : MonoBehaviour {
    public Action enter;
    public Action inRegion;
    public Action exit;
    public Vector3 center;
    public float radius;
    private bool inside = false;
    public void SetActions(Action enter = null,Action exit = null, Action inRegion = null)
    {
        this.enter = enter??No.Nothing;
        this.exit = exit??No.Nothing;
        this.inRegion = inRegion??No.Nothing;
    }
	void Update () {
        if (Vector3.Magnitude(center -gameObject.transform.position) < radius)
        {
            if (!inside)
            {
                inside = true;
                enter();
            }
            else
            {
                inRegion();
            }
        }
        else
        {
            if (inside == true)
            {
                inside = false;
                exit();
            }
        }
	}
}
