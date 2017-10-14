using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GetInterfaces : MonoBehaviour {
    public static IBehave[] Behaves(GameObject where)
    {
        var mObjs = where.GetComponents<MonoBehaviour>();
        return (from a in mObjs where (a.GetType().GetInterfaces().Any(k => k == typeof(IBehave)) && a.enabled) select (IBehave)a).ToArray();
    }
    public static IAffect[] Affects(GameObject where)
    {
        var mObjs = where.GetComponents<MonoBehaviour>();
        return (from a in mObjs where (a.GetType().GetInterfaces().Any(k => k == typeof(IAffect)) && a.enabled) select (IAffect)a).ToArray();
    }
    public static ISetTarget[] TargetSetters(GameObject where)
    {
        var mObjs = where.GetComponents<MonoBehaviour>();
        return (from a in mObjs where (a.GetType().GetInterfaces().Any(k => k == typeof(ISetTarget)) && a.enabled) select (ISetTarget)a).ToArray();
    }
}
