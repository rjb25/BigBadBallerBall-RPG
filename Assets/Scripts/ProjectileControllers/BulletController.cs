using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IAffect {
    public int collisionsAllowed = 1;
    private int collisionCount = 0;
    public int damage = 0;
    public void Affects(GameObject collider, Collision collision)
    {
        collider.GetComponentInParent<Health>().TakeDamage(damage);
        if (collisionsAllowed >= 0)
        {
            collisionCount += 1;
            if (collisionCount >= collisionsAllowed)
            {
                Destroy(gameObject);
            }
        }
    }
}
