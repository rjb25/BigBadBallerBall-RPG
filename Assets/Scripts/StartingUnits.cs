using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StartingUnits : MonoBehaviour {
    public Text playerText;
    public int val;
	// Use this for initialization
	void Start () {
        val = 5;
        Create nonStatic = GameObject.Find("GlobalScripts").GetComponent<Create>();
       InvokeRepeating("Repeating", 5f, 10f);
        //Create.Gunner(new Vector3(0f, 0.5f, -14f));

        GameObject light = Create.ALight(gameObject.transform.position + new Vector3(0f, 5f, 0f), color: Color.red, intensity: 3);
        nonStatic.Sound("boop", altLocation: light, times: 5, volume: 0.1f);
        StartCoroutine(PlayerMessage(" ",10f));
        Create.Gunner(new Vector3(0f, .5f, -140f), "Player", new string[] { "Enemy" }, 30, targetingRange: 1, ai: "hold");
        Create.Gunner(new Vector3(0f, .5f, -130f), "Player", new string[] { "Enemy" }, 30, targetingRange: 1, ai: "hold");
        Create.Gunner(new Vector3(0f, .5f, -120f), "Player", new string[] { "Enemy" }, 30, targetingRange: 1, ai: "hold");
        Create.Gunner(new Vector3(0f, .5f, -110f), "Player", new string[] { "Enemy" }, 30, targetingRange: 1, ai: "hold");
        Create.Gunner(new Vector3(0f, .5f, -101f), "Player", new string[] { "Enemy" }, 30, targetingRange: 1, ai: "hold" );
    }
    public void FPS()
    {
        print(1.0f / Time.deltaTime);
    }
    void Repeating()
    {
        Create.Charger(new Vector3(0f, 0.5f, 14f),"Enemy",null);
        Create.Gunner(new Vector3(0f, .5f, -14f),"Enemy",null);
    }


    IEnumerator PlayerMessage(string message, float delayTime )
    {

        yield return new WaitForSeconds(delayTime);
        playerText.text = message;


    }

}
