using UnityEngine;

public class BomberController : ToolScript
{
    public GameObject projectile;
    public float shotSpeed = 10;
    public string[] targets;
    public override void Use()
    {
        var bullet = Instantiate(projectile, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), gameObject.transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = transform.up * shotSpeed;
        base.SetTargets(bullet, targets);

    }
}
