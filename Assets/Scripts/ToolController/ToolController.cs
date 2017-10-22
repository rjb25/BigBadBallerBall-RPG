using UnityEngine;


public class ToolController : MonoBehaviour
{
    public GameObject projectile;
    public GameObject buffedProjectile = null;
    public bool hasTargeting = false;
    public Actor noTarget;
    public int kick = 0;
    public int rotKick = 0;
    public int kickVert = 0;
    public int kickHor = 0;
    public bool hasKick = true;
    public bool randKick = false;
    //public string[] targets;
    // public IBuff[] buffs;
    //IBuff is an interface that will accept a GameObject and return void. Basically sets stats if object has them.
    public float reloadTime = 10;
    public bool reloaded = false;
    public Rigidbody kickWhat;
    public Rigidbody kickedRot;
    public Transform kickBy;
    private void Start()
    {
        //SetBuffed(projectile, buffs);
    }
    void OnDeath()
    {
        Destroy(projectile);
    }
    public void Use()
    {
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        projectileScript.firer = gameObject;
                   //buffedprojectile. if buffed you will need to instantiate on buff change to save on performance then just delete the old buff each change.
        //if projectile. Could have a sword using this class for reload time and kick. it would have collision as trigger and function as impact damage. NO THIS IS NOT QUITE RIGHT
        GameObject proj = Instantiate(projectile, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z) + (transform.forward*projectile.GetComponent<Projectile>().distance), gameObject.transform.rotation);
        if (!proj.activeSelf)
        {
            proj.SetActive(true);
        }
        // Targets will be handled in each projectile. Heals vs bullets, makes more sense. SetTargets(bullet, targets)
        
        if (hasKick)
        {
            ApplyKick(kickWhat,kickedRot,kickBy,randKick,kick,kickVert,rotKick,kickHor);
        }

    }
    //Have Buff be an interface for something that modifies stats of an object. Either by adding scripts, setting variables or whatever.
    //Accepts a game object, returns a gameObject. The first buff to make is basic stats. Buffs damage and speed
   
   /* public void SetBuffed(GameObject projectile, IBuff[] buffs)
    { 
       buffedProjectile = projectile;
if (buffs)
        {
            foreach(IBuff buff in buffs){
            buff(buffedProjectile);
            }
        }

      }
       
    }*/
    /*
    public void SetTargets(GameObject projectile, string[] targets)
    {
        foreach (string target in targets)
        {
            projectile.GetComponents<Sendable>()[0].targets.Add(target);
        }
    }
    */

    public static void ApplyKick(Rigidbody kickWhat, Rigidbody kickRot,Transform kickBy, bool frandKick = false, int fkick = 0, int fkickVert = 0, int frotKick = 0, int fkickHor = 0)
    {
       
        if (frandKick)
        {
            fkick = Mathf.FloorToInt(Random.value * fkick);
            fkickVert = Mathf.FloorToInt(Random.value * fkickVert);
            frotKick = Mathf.FloorToInt(Random.value * frotKick);
            fkickHor = Mathf.FloorToInt(Random.value * fkickHor);
        }
        if (fkick != 0)
        {
            kickWhat.AddForce(kickBy.forward * -fkick);
        }
        if (fkickVert != 0)
        {
            kickWhat.AddForce(kickBy.up * fkickVert);
        }
        if (frotKick != 0)
        {
            kickRot.AddTorque(new Vector3(0f, frotKick, 0f));
        }
        if (fkickHor != 0)
        {
            kickWhat.AddForce(kickBy.right * fkickHor);
        }
    }
    public void IsActive()
    {
        if (reloaded)
        {
            Invoke("Reload", reloadTime);
            reloaded = false;
            Use();
        }
    }
    public void Reload()
    {
        reloaded = true;
    }

}