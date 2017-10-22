using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float spawnRate = 5;
    public Transform spawned;
    public float amount = -1;
    private int count = 0;
    private float timeLeft;
    public int yOffset = 1;
    // Use this for initialization
    void Start () {
        timeLeft = spawnRate;

    }

	// Update is called once per frame
	void FixedUpdate () {
        if(amount > 0 && amount <= count)
        {
            Destroy(gameObject);
        }
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            count += 1;
            Instantiate(spawned, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + yOffset, gameObject.transform.position.z), Quaternion.identity); ;
            timeLeft = spawnRate;
        }
    }
}
