using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToolScript : MonoBehaviour {

    public float reloadTime = 10;
    private bool initial = true;
    private float timeLeft;
    private float timePrevious;
    public void Start()
    {
        timePrevious = Time.time;
    }
    public void SetTargets(GameObject projectile, string[] targets)
    {
        foreach (string target in targets)
        {
            projectile.GetComponents<Sendable>()[0].targets.Add(target);
        }
    }
    public void IsActive()
    {
        if (initial)
        {
            timeLeft = reloadTime;
            initial = false;
        }
       timeLeft = reloadTime - (Time.time - timePrevious);
        if (timeLeft < 0)
        {
            Use();
            timeLeft = reloadTime;
            timePrevious = Time.time;
        }
    }
    public virtual void Use() { }

}
