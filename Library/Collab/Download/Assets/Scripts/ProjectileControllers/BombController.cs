using UnityEngine;

public class BombController : MonoBehaviour , IAffect
{
    public float radius = 5.0F;
    public float power = 10.0F;
    public int damage = 5;
    public void Affects(GameObject collider, Collision collision)
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {

            if (gameObject.GetComponent<Sendable>().targets.Contains(hit.gameObject.tag))
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
                }
                float distance = Vector3.Distance(explosionPos, hit.transform.position);
                hit.gameObject.GetComponentInParent<Health>().TakeDamage(damage / (Mathf.FloorToInt(distance + 1)));
            }

        }
        Destroy(gameObject);
    }
}
