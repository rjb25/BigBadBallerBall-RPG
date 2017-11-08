using UnityEngine;

//Anything that has a use. Includes the reload time, kick and if available spawning of said use.
//Pretty much the gun controller.
public class ToolController : MonoBehaviour
{
    public GameObject projectile;
    public GameObject buffedProjectile = null;
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
    public float lastUse;
    public Rigidbody kickWhat;
    public Rigidbody kickedRot;
    public Transform kickBy;
    public Trigger trs;
    public bool autoUse = false;
    public void ToggleAuto()
    {
        autoUse = !autoUse;
        trs.enabled = autoUse;
    }
        
    private void Start()
    {
        lastUse = Time.time;
        //SetBuffed(projectile, buffs);
        
            trs = gameObject.AddComponent<Trigger>();
            trs.Set(activate: Use);
            trs.condition = () => Time.time > lastUse + reloadTime;
            trs.enabled = autoUse;
        
    }
    void OnDeath()
    {
        Destroy(projectile);
    }
    public void Use()
    {
        if (Time.time > lastUse + reloadTime)
        {
            lastUse = Time.time;

            Projectile ps = projectile.GetComponent<Projectile>();
            ps.firer = gameObject;
            //buffedprojectile. if buffed you will need to instantiate on buff change to save on performance then just delete the old buff each change.
            //if projectile. Could have a sword using this class for reload time and kick. it would have collision as trigger and function as impact damage. NO THIS IS NOT QUITE RIGHT
            GameObject proj = Instantiate(projectile, gameObject.transform.position + (transform.forward * ps.distance), gameObject.transform.rotation);
            if (!proj.activeSelf)
            {
                proj.SetActive(true);
            }
            proj.GetComponent<Movement>().defaultMovement = projectile.GetComponent<Movement>().defaultMovement;
            // Targets will be handled in each projectile. Heals vs bullets, makes more sense. SetTargets(bullet, targets)

            if (hasKick)
            {
                ApplyKick(kickWhat, kickedRot, kickBy, randKick, kick, kickVert, rotKick, kickHor);
            }
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

}