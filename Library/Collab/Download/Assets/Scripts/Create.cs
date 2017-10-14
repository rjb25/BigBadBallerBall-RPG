using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    //may need to call ScriptStart instead of Start due to the odd order of assignment
    //This is my way of getting around prefabs and vanishing values in editor
    //This is to be called by a random generator, or perhaps a create Gunman function
    //make the random functions (minus the spawner) all delegates, because they are all fairly the same object in new out, then you could randomize which of the functions are called. Etc etc manipulate however
    private static string[] shapes = { "sphere", "cube", "cylinder", "capsule" };
    
    public static GameObject NewObject(string shape = "sphere")
    {
        switch (shape)
        {
            case "cube":
                return GameObject.CreatePrimitive(PrimitiveType.Cube);
            case "sphere":
                return GameObject.CreatePrimitive(PrimitiveType.Sphere);
            case "capsule":
                return GameObject.CreatePrimitive(PrimitiveType.Capsule);
            case "cylinder":
                return GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            default:
                return GameObject.CreatePrimitive(PrimitiveType.Sphere);
        }
    }
    public static void HasVars(GameObject obj, int speed = 20)
    {
        obj.AddComponent<Vars>();
    }
    public static  void Scale(GameObject obj, float x = 1, float y = 1, float z = 1)
    {
        obj.transform.localScale = new Vector3(x, y, z);
    }

    public static GameObject CreateRandomObject()
    {
        return NewObject(shapes[Random.Range(0, 3)]);
    }
    public static void MakeColor(GameObject obj, int r = 0, int g = 255, int b = 0, string mode = "_Color")
    {
        Material objMaterial = obj.GetComponent<Renderer>().material;
        float alpha = objMaterial.color.a;
       objMaterial.SetColor(mode, new Color(r, g, b, alpha));
    }
    public static void SetMaterial (GameObject obj, string material)
    {
        string location = "Materials/" + material;
        obj.GetComponent<Renderer>().material = Resources.Load(location, typeof(Material)) as Material;
        
    }
    public static void SetFade(GameObject obj, int alpha = 1, string mode = "_Color")
    {
        Color color = obj.GetComponent<Material>().color;
        obj.GetComponent<Renderer>().material.SetColor(mode,new Color(color.r, color.g, color.b, alpha));
    }
    //possible problem with not being able to have Start() method use the AI as it has not yet been set
    public static void SetTargeting(GameObject obj, string[] targets, string targeting = "nearest" )
    {
        switch (targeting)
        {
            case "priority":
                obj.AddComponent<TargetsPriority>();
                obj.GetComponent<TargetsPriority>().targetByTags = targets;
                break;
            case "nearest":
                obj.AddComponent<TargetsNearest>();
                obj.GetComponent<TargetsNearest>().targetByTags = targets;
                break;
            default:
                break;
        }
    }
    public static void SetAI(GameObject obj, string AI = "move", float distance = 0, int retreatDuration = 1, float chaseRange = -1, bool relative = false, List<string> behaviourTargets = null)
    {
        switch (AI)
        {
            case "move":
                obj.AddComponent<MoveAI>();
                MoveAI script = obj.GetComponent<MoveAI>();
                script.distance = distance;
                break;
            case "kite":
                obj.AddComponent<KiteAI>();
                KiteAI script2 = obj.GetComponent<KiteAI>();
                script2.distance = distance;
                script2.relative = relative;
                break;
            case "charge":
                obj.AddComponent<Sendable>();
                Sendable to = obj.GetComponent<Sendable>();
                to.targets = behaviourTargets;

                obj.AddComponent<ChargeAI>();
                ChargeAI script3 = obj.GetComponent<ChargeAI>();
     
                script3.distance = distance;
                script3.retreatDuration = retreatDuration;
                break;
            case "accelerate":
                obj.AddComponent<AccelerateAI>();
                AccelerateAI script4 = obj.GetComponent<AccelerateAI>();
                script4.distance = distance;
                break;
            default:
                break;
        }
    }
    public static void AddImpact(GameObject obj, int dmgMin = 0, int dmgMult = 1)
    {
        obj.AddComponent<ImpactDamage>();
        ImpactDamage script = obj.GetComponent<ImpactDamage>();

        script.minDamage = dmgMin;
        script.damageMultiplier = dmgMult;
    }
    /* rigid body already pretty easy to use
    public static Rigidbody(float mass = 1, float angDrag = 0.05f, float drag = 0, float mass = 1,)
    {

    }
    */
    //one day this could be make random unit.
    //center here also means body
    public static GameObject MakeUnit(GameObject center, string name = "generic", int health = 100, int speed = 20, int maxSpeed = -1)
    {
        
        GameObject parent = new GameObject(name);
        /*
        GameObject healthBar = NewObject("cube");
        healthBar.AddComponent<AlwaysVisible>();
        healthBar.AddComponent<Follow>();
        healthBar.GetComponent<Collider>().enabled = false;
   */
        GameObject healthBox = GetPrefab("HealthBox");
        GameObject healthBar = Instantiate(healthBox);
        parent.AddComponent<Health>();
        Health healthScript = parent.GetComponent<Health>();
        healthScript.maxHealth = health;
        healthScript.healthBox = healthBar.transform;
        AddReward(center);

        HasVars(parent, speed: speed);

        Follow followScript = healthBar.GetComponent<Follow>();
        followScript.target = center;
        followScript.offset = new Vector3 (0f ,center.transform.localScale.y, 0f);

        center.AddComponent<Rigidbody>();
        center.name = "body";
        center.AddComponent<CenterMass>();
        //LOL the redundancy
        center.GetComponent<CenterMass>().center = center.transform;
        if (maxSpeed >=0)
        {
            center.AddComponent<MaxSpeed>();
            center.GetComponent<MaxSpeed>().maxSpeed = maxSpeed;
        }

        center.transform.parent = parent.transform;
        healthBar.transform.parent = parent.transform;

        return parent;
    }
    //amount should probably be moved to vars so it could be updated easily and accessed easily. Make higher worth have worth bar etc etc bounty yata yata. Plus it would be settable at make unit.
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


    public static void Charger(Vector3 location, string faction = "Enemy", string[] OpposingFactions = null)
    {
            OpposingFactions = OpposingFactions ?? new string[] { "Player", "Character"};

        GameObject body = NewObject("sphere");
        body.tag = faction;
        SetMaterial(body, faction);
        SetTargeting(body, OpposingFactions);
        SetAI(body, AI: "charge", behaviourTargets: new List<string>(OpposingFactions));
        AddImpact(body);
        
        GameObject unit= MakeUnit(body, (faction + "Charger"));
        unit.transform.position = location;

    }
    public static GameObject GetPrefab(string prefab)
    {
        string location = "Prefabs/" + prefab;
        return Resources.Load(location, typeof(GameObject)) as GameObject;
    }
    

    //public GameObject attachByJoint(GameObject parent){}
    //public GameObject attachByParenting(GameObject parent) { }
    //public GameObject AttachWithRotation(GameObject parent) { }   





}
