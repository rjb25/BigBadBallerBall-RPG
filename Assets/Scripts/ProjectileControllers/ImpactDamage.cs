using UnityEngine;

public class ImpactDamage : MonoBehaviour
{
    public int minDamage = 0;
    public float impactDamage = 1;
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
            int damage = Mathf.Max(Mathf.FloorToInt(pro.damageMult * impactDamage * impact.relativeVelocity.magnitude), minDamage);
            impact.collider.gameObject.GetComponent<Health>().TakeDamage(damage);
        }

    }
 }
