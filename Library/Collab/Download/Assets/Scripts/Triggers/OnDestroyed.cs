using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnDestroyed: MonoBehaviour {
    public UnityEvent myUnityEvent;
    void OnDestroy() { 
            myUnityEvent.Invoke();
        }
}
