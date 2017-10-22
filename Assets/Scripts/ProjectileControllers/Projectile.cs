using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//obsolete will be implemented in create eapon on create class. and or create bullet of create class
public class Projectile : MonoBehaviour {
    public int collisionsAllowed = 1;
    private int collisionCount = 0;
    public GameObject firer;
    public GameObject spawner;
    public float damageMult = 1;
    public float distance;
    public Sendable to;
    private void Start()
    {

        to = GetComponent<Sendable>();
    }
    public void OnCollisionEnter(Collision collision)
    {//could do broadcast from  Sendable
        if (to.IsReceiver(collision.gameObject))
        {
            if (collisionsAllowed >= 0)
            {
                collisionCount += 1;
                if (collisionCount >= collisionsAllowed)
                {
                    Destroy(gameObject);
                }
            }
        }
        //possibly
    }
}
