using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
//A series of functions used to create things. Basically coded prefabs.
public class Create : MonoBehaviour
{
    //This is my way of getting around prefabs and vanishing values in editor. Also it allows for nested prefabs. I am not sure if I want all objects to be generated in this manner.
    //This is to be called by a random generator, or perhaps a create Gunman function
    //make the random functions (minus the spawner) all delegates, because they are all fairly the same object in new out, then you could randomize which of the functions are called. Etc etc manipulate however
    private static string[] shapes = { "sphere", "cube", "cylinder", "capsule" };
    #region basic
    public static GameObject NewObject(string shape = "sphere")
    {
        GameObject obj;
        switch (shape)
        {
            case "cube":
                obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                break;
            case "sphere":
                obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                break;
            case "capsule":
                obj =  GameObject.CreatePrimitive(PrimitiveType.Capsule);
                break;
            case "cylinder":
                obj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                break;
            case "empty":
                obj = new GameObject("empty");
                break;
            default:
                obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                break;
           
        }
        //obj.SetActive(false);
        return obj;
    }
    public static Rigidbody AddRigidbody(GameObject obj, float mass = 1, float angDrag = 0.05f, float drag = 0, bool gravity = true, bool kinetic = false, bool noRot = false)
    {
        Rigidbody rb = obj.AddComponent<Rigidbody>();
        rb.mass = mass;
        rb.angularDrag = angDrag;
        rb.drag = drag;
        rb.useGravity = gravity;
        rb.isKinematic = kinetic;
        
        if (noRot)
        {
            rb.freezeRotation = true;
        }
        return rb;
    }

    public static void SetScale(GameObject obj, float x = 1, float y = 1, float z = 1, float mult = 1)
    {
        Transform tObj = obj.transform;

            tObj.localScale = new Vector3(x*mult,y*mult,z*mult);

    }
    public static void ModScale(GameObject obj, float x = 1, float y = 1, float z = 1, float mult = 1)
    {
        Transform tObj = obj.transform;
            tObj.localScale = new Vector3(tObj.localScale.x*x*mult, tObj.localScale.y*y*mult, tObj.localScale.z*z*mult);
        
    }

    public static GameObject GetPrefab(string prefab, bool instantiate = false)
    {
        string location = "Prefabs/" + prefab;
        GameObject nonexistent = Resources.Load(location, typeof(GameObject)) as GameObject;
        if (instantiate == false)
        {
            return nonexistent;
        }
        else
        {
            return Instantiate(nonexistent);
        }

    }
    
    public static void SetColor(GameObject obj, Color color, string mode = "_Color")
    {

        Renderer rend = obj.GetComponent<Renderer>();
        color.a = rend.material.color.a;
        rend.material.SetColor(mode, color);
    }
    public static void SetMaterial(GameObject obj, string material)
    {
        string location = "Materials/" + material;
        obj.GetComponent<Renderer>().material = Resources.Load(location, typeof(Material)) as Material;

    }
    public static void SetFade(GameObject obj, int alpha = 1, string mode = "_Color")
    {
        Color color = obj.GetComponent<Material>().color;
        obj.GetComponent<Renderer>().material.SetColor(mode, new Color(color.r, color.g, color.b, alpha));
    }
    #endregion
    #region target involved
    public static void AddReward(GameObject obj, int amount = 1, GameObject Drop = null, Vector3 offset = new Vector3(), float velocity = 0.001f)
    {
        if (Drop == null)
        {
            Drop = GetPrefab("Coin");
        }
        obj.AddComponent<DropScatter>();
        DropScatter script = obj.GetComponent<DropScatter>();
        script.amount = amount;
        script.drop = Drop;
        script.offset = offset;
        script.velocity = velocity;
    }

    public static Targeting AddTargeting(GameObject obj, string method = "nearest", float targetingSpeed = 3, int targetingRange = 100, float retargetingSpeed = 3, string newTargetOn = "", string waiting = "nothing")
    {
        Targeting ts = obj.AddComponent<Targeting>();
        ts.targeting = method;
        ts.whileWaitingType = waiting;
        ts.targetingSpeed = targetingSpeed;
        ts.targetingRange = targetingRange;
        ts.retargetingSpeed = retargetingSpeed;
        ts.newTargetOn = newTargetOn;
        //Actor is a void delegate.

        return ts;
    }
    //Needs major updating for new singular AI file.
    //Someway to allow these to be setters aswell?

    public static void AddSendable(GameObject obj)
    {
        Sendable to = obj.AddComponent<Sendable>();
    }
    public static void AddMovement(GameObject obj, float speed = 30, MoveDel movement = null)
    {
        Movement ms = obj.AddComponent<Movement>();
        ms.speed = speed;
        ms.defaultMovement= movement;
    }
    public static AI AddAI(GameObject obj, float distance = 0, int retreatDuration = 1, float chaseRange = -1, bool relative = false, string ai = "charge", bool onDeath = true, float pointSpeed = 0.1f, int pursueRange = 1000, Vector3 basePoint = new Vector3())
    {
        
        AI ais = obj.AddComponent<AI>();
        ais.pointSpeed = pointSpeed;
        ais.retreatDuration = retreatDuration;
        ais.basePoint = basePoint;
        ais.pursueRange = pursueRange;
        ais.distance = distance;
        switch (ai)
        {
            case "hold":
                ais.kites = false;
                ais.charges = false;
                ais.hold = true;
                break;
            case "charge":
                ais.kites = false;
                ais.charges = true;
                ais.hold = false;
                break;
            case "kite":
                ais.kites = true;
                ais.charges = false;
                ais.hold = false;
                break;
            default:
                ais.kites = false;
                ais.charges = false;
                ais.hold = false;
                break;
        }

        return ais;
    }
    public static void AddImpact(GameObject obj, int dmgMin = 0, int dmgMult = 1)
    {
        obj.AddComponent<ImpactDamage>();
        ImpactDamage script = obj.GetComponent<ImpactDamage>();

        script.minDamage = dmgMin;
        script.impactDamage = dmgMult;
    }
    #endregion
    #region assembling
    public static void AddHealth(GameObject toWhat,int  health = 50)
    {
        GameObject healthBox = GetPrefab("HealthBox");
        GameObject healthBar = Instantiate(healthBox);
        Follow followScript = healthBar.GetComponent<Follow>();
        followScript.target = toWhat;
        followScript.offset = new Vector3(0f, toWhat.transform.localScale.y, 0f);
        
        Health healthScript = toWhat.AddComponent<Health>();
        healthScript.maxHealth = health;
        healthScript.healthBox = healthBar.transform;
        SetScale(healthBar, 1,0.1f,0.1f);
        ModScale(healthBar, x: ((float)health) / 100);
        healthBar.transform.parent = toWhat.transform.parent.transform;

    }
    public static GameObject MakeUnit(GameObject center, string name = "generic", int health = 100, int speed = 20, int maxSpeed = -1, bool frozen = true)
    {

        GameObject parent = new GameObject(name);

        AddRigidbody(center,noRot:frozen);

        center.name = "body";
        center.AddComponent<CenterMass>();
        //LOL the redundancy
        center.GetComponent<CenterMass>().center = center.transform;
        if (maxSpeed >= 0)
        {
            center.AddComponent<MaxSpeed>();
            center.GetComponent<MaxSpeed>().maxSpeed = maxSpeed;
        }
        center.transform.parent = parent.transform;


        AddHealth(center, health);
        return parent;
    }

    //amount should probably be moved to vars so it could be updated easily and accessed easily. Make higher worth have worth bar etc etc bounty yata yata. Plus it would be settable at make unit.
    public static void AddLoadout(string name, GameObject to, bool equip = false)
    {

        Equipment es = to.GetComponent<Equipment>();
        if (!es)
        {
            es = to.AddComponent<Equipment>();
        }
        if (!es.available.ContainsKey(name))
        {
           
            GameObject loadout = Instantiate(GetPrefab(name), to.transform.position, to.transform.rotation, to.transform.parent);
            
            es.NewAvailable(name, loadout);
            
            GetRefs(loadout);
            /*
            for (int i = 0; i < loadout.transform.childCount; i++)
            {
                GameObject Go = loadout.transform.GetChild(i).gameObject;

                if (Go.GetComponent<IsRef>())
                {
                    GameObject oldGo = Go;
                    Go = Instantiate(GetPrefab(Go.name), Go.transform.position, Go.transform.rotation, Go.transform.parent);
                    Destroy(oldGo);
                }
            }*/
            loadout.SetActive(false);
        }
        else
        {

            print("already has loadout");
        }
        if (equip)
        {
            es.currentNum = es.availableCount;
            EquipLoadout(name, to);
        }
    }

    //cannot find prefabs that are in folders currently. Due to GetPrefabs limitations.
    //Could be done, simply add a directory to is ref. Then pass that to get prefab.
    public static void GetRefs(GameObject parent)
    {
        
        if (parent)
        {
            int length = parent.transform.childCount;
            for (int i = 0; i < length; i++)
            {
                GameObject childRef = parent.transform.GetChild(i).gameObject;

                GameObject child;
                if (childRef.GetComponent<IsRef>())
                {
                    GameObject prefab = GetPrefab(childRef.name);
                    if (prefab)
                    {
                        child = Instantiate(prefab, childRef.transform.position, childRef.transform.rotation, childRef.transform.parent);
                        childRef.transform.parent = GameObject.Find("GlobalScripts").transform;
                        Destroy(childRef);
                    }
                    else
                    {
                        child = null;
                        print("could not find prefab reference");
                    }
                }
                else
                {
                    child = childRef;
                }
                //Recursive check if children have children, then apply to them as well.
                GetRefs(child);
            }
        }
    }

    public static void AddFaction(GameObject go, string faction = "Enemy")
    {
        Faction fs = go.AddComponent<Faction>();
        fs.faction = faction;
    }
    public static void EquipLoadout(string name, GameObject to/*, string faction*/)
    {
        DequipLoadout(to);
        Equipment es = to.GetComponent<Equipment>();
        GameObject loadout;
        if (es.available.ContainsKey(name))
        {
            loadout = es.available[name];
            loadout.SetActive(true);
            GameObject start = GetPrefab(name);
            for (int i = 0; i < start.transform.childCount; i++)
            {
                GameObject Go = loadout.transform.GetChild(i).gameObject;
                /*
                if (loadout.transform.childCount == 2) {
                    print(loadout.transform.childCount + " " + loadout.name + loadout.transform.GetChild(0).name + loadout.transform.GetChild(1).name);
                }*/
                GameObject startGo = start.transform.GetChild(i).gameObject;
                AttachFixed(Go, to, startGo.transform.localPosition);
            }
            es.current = loadout;
        }
        else
        {
            print("trying to equip loadout not posessed");
        }
        
    }
    public static void DequipLoadout(GameObject from)
    {
        GameObject current = from.GetComponent<Equipment>().current;
        if (current)
        {
            current.SetActive(false);
            //Destroy(current);
        }
    }
    public static void AttachFixed(GameObject obj, GameObject to, Vector3 displacement)
    {
        obj.transform.position = to.transform.position + (to.transform.rotation * displacement);
        obj.transform.rotation = to.transform.rotation;
        Variables vs = obj.GetComponent<Variables>();
        if (vs)
        {

        }
        else
        {
            vs = obj.AddComponent<Variables>();
        }
        FixedJoint already = obj.GetComponent<FixedJoint>();
        if (already)
        {
            Destroy(already);
        }
        CenterMass center = obj.GetComponent<CenterMass>();
        if (center)
        {
            center.center = to.transform;
        }
        ToolController ts = obj.GetComponent<ToolController>();
        if (ts)
        {
            ts.SetHolder(to);
        }
        vs.displacement = displacement;
        FixedJoint joint = obj.AddComponent<FixedJoint>();
        joint.connectedBody = to.GetComponent<Rigidbody>();

    }
    #endregion
    #region creators
    
