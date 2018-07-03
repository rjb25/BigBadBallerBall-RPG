using UnityEngine;

//Anything that has a use. Includes the reload time, kick and if available spawning of said use.
//Pretty much the gun controller.
public class Boost : MonoBehaviour
{
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
    public Trigger trs2;
    public bool autoUse = false;
    private Rigidbody playerRotation;


    private void Start()
    {
        lastUse = Time.time-reloadTime;

            PlayerController ps = GetComponent<PlayerController>();
            trs2 = gameObject.AddComponent<Trigger>();
            trs2.Set(activate: Use, active: Use);
            trs2.condition = () => Input.GetMouseButtonDown(0) && ps.enabled;
            kickedRot = GetComponent<Rigidbody>();
        

    }
    public void Use()
    {
        if (Time.time > lastUse + (reloadTime))
        {

            lastUse = Time.time;

            ApplyKick(kickWhat, kickedRot, kickBy, randKick, kick, kickVert, rotKick, kickHor);


        }

    }
    public static int RandomSign(){
            return (int)((Random.Range(0, 2) - 0.5) * 2);
        }
public static void ApplyKick(Rigidbody kickWhat, Rigidbody kickRot,Transform kickBy, bool frandKick = false, int fkick = 0, int fkickVert = 0, int frotKick = 0, int fkickHor = 0)
    {
  
        if (frandKick)
        {
            //fkick = Mathf.FloorToInt(Random.value * fkick);
            fkickVert = Mathf.FloorToInt(Random.value * fkickVert);
            frotKick = Mathf.FloorToInt(frotKick);
            fkickHor = Mathf.FloorToInt(Random.value * fkickHor) * RandomSign();
        }
        if (fkick != 0)
        {
            kickWhat.AddForce(Vector3.Normalize(Vector3.Scale(kickBy.forward, new Vector3(1,0,1))) * fkick);
        }
        if (fkickVert != 0)
        {
            kickWhat.AddForce(kickBy.up * fkickVert);
        }
        if (frotKick != 0)
        {
            kickRot.AddTorque(kickBy.right*frotKick);
        }
        if (fkickHor != 0)
        {
            kickWhat.AddForce(kickBy.right * fkickHor);
        }
    }

}