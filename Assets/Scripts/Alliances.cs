using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Alliances : MonoBehaviour {

    public Dictionary<string, HashSet<string>> alliances;
    // Use this for initialization
    void Start () {
        alliances = new Dictionary<string, HashSet<string>>();
        alliances.Add("all",new HashSet<string>());
	}

    // Update is called once per frame
    public List<string> GetAllies(string faction)
    {
        return alliances[faction].ToList();
    }
    public List<string> GetEnemies(string faction)
    {
        return alliances["all"].Except(alliances[faction]).ToList();
    }
    public void Ally(string faction1,string faction2)
    {
        alliances[faction1].Add(faction2);
        alliances[faction2].Add(faction1);
    }
    public void War(string faction1, string faction2)
    {
        alliances[faction1].Remove(faction2);
        alliances[faction2].Remove(faction1);
    }
}
