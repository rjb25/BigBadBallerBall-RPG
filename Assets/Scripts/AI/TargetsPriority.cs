
using System.Collections.Generic;
using UnityEngine;



public class TargetsPriority : MonoBehaviour
{
    public string[] targetByTags;
    public GameObject target;
    private IBehave[] behaviours;


    public void Start()
    {
        behaviours = GetInterfaces.Behaves(gameObject);
    }
    public void Update()
    {
        if (!target)
        {

            List<GameObject> tagsGos = new List<GameObject>();
            foreach (string tag in targetByTags)
            {
                tagsGos.AddRange(GameObject.FindGameObjectsWithTag(tag));
            }
            GameObject highestPriority = null;
            float priority = Mathf.Infinity;
            foreach (GameObject go in tagsGos)
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
            if (highestPriority != null)
            {
                if (priority < 1000)
                {
                    target = highestPriority;
                    foreach (IBehave behaver in behaviours)
                    {
                        behaver.Behaves(target);
                    }
                }
            }
        }
    }

}


   