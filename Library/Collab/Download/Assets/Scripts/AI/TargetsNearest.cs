
using System.Collections.Generic;
using UnityEngine;

public class TargetsNearest : MonoBehaviour{
    public string[] targetByTags;
    public GameObject target;
    private IBehave[] behaviours;


    public void Start()
    {

        behaviours = GetInterfaces.Behaves(gameObject);
        if (target)
        {
            foreach (IBehave behaviour in behaviours)
            {
                behaviour.Behaves(target);
            }
        }

    }
    void Update()
    {
        if (!target)
        {
            
            List<GameObject> tagsGos = new List<GameObject>();
            foreach (string tag in targetByTags)
            {
                tagsGos.AddRange(GameObject.FindGameObjectsWithTag(tag));
     
            }
            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject go in tagsGos)
            {
                
                Vector3 diff = go.transform.position - position;
                
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance && go != gameObject)
                {
                    
                    closest = go;
                    distance = curDistance;
                }
            }
            if (closest != null)
            {        
                target = closest;
                foreach (IBehave behaver in behaviours)
                {
                    behaver.Behaves(target);
                }
            }
        }
    }
}