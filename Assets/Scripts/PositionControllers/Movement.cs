using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    private Rigidbody rb;
    public delegate void MoveDel(Vector3 direction);
    public MoveDel moveFunc;
    public float speed = 9;
    public float grip = 0.9f;
    public string currentMovement;

    
    //public Vector3 holdPoint;
    // Use this for initialization
    void Start () {
        SetMovement(currentMovement);
        rb = GetComponent<Rigidbody>();
    }
    public void SetMovement(string moveName)
    {
        
        switch (moveName)
        {
            case "accelerate":
                moveFunc = new MoveDel(Accelerate);
                currentMovement = "accelerate";
                break;
           case "velocity":
                moveFunc = new MoveDel(Velocity);

                currentMovement = "velocity";
                break;
            case "slow":
                moveFunc = new MoveDel(Grip);

                currentMovement = "slow";
                break;
            case "none":
                moveFunc = new MoveDel(None);

                currentMovement = "none";
                break;
            default:
                print("nothing");
                // moveFunc = new MoveDel(Velocity);
                currentMovement = "nothing";
                moveFunc = new MoveDel(None);
                break;
        }
    }
    public void Grip(Vector3 direction)
    {
        rb.velocity *= grip;
    }
    public void None(Vector3 direction)
    {

    }
    public void Velocity(Vector3 direction)
    {
       // print(direction);

            gameObject.GetComponent<Rigidbody>().velocity = direction * speed * Time.deltaTime * 30f;
        

    }
    public void Accelerate(Vector3 direction)
    {

            rb.AddForce(direction * speed * Time.deltaTime * 30);
      

    }
    //gonna require some serious checks to make sure this is ok.... set a point out in direction. ray cast up and down. whichever hits, get that point. position acordingly
    //https://forum.unity.com/threads/how-to-find-objects-height-above-terrain-mesh.2708/
    public void Teleport(Vector3 direction) {
        gameObject.transform.position += direction * speed *30;
    }

}
