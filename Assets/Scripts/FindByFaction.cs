using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindByFaction : MonoBehaviour {
    public Dictionary<string/*faction*/, List<GameObject> /*objects of that faction*/> targetables;
	// Use this for initialization
	void Start () {
        targetables = new Dictionary<string, List<GameObject>>();
	}
	
	// Update is called once per frame
	void Update () {
		//routine that checks FindByFaction every minute for empties and removes them for less parsing.
	}
    public List<GameObject> GetGOWithFaction(string faction)
    {
        return targetables[faction];
    }
}
