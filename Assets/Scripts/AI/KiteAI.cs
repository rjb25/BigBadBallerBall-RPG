using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiteAI : MonoBehaviour, IBehave {
    public float distance = 0;
    public bool relative = true;
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
                AddForce();
            }
            else
            {
                AddForce(-1);   
            }
            transform.LookAt(target.transform.position);
        }
    }
    private void AddForce(int direction = 1)
    {
        
        
        if (relative) {
            Vector3 force = Vector3.Scale(Vector3.forward, new Vector3(1f, 0f, 1f)) * direction * vars.speed * Time.deltaTime * 30;
            rb.AddRelativeForce(force);
        }
        else
        {
            Vector3 force = Vector3.Scale(Vector3.Normalize(target.transform.position - transform.position), new Vector3(1f, 0f, 1f)) * direction * vars.speed * Time.deltaTime * 30;
            rb.AddForce(force);
        }
    }
}
