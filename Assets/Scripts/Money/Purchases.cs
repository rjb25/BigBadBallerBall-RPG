using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
//All the options for buing content.
//This generates the buttons you see at the bottom when you hit ESC in game.
//It handles what the buttons do, how much it costs to upgrade them, what upgrading effects, etc etc.
public class Purchases : MonoBehaviour {
    public BalanceScript balance;
    public int Cheap = 1;
    private Health health;
    private PlayerController playerScript;
    public GameObject menu;
    private GameObject playerBody;
    Dictionary<string, Inf> buttons;
    public struct Inf
    {
        public int price;
        public int upgrade;
        public int level { get; set; }
        public Producer produce;
    }

    private void Start()
    {
        playerBody = GameObject.Find("PlayerBody");
        health = gameObject.GetComponent<Health>();
        playerScript = gameObject.GetComponent<PlayerController>();
        buttons = new Dictionary<string, Inf>()
        {
                   {"Gun", new Inf{price = 1, level = 1, upgrade = 1,
                produce = (level) => {
                    GameObject gun = Create.Gun( new List<string>(new string[]{"Enemy" }),autoFire: true, level: level);
        gun.transform.parent = playerBody.transform.parent;

        Interactable interactable = gun.AddComponent<Interactable>();
        interactable.moveable = true;

        Create.AttachSpawner(gun, playerBody,displacement: new Vector3(1, 0, 1)); }
    } },

                {"Charger", new Inf{price = 1, level = 1, upgrade = 1,
                produce = (level) => Create.Charger(gameObject.transform.position + new Vector3(0f, 5f, 0f), "Player", new string[] { "Enemy" },level: level)
    } },
                {"Light", new Inf{price = 1, level = 1, upgrade = 1,
                produce = (level) => Create.ALight(gameObject.transform.position + new Vector3(0f, 5f, 0f), color: Color.red, range: 10+(level*2), intensity:1+level,indirect:level/50)
    } },
                {"Heal", new Inf{price = 1, level = 1, upgrade = 1,
                produce = (level) =>  health.TakeDamage(-25 - (level *10))
    } },
                {"Backwards", new Inf{price = 1, level = 1, upgrade = 1,
                produce = (level) => playerScript.noBackwards = false
    } },
                {"Townhall", new Inf{price = 5, level = 1, upgrade = 1,
                produce = (level ) =>Create.Townhall(gameObject.transform.forward * 2 + new Vector3(0,0.25f,0), "Player")
    } } ,
            {"Sword", new Inf{price = 1, level = 1, upgrade = 1,
            produce = (level) => print("yay sword" + level)
            } }

        };
        int count = 0;
        foreach (KeyValuePair<string, Inf> pair in buttons)
        {
            GameObject buttonObj = Instantiate(Create.GetPrefab("Button"), menu.transform);
            ClickableObject cs = buttonObj.AddComponent<ClickableObject>();
            Button button = buttonObj.GetComponent<Button>();
            Text txt = buttonObj.GetComponentInChildren<Text>();
            txt.text = "(" + pair.Value.upgrade + ")" +"lvl" + pair.Value.level + " " + pair.Key + "(" + pair.Value.price + ")";
            buttonObj.transform.localScale = new Vector3(1, 1, 1);
            RectTransform rect = buttonObj.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(count*160,0);

            cs.leftClick = delegate { Buy(pair.Key); };
            cs.rightClick = delegate { Upgrade(pair.Key, txt); };
            count++;

        }
    }
    public void Upgrade(string name, Text txt) //level
    {

        Inf item = buttons[name];
        
        if (balance.balance >= item.upgrade) //&& cheap contains name
        {
            balance.AddMoney(-item.upgrade);
            item.level++;
            item.upgrade += item.upgrade;
            buttons[name] =  item;
            print("upgraded to level " + item.level);
            txt.text = "(" + item.upgrade + ")" + "lvl" + item.level + " " + name + "(" + item.price + ")";
        }


    }
    public void Buy(string name) //level
    {
        Inf item = buttons[name];
        if (balance.balance >= item.price) //&& cheap contains name
        {
            balance.AddMoney(-item.price);
            item.produce(item.level);
        }

    }
}
