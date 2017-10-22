
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Targeting : MonoBehaviour{
    public string[] targetByTags;
    public GameObject target;
    public string targeting = "nearest";
    public float targetingSpeed = 3;
    public float retargetingSpeed = 1;
    public bool retargetOnInterval = true;
    public float targetingRange = 100;
    // switch case OK for now private delegate void targeting(GameObject[] objs);
    private void Start()
    {
        if (retargetOnInterval)
        {
            OnInterval ois = gameObject.AddComponent<OnInterval>();
            ois.Set(TargetAtSpeed, retargetingSpeed);
        }
        /*
        if (!setTargetOnDeath)
        {
            //This needs a coroutine if I want to be able to update targeting speed mid game.
            InvokeRepeating("SetTarget", targetingSpeed, targetingSpeed);
        }
        */
        //print(gameObject.name);
        TargetAtSpeed();
    }
    public void TargetAtSpeed()
    {
        Invoke("SetTarget", targetingSpeed);
    }
    //this could be static if I so desired
    public static GameObject GetTarget(string[] targetTags, GameObject obj, string targeting, float range)
    {
        List<GameObject> gos = new List<GameObject>();
        foreach (string tag in targetTags)
        {
            gos.AddRange(GameObject.FindGameObjectsWithTag(tag));
        }
        List<GameObject> theGos = gos.Where((go => (go.transform.position - obj.transform.position).sqrMagnitude < range)).ToList();


        switch (targeting)
        {
            case "nearest":
                return Nearest(obj, theGos);

            case "priority":
                return Priority(obj, theGos);

            default:
                print("defaulting to nearest");
                return Nearest(obj, theGos);

        }
    }
public void SetTarget()
    {
            target = GetTarget(targetByTags,gameObject,targeting,targetingRange);
           if(target == null)
        {
            // go to point
        }
    }
       
    
    public static GameObject Nearest(GameObject obj,List<GameObject> objs)
    {
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = obj.transform.position;
        foreach (GameObject go in objs)
        {

            Vector3 diff = go.transform.position - position;

            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && go != obj.gameObject)
            {

                closest = go;
                distance = curDistance;
            }
        }
            return closest;
    }
    public static GameObject Priority(GameObject obj,List<GameObject> objs)
    {
        GameObject highestPriority = null;
        float priority = Mathf.Infinity;
        foreach (GameObject go in objs)
        {
            float curPriority = 0;
            curPriority = go.GetComponent<Priority>().priority;

            if (curPriority < priority)
            {
                highestPriority = go;
                priority = curPriority;
            }
        }
        //if set to really low priority, ignore them. (High number for priority means do way later)

            if (priority < 1000)
            {
                return highestPriority;
        }
        else
        {
            return null;
        }
    }
    
}