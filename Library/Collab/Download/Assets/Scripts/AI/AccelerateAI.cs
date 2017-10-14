using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerateAI : MonoBehaviour, IBehave {

    public float speed;
    public float distance = 0;
    private Rigidbody rb;
    private GameObject target;
    private Vars vars;
    public void Start()
    {
        vars = transform.parent.GetComponent<Vars>();
        rb = GetComponent<Rigidbody>();

    }

    public void Behaves(GameObject target)
    {
        this.target = target;
        
    }
    void Update()
    {
        if (target)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > distance)
            {
                rb.AddRelativeForce(Vector3.forward * vars.speed * Time.deltaTime * 30);
            }
            transform.LookAt(target.transform.position);
        }
    }
}
