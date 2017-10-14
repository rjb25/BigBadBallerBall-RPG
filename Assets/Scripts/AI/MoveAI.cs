using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveAI : MonoBehaviour, IBehave {
    public float speed = 10;
    public float distance = 0;
    private GameObject target;
    Rigidbody rb;
    private Vars vars;
    public void Start()
    {
        vars = transform.parent.GetComponent<Vars>();

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

                gameObject.GetComponent<Rigidbody>().velocity = transform.forward * vars.speed * Time.deltaTime * 30;
            }
            transform.LookAt(target.transform.position);
        }
    }
}
