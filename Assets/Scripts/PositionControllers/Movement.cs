using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This class handles object movement. It has static functions so that this could be called for various affects on any object.
public class Movement : MonoBehaviour {
    public Rigidbody rb;
    public float speed = 9;
    public float grip = 0.9f;
    public MoveDel defaultMovement;
    public bool velocity = false;
    //public Vector3 holdPoint;
    // Use this for initialization
    void Start () {
       if(defaultMovement == null)
        {
            if (velocity)
            {
                defaultMovement = Velocity;
            }
            else
            {
                defaultMovement = Accelerate;
            }
        }
        rb = GetComponent<Rigidbody>();
    }


    public static void Slow(Vector3 direction = new Vector3(), Rigidbody rb = null, float speed = 0)
    {
        rb.velocity *= Mathf.Max((100-speed),50)/100;
    }
    public static void None(Vector3 direction = new Vector3(), Rigidbody rb = null, float speed = 0)
    {

    }
    public static void Velocity(Vector3 direction = new Vector3(), Rigidbody rb = null, float speed = 0)
    {
        // print(direction);
            rb.GetComponent<Rigidbody>().velocity = direction * speed * Time.deltaTime * 30f;
        

    }
    public static void Accelerate(Vector3 direction = new Vector3(), Rigidbody rb = null, float speed = 0)
    {
        rb.AddForce(direction * speed * Time.deltaTime * 30);
    }
    //gonna require some serious checks to make sure this is ok.... set a point out in direction. ray cast up and down. whichever hits, get that point. position acordingly
    //https://forum.unity.com/threads/how-to-find-objects-height-above-terrain-mesh.2708/
    public static void Teleport(Vector3 direction = new Vector3(), Rigidbody rb = null, float speed = 0) {

        rb.gameObject.transform.position += direction * speed *30;
    }

}
