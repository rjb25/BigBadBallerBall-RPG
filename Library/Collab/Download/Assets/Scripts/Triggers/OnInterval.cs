using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnInterval : MonoBehaviour {
    public UnityEvent myUnityEvent;
    public float interval;
    public float timeLeft;
    private void Start()
    {
        timeLeft = interval;
    }
    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            myUnityEvent.Invoke();
            timeLeft = interval;
        }
    }

}
