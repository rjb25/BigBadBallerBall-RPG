using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDamage : MonoBehaviour {
    public int damage = 1;
    private Sendable to;
    public Projectile pro;
    void Start()
    {
        to = GetComponent<Sendable>();
        pro = GetComponent<Projectile>();
    }

    public void OnCollisionEnter(Collision impact)
    {
        if (to.IsReceiver(impact.gameObject))
        {
            int theDamage = Mathf.FloorToInt(damage * pro.damageMult);
            impact.gameObject.GetComponentInParent<Health>().TakeDamage(theDamage);
        }

    }
}