    public static GameObject Sword(List<string> targets)
    {
        GameObject rail = NewObject("cube");
        SetMaterial(rail, "Steel");
        AddRigidbody(rail,gravity: false);
        AddSendable(rail);

        ImpactDamage ims = rail.AddComponent<ImpactDamage>();
        ims.impactDamage = 1;
        SetScale(rail, 0.1f, 0.1f);
        return rail;
    }
    public static GameObject Gun(List<string> targets, bool autoFire = false, int reloadTime = 10, float level = 1)
    {

        GameObject rail = NewObject("cube");
        SetMaterial(rail, "Gun");
        GameObject projectile = NewObject("sphere");
        SetMaterial(projectile, "Gun");
        AddRigidbody(projectile, 0.01f, gravity: false, noRot: true);
        AddSendable(projectile);
        AddProjectile(projectile, firer: rail, collisionsAllowed: 0, distance: 0.7f);
        /* tracking
        AddTargeting(projectile,  targets.ToArray(),targetingSpeed:-1f,targetingRange:1000, newTargetOn: "kill",waiting:"forward");
        AddAI(projectile,ai: "none",pointSpeed: 1,relative:true);
        */
        AddMovement(projectile, speed: 30f, movement: Movement.Velocity);
        projectile.transform.SetParent( rail.transform,true);
        projectile.AddComponent<Move>();
       
        AddRigidbody(rail, gravity: false);
       
        HitDamage hs = projectile.AddComponent<HitDamage>();
        hs.damage = 20;
        projectile.SetActive(false);
        ModScale(projectile, mult: 0.1f);
        Duration ds = projectile.AddComponent<Duration>();
        ds.duration = 15f;
        AddSpawner(rail, projectile, reloadTime: reloadTime, auto:autoFire);
        SetScale(rail, 0.1f, 0.1f);
        return rail;
    }
    public static GameObject Charger(Vector3 location, string faction = "Enemy", float acceleration = 15,  float speed = 10,int reward = 1, string ai = "charge", float level = 1)
    {

        GameObject body = NewObject("sphere");
        body.tag = faction;
        SetMaterial(body, faction);
        AddTargeting(body,  newTargetOn: "kill");
        AddAI(body, ai:ai, pointSpeed: -1);
        AddMovement(body,movement:Movement.Accelerate, speed:acceleration);
        AddSendable(body);
        AddProjectile(body);
        AddImpact(body);
        if (faction != "Player")
        {
            AddReward(body, amount: reward);
        }

        GameObject unit= MakeUnit(body, (faction + "Charger"), health: Mathf.FloorToInt(10 * level), frozen: false);
        AddFaction(unit,faction);
        unit.transform.position = location;
        return unit;

    }

