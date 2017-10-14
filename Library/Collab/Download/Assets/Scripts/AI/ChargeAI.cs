using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAI : MonoBehaviour, IBehave, IAffect {
    public float distance = 0;
    public float speed = 10;
    private Rigidbody rb;
    private bool reversing = false;
    public int retreatDuration = 3;
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
    public void Affects(GameObject collider, Collision collision) {
        if (!reversing)
        {
            Reverse();
            reversing = true;
            Invoke("Reverse", retreatDuration);
        }
    }


    public void Reverse()
    {
        if (reversing) {
            reversing = false;
        }
            vars.speed = -vars.speed;
    }
}
