using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sendable : MonoBehaviour{
    public List<string> targets;
    public bool hitsBarriers = true;
    public IAffect[] affects;
    private bool affectsSet = false;
    public void Start()
    {
        affects = GetInterfaces.Affects(gameObject);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (targets.Contains(collision.gameObject.tag) || (hitsBarriers && collision.gameObject.CompareTag("Barrier")))
        {
            foreach (IAffect affect in affects)
            {
                affect.Affects(collision.gameObject, collision);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (!affectsSet)
        {
            affects = GetInterfaces.Affects(gameObject);
            affectsSet = true;
        }
        if (targets.Contains(other.gameObject.tag) || (hitsBarriers && other.gameObject.CompareTag("Barrier")))
            {
            foreach (IAffect affect in affects)
                {
                

                    affect.Affects(other.gameObject, null);

                }
            }
    }
}
