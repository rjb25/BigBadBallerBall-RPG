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
        Create.Unit(RandomPosition(), "ChargerBody", "Enemy", level: 1);
        if (Time.timeSinceLevelLoad / 50 > 30)
        {
            Create.Unit(RandomPosition(), "KiterBody", "Enemy", "Gunny", level: 1);
        }
    }
    // Update is called once per frame
    public Vector3 RandomPosition()
    {
        Vector2 direction = Random.insideUnitCircle;
        float distance = Random.Range(0,30);
        Vector2 position = (direction * distance)+(direction * 16);
        Vector3 location = new Vector3(position.x,0.5f,position.y);
        return location;
    }
    void Update () {
	}
}
