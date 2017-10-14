using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnKey : MonoBehaviour {
    public UnityEvent myUnityEvent;
    public KeyCode key;

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            myUnityEvent.Invoke();
        }
    }
}
