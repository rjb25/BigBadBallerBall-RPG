using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float prevMagnitude;
    public float speed;
    private Rigidbody rb;
    private float trueDestX;
    private float trueDestY;
    private float trueDestZ;
    private GameObject target;

    void FixedUpdate() {
        //prevVelocity = getComponent<Rigidbody>().velocity;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int damage = Mathf.FloorToInt(Mathf.Pow(collision.relativeVelocity.magnitude, 1.5f));

            collision.collider.gameObject.GetComponentInParent<Health>().TakeDamage(damage);
        }
    }
    void Start()
    {
    target = GameObject.Find("Player");
    rb = GetComponent<Rigidbody>();
    }

	void Update () {
 
        transform.LookAt(target.transform.position);
        rb.AddRelativeForce(Vector3.forward * speed);
       
    }

}
