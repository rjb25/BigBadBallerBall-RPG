using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This is my super hacky route to multiple inheritance
//CHILD INTERFACES
public interface IBehave {
    void Behaves(GameObject target);
}
public interface IAffect {
    void Affects(GameObject collider, Collision collision);
}
//PARENT INTERFACES
//AMBIGOUS
public interface ISetTarget
{
    void SetTarget(GameObject target);
}
