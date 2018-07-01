using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SaveGame : MonoBehaviour {
    public GameState current = null;
    public bool loaded = false;
    public bool saved = false;
    public StartMenu sm;
    // Use this for initialization
    public void Start()
    {
        if (GameObject.Find("SaveData"))
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.name = "SaveData";
            DontDestroyOnLoad(gameObject);
        }
    }
    public void Load()
    {
        loaded = true;
        if (!saved)
        {
            TextAsset asset = Resources.Load("SaveGames/save") as TextAsset;
            string jsonString = asset.text;
            GameState gs = JsonUtility.FromJson<GameState>(jsonString);
            current = gs;
        }


            Application.LoadLevel(Application.loadedLevel);
        
        GameObject.Find("MenuData").GetComponent<StartMenu>().StartGame();
    }
    public void Save()
    {
        saved = true;
        GameState gs = new GameState();
        gs.score = GameObject.Find("UI/PlayerScore").GetComponent<ScoreScript>().score;
        current = gs;
        File.WriteAllText(Application.dataPath + "/Resources/SaveGames/save.json", JsonUtility.ToJson(gs));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
