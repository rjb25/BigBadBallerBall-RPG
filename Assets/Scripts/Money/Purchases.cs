using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class Purchases : MonoBehaviour {
    public BalanceScript balance;
    public int Cheap = 1;
    private Health health;
    private PlayerController playerScript;
    public GameObject menu;
    Dictionary<string, Inf> buttons;
    struct Inf
    {
        public int price;
        public int level;
    }

    private void Start()
    {
        health = gameObject.GetComponent<Health>();
        playerScript = gameObject.GetComponent<PlayerController>();
        buttons = new Dictionary<string, Inf>()
        {
                {"Charger", new Inf{price = 1, level = 1} },
                {"Light", new Inf{price = 1, level = 1} },
                {"Heal", new Inf{price = 1, level = 1} },
                {"Backwards", new Inf{price = 1, level = 1} }



        };
        int count = 0;
        foreach (KeyValuePair<string, Inf> pair in buttons)
        {
         
            

            GameObject buttonObj = Instantiate(Create.GetPrefab("Button"), menu.transform);
            Button button = buttonObj.GetComponent<Button>();
            buttonObj.GetComponentInChildren<Text>().text = "lvl" + pair.Value.price + " " + pair.Key + "(" + pair.Value.level + ")";
            buttonObj.transform.localScale = new Vector3(1, 1, 1);
            RectTransform rect = buttonObj.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(count*160,0);

                button.onClick.AddListener(delegate { Buy(pair.Key); });
            count++;

        }
    }

    //maybe make this a switch case of buy
    public void Buy(string name) //level
    {
        int price = 1;
        if (balance.balance >= price) //&& cheap contains name
        {
            balance.AddMoney(-price);
            switch (name)
            {
                case "Charger":
                    Create.Charger(gameObject.transform.position + new Vector3(0f, 5f, 0f), "Player", new string[] { "Enemy" });
                    break;
                case "Light":
                    Create.ALight(gameObject.transform.position + new Vector3(0f, 5f, 0f), color: Color.red);
                    break;
                case "Heal":
                    health.TakeDamage(-25);
                    break;
                case "Backwards":
                    playerScript.noBackwards = false;
                    break;
                default:
                    print("no item specified");
                    balance.AddMoney(price);
                    break;
            }
        }
      
    }
}
