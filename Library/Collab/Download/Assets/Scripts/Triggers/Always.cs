using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Always: MonoBehaviour {
    public UnityEvent myUnityEvent;

    private void Update()
    {
            myUnityEvent.Invoke();
    }
}