    public static GameObject Townhall(Vector3 location, string faction = "Player")
    {

        GameObject parent = new GameObject(faction + " Townhall");
        
        GameObject body = NewObject("cube");
        body.name = "body";
        body.transform.parent = parent.transform;
        body.tag = faction;
        SetMaterial(body, faction);
        body.transform.position = location;
        ModScale(body,mult:1f);
        AddHealth(body,150);

        return body;
    }
    public static GameObject Gunner(Vector3 location, string faction = "Enemy", float acceleration = 30, float speed = 10, float pointSpeed = 0.0001f, MoveDel movement = null, int reward = 1, int targetingRange = 1000, string ai = "kite", float level = 1)
    {
        //Next make it so that the bodies are grabbed from prefabs.
        GameObject body = NewObject("sphere");
        body.tag = faction;
        SetMaterial(body, faction);

        Targeting ts = AddTargeting(body, targetingRange: targetingRange, newTargetOn: "interval", targetingSpeed: -1, waiting: "hold");
        AddAI(body, ai: ai, distance: 20, pointSpeed: pointSpeed);
        AddMovement(body, movement: movement, speed: acceleration);
        //This should be in movement to only disable movement if speed greater than max. This would mean things cant be hit far.
        MaxSpeed ms = body.AddComponent<MaxSpeed>();
        ms.maxSpeed = speed;

        GameObject unit = MakeUnit(body, (faction + "Gunner"), health: Mathf.FloorToInt(10 * level));
        unit.transform.position = location;
        if (faction != "Player")
        {
            AddReward(body, amount: reward);
        }

        AddFaction(unit, faction);
        AddLoadout("Gunny",body,true);
        return unit;
        //\rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
    /*
    public static GameObject Gunner(Vector3 location, string faction = "Enemy", string[] OpposingFactions = null, float acceleration = 15, float speed = 10, float pointSpeed = 0.0001f,MoveDel movement = null, int reward = 1, int targetingRange = 1000, string ai = "kite", float level = 1)
    {
        OpposingFactions = OpposingFactions ?? new string[] { "Player", "Character" };

        GameObject body = NewObject("sphere");
        body.tag = faction;
        SetMaterial(body, faction);
     
        Targeting ts = AddTargeting(body,targetingRange:targetingRange, newTargetOn: "interval",targetingSpeed: -1,waiting: "hold");
     AddAI(body, ai:ai, distance: 20,pointSpeed: pointSpeed);
        AddMovement(body, movement: movement, speed: acceleration);
        MaxSpeed ms = body.AddComponent<MaxSpeed>();
        ms.maxSpeed = speed;
        

        
        
        GameObject unit = MakeUnit(body, (faction + "Gunner"), health: Mathf.FloorToInt(10 *level));
        unit.transform.position = location;
        GameObject gun = Gun(new List<string>(OpposingFactions),autoFire: true);
        gun.transform.parent = unit.transform;
        if (faction != "Player")
        {
            AddReward(body, amount: reward);
        }
        AttachSpawner(gun, body, displacement: new Vector3(0, 0, 1.5f));
        AddFaction(unit, faction);
        return unit;
        //\rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

       
        
    }*/
    //different method for spot lights as rotation is involved.
    public static GameObject ALight(Vector3 position, Color? color = null, float range = 10, float intensity = 1f, float indirect = 0, Vector3 angle = new Vector3(), LightType? type = null)
    {


        GameObject lightGameObject = new GameObject("The Light");
        GameObject sphere = NewObject("sphere");
        SetMaterial(sphere, "Emissive");
        SetColor(sphere, color ?? Color.white, "_EmissionColor");


        sphere.transform.parent = lightGameObject.transform;
        Light lightComp = lightGameObject.AddComponent<Light>();
        lightComp.color = color ?? Color.white;
        lightGameObject.transform.position = position;
        lightComp.range = range;
        lightComp.intensity = intensity;
        lightComp.bounceIntensity = indirect;
        lightGameObject.transform.eulerAngles = angle;

        lightComp.type = type ?? LightType.Point;
        return lightGameObject;
    }
    #endregion
    #region spawner


    //Make a master projectile creator for randomization. Takes list of behaviours to add, and randomizes their inputs. SetProjectileAspects
    public static void AddProjectile(GameObject obj, GameObject firer = null, GameObject spawner = null, int collisionsAllowed = -1, float damageMult = 1, float distance = 1)
    {
        Projectile ps = obj.AddComponent<Projectile>();
        ps.firer = firer;
        ps.spawner = spawner;
        ps.collisionsAllowed = collisionsAllowed;
        ps.damageMult = damageMult;
        ps.distance = distance;

    }
    //may want isPlayers to be isSeperate. That way its easy to add shields and such to things. that need seperate collisions. Add rotate about and have velocity of (var) have rot of (var)
    public static void AttachSpawner(GameObject spawner, GameObject body, GameObject kicked = null, GameObject kickedRot = null, Vector3 displacement = new Vector3()/*, bool isPlayers = false*/)
    {
        kicked = kicked ?? body;
        kickedRot = kickedRot ?? body;
        ToolController toolScript = spawner.GetComponent<ToolController>();
        toolScript.kickWhat = kicked.GetComponent<Rigidbody>();
        toolScript.kickedRot = kickedRot.GetComponent<Rigidbody>();
        AttachFixed(spawner, body, displacement);
        
        /*
        if (isPlayers)
        {
            RotateAbout
        }*/
    }

    
    public static void AddSpawner( GameObject spawner, GameObject projectile, GameObject kickBy = null, int kick = 0, int kickVert = 0, int kickRot = 0, int kickHor = 0, float reloadTime = 10, bool randKick = false, bool hasKick = true, bool auto = false /*,Buff[]? buffs = null*/)
    {
            kickBy = kickBy ?? spawner;
        
        ToolController toolScript = spawner.AddComponent<ToolController>();
        toolScript.autoUse = auto;
        toolScript.projectile = projectile;
        toolScript.kick = kick;
        toolScript.kickBy = kickBy.transform;
        toolScript.kickVert = kickVert;
        toolScript.kickHor = kickHor;
        toolScript.rotKick = kickRot;
        toolScript.randKick = randKick;
        toolScript.hasKick = hasKick;
        toolScript.reloadTime = reloadTime;
    }
    #endregion
    #region audio
    public void Sound(string name, Vector3? location = null, float duration = -1, int times = 1, GameObject altLocation = null, float volume = 1f)
    {
        AudioClip clip = Resources.Load<AudioClip>("Sounds/"+name);
        if (duration < 0)
        {
            duration = clip.length;
        }
    
       
        Vector3 pos;
        if (altLocation != null)
        {
            pos = altLocation.transform.position;
        }
        else
        {
            pos = location ?? GameObject.Find("Main Camera").transform.position;
        }
        StartCoroutine(SoundRepeat(clip, pos, duration, times, volume));
    }



    public IEnumerator SoundRepeat(AudioClip clip, Vector3 location, float duration, int number, float volume)
    {
        int i = 0;
        while (i < number)
        {
            AudioSource.PlayClipAtPoint(clip, location, volume);
            yield return new WaitForSeconds(duration); //wait 1 second per interval
            i++;
        }
    }
    #endregion






}
