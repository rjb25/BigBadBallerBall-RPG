using UnityEngine;
//The player has weird rotation so that they can have acceleration movement but not have to deal with being rotated by other objects.
//This is a player specific class to allow for weapons to deal damage based on player movement and rotation speed.
//It is not the same as impact damage.
public class PlayerSpeedDamage : MonoBehaviour
{
    public int minDamage = 0;
    public float 
        iplier = 1;
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
            
            int damage = Mathf.Max(Mathf.FloorToInt((relativeVelocity * velocityDmgMult + playerRotation.angularVelocity.magnitude * rotationDmgMult)), minDamage);
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(damage);
        }

    }
    public void Reload()
    {
 
        reloaded = true;
    }
 }
