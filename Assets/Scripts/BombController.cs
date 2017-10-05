using UnityEngine;

public class BombController : MonoBehaviour
{
    public int damage = 50;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            collision.collider.gameObject.GetComponentInParent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}