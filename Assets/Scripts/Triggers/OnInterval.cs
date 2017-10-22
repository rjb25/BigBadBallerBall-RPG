using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OnInterval : MonoBehaviour {

    
    public Actor action;
    public float interval;
    public float timeLeft;
    public void Set(Actor doWhat, float interval)
    {//could put these out into functions if desired.
        action = doWhat;
        this.interval = interval;
    }
    private void Start()
    {
        timeLeft = interval;
    }
    private void Update()
    {
        
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            action.Invoke();
            timeLeft = interval;
        }
    }

}
