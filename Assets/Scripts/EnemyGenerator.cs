using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this is the class that controls enemy spawning.
public class EnemyGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InvokeRepeating("Repeating", 5f, 10f);
    }
    void Repeating()
    {
        //Create.RandomUnit(new Vector3(0f, 0.5f, 14f), "Enemy", null, level: Time.time / 50);
        Create.Charger(new Vector3(0f, 0.5f, 14f), "Enemy", null, level: Time.timeSinceLevelLoad / 50);
        Create.Gunner(new Vector3(0f, .5f, -14f), "Enemy", null, level: Time.timeSinceLevelLoad / 50);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
