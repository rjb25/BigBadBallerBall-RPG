using UnityEngine;
using System.Collections.Generic;
//Merge all projectile classes

public class BombDamage : MonoBehaviour
{
    public float radius = 5.0F;
    public int damage = 5;
    //how much damage disapates with range.
    public float rangeMult = 1;
    private Sendable to;
    public Projectile pro;
    void Start()
    { 
        to = GetComponent<Sendable>();
        pro = GetComponent<Projectile>();
    }


    void OnCollisionEnter(Collision impact)
    {
        if (to.IsReceiver(impact.gameObject))
        {
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                
                if (to.affected.Contains(hit.gameObject.tag))
                {

                    float distance = Vector3.Distance(explosionPos, hit.transform.position);
                    hit.gameObject.GetComponentInParent<Health>().TakeDamage(damage / (Mathf.FloorToInt(distance * rangeMult) +1));
                }

            }
        }
    }
}
