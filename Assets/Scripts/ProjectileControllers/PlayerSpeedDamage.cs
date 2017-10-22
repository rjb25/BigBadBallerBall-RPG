using UnityEngine;

public class PlayerSpeedDamage : MonoBehaviour
{
    public int minDamage = 0;
    public float damageMultiplier = 1;
    public float rotationDmgMult = 1;
    public float velocityDmgMult = 1;
    public bool onlyPlayerVelocity = true;
    public float reloadTime = 1;
    private bool reloaded = true;
    private Rigidbody playerRotation;
    private Sendable to;
    private Rigidbody playerVelocity;
    void Start()
    {
        to = GetComponent<Sendable>();
        playerRotation = GameObject.Find("PlayerRotation").GetComponent<Rigidbody>();
        playerVelocity = GameObject.Find("PlayerBody").GetComponent<Rigidbody>();
    }

    public void OnCollisionEnter(Collision impact)
    {
        
        GameObject collision = impact.gameObject;
        if (reloaded && to.IsReceiver(collision))
        {
            reloaded = false;
            Invoke("Reload", reloadTime);
            float relativeVelocity;
            if (onlyPlayerVelocity)
            {
                relativeVelocity = Vector3.Magnitude(playerVelocity.velocity);
            }
            else
            {
                relativeVelocity = Vector3.Magnitude(playerVelocity.velocity - collision.GetComponent<Rigidbody>().velocity);
            }
            
            int damage = Mathf.Max(Mathf.FloorToInt(damageMultiplier * (relativeVelocity * velocityDmgMult + playerRotation.angularVelocity.magnitude * rotationDmgMult)), minDamage);
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(damage);
        }

    }
    public void Reload()
    {
 
        reloaded = true;
    }
 }
