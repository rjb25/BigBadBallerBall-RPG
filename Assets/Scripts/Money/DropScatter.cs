using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Class that makes the coins move whene they are dropped.
public class DropScatter : MonoBehaviour {
    public int amount;
    public GameObject drop;
    public Vector3 offset;
    public float velocity = 1;

	public void OnDeath () {
		for(int i = 0; i< amount; i++)
        {
            GameObject dropped = Instantiate(drop, transform.position + offset, Quaternion.identity);
            Rigidbody rb = dropped.GetComponent<Rigidbody>();
            rb.AddForce(Random.insideUnitSphere * velocity, ForceMode.Impulse);
        }
    }
}
