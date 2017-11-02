using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AI : MonoBehaviour
{
    //this will eventually be broken back into AI classes.
    #region vars
    public float distance = 0;
    public int direction = 1;
    public int retreatDuration = 3;
    public bool kites = false;
    public bool relative = true;
    public bool charges = false;
    public bool movesFacing = false;
    public bool hold = false;
    public float pointSpeed = 0.1f;
    private Targeting targetScript;
    private Movement ms;
    public bool reholding = false;
    public float holdRange = 0.01f;
    public Vector3 holdPoint;
    public Rigidbody rb;
    private Sendable sendScript;
    public OnRegion holdRegion;
    public Trigger ts;
    public Vector3 basePoint;

    public int pursueRange = 10;

    //public Actor noTarget;
    #endregion
    public void Start(){
       
        ms = GetComponent<Movement>();
        //noTarget = Forward;
        targetScript = GetComponent<Targeting>();
    sendScript = GetComponent<Sendable>();
        holdPoint = gameObject.transform.position;
        if(basePoint == new Vector3())
        {
            basePoint = gameObject.transform.position;
        }
        rb = GetComponent<Rigidbody>();
        //The way to set triggers NOTE THIS IT IS REALLY IMPORTANT
        ts = gameObject.AddComponent<Trigger>();
        ts.condition = () => Vector3.Magnitude(holdPoint - gameObject.transform.position) < holdRange;
        ts.Set(active: () => Movement.Slow(rb:ms.rb, speed:ms.speed), inactive: () => ms.defaultMovement(Vector3.Normalize(holdPoint - gameObject.transform.position), ms.rb,ms.speed));
        ts.name = "hold motion trigger";
        
        ts.enabled = hold;

    }
    public void SetHold(bool isHolding)
    {
        ts.enabled = isHolding;
        hold = isHolding;
    }
    /*public void Forward()
    {
        
        ms.Velocity(gameObject.transform.forward);
    }*/
    void Kite(){
        float dist = Vector3.Distance(transform.position, targetScript.target.transform.position);
        if (dist > distance)
        {
            direction = 1;
        }
        if(dist < distance - 5) { 
            direction = -1;
        }   

    }
    public void SetHold()
    {
        holdPoint = gameObject.transform.position;
        hold = true;
    }
void Update()
{
        //if out of pursue range from base, move towards hold point.
        Vector3 baseDistance = basePoint - gameObject.transform.position;
        hold = baseDistance.sqrMagnitude > pursueRange * pursueRange;
        
        Vector3 where = Vector3.zero;
        if (targetScript.target) 
    {
            //Movement based on target
          
            Vector3 relativePos = targetScript.target.transform.position - transform.position;

                if (kites)
                {
                    Kite();
                }

                Vector3 forward;

                if (movesFacing)
                {

                    forward = transform.forward;
                }
                else
                {

                    forward = Vector3.Normalize(relativePos);
                }
                if (!relative)
                {
                    where = direction * Vector3.Normalize(Vector3.Scale(forward, new Vector3(1, 0, 1)));
                }
                else
                {
                    where = direction * forward;
                }

                
                
            
            //Rotation Based on target
            if (pointSpeed > 0)
            {
                if (pointSpeed > 10)
                {
                    transform.LookAt(targetScript.target.transform);
                }
                else
                {
                    Quaternion rotation = Quaternion.LookRotation(relativePos);
                    if (transform.rotation != rotation)
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.time * pointSpeed);
                    }
                }
            }

           // 
        }
        else
        {
}

        /*
        if (where == Vector3.zero)
        {
            ms.SetMovement("none");
        }
        else
        {
            ms.SetMovement("accelerate");
        }*/
        if (hold)
        {
            Vector3 difference = holdPoint - gameObject.transform.position;
            where = Vector3.Normalize(difference);
        }

        ms.defaultMovement(where,ms.rb,ms.speed);
    }
void OnCollisionEnter(Collision collision)
    {//delegates are the answer if this section gets bogged down
            checkRetreat(collision.gameObject);
    }
    void OnTriggerEnter(Collider collision)
    {
        checkRetreat(collision.gameObject);
    }
    void checkRetreat(GameObject obj)
    {
        if (charges)
        {
            if (sendScript.IsReceiver(obj))
            {
                Retreat();
            }
        }
    }
    public void Retreat()
    {
        if (direction > 0)
        {
            Reverse();
            Invoke("Reverse", retreatDuration);
        }
    }


    public void Reverse()
{
        direction *= -1;
}
}
