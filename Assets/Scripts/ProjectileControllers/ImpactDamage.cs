using UnityEngine;

public class ImpactDamage : MonoBehaviour
{
    public int minDamage = 0;
    public float impactDamage = 1;
    private Sendable to;
    public Timer effectTimer;
    public float wait = 4;
    private Projectile pro;
    void Start()
    {
        effectTimer = new Timer(wait);
       to = GetComponent<Sendable>();
        pro = GetComponent<Projectile>();
    }

    public void OnCollisionEnter(Collision impact)
    {

        if (effectTimer.Ready())
        {
            if (to.IsReceiver(impact.gameObject))
            {
                int damage = Mathf.Max(Mathf.FloorToInt(pro.damageMult * impactDamage * impact.relativeVelocity.magnitude), minDamage);
                impact.collider.gameObject.GetComponent<Health>().TakeDamage(damage);
            }
        }

    }
 }
