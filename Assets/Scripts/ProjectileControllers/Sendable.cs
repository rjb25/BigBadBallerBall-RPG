using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sendable : MonoBehaviour{
    //make this a function class. for performance of AI being integrated
    public List<string> targets;
    public List<string> affected;
    public bool hitsBarriers = true;
    private void Start()
    {
        affected = affected ?? targets;
    }
    public bool IsReceiver(GameObject other)
    {
        if (targets.Contains(other.gameObject.tag) || (hitsBarriers && other.gameObject.CompareTag("Barrier")))
        {
            return true;
        }
        return false;
    }

}
