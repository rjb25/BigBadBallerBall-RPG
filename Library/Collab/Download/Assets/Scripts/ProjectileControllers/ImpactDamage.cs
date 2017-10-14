using UnityEngine;

public class ImpactDamage : MonoBehaviour, IAffect
{
    public int minDamage = 0;
    public float damageMultiplier = 1;
    void Start()
    {

    }

    public void Affects(GameObject collision, Collision impact = null)
    {
            int damage = Mathf.Max(Mathf.FloorToInt(damageMultiplier * impact.relativeVelocity.magnitude), minDamage);
            impact.collider.gameObject.GetComponentInParent<Health>().TakeDamage(damage);

    }
 }
