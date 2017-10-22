using UnityEngine;

public class HealController : MonoBehaviour
{
    public int collisionsAllowed = 1;
    private int collisionCount = 0;
    public int heal = 10;
    public void Affects(GameObject collider, Collision collision)
    {
        Health health = collider.GetComponentInParent<Health>();
        int healthMax = health.maxHealth;
        int healthCurrent = health.currentHealth;
        int healthDifference = healthMax - healthCurrent;

        if (healthDifference > 0)
        {
            health.TakeDamage(-heal);
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
}
