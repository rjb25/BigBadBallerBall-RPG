using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Timer : Object {
    public float lastUse;
    public float duration = -1;
    public Timer(float dur)
    {
        duration = dur;
    }
    public bool Ready() {
         if (Time.time > lastUse + duration)
        {
            lastUse = Time.time;
            return true;
        }
        else
        {
            return false;
        }
    }
}
