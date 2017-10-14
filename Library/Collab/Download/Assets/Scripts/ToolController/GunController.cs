using UnityEngine;


public class GunController : ToolScript
{
    public GameObject projectile;
    public float shotSpeed = 10;
    public int kick = 0;
    public string[] targets;
    public Rigidbody kickWhat;

    public override void Use()
    {
        var bullet = Instantiate(projectile, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), gameObject.transform.rotation);
        base.SetTargets(bullet, targets);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward*shotSpeed;
        kickWhat.AddRelativeForce(Vector3.forward *-kick);
    }

}