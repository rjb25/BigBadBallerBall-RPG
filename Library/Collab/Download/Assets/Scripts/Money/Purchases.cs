using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchases : MonoBehaviour {
    public BalanceScript balance;
    public GameObject ballAlly;
    public int AllyCost = 1;
    /*public Create createScript;
    private void Start()
    {
        createScript = new Create();
    }*/
    public void BuyBallAlly()
    {
        if (balance.balance >= AllyCost)
        {
            balance.AddMoney(-AllyCost);
            //Instantiate(ballAlly,gameObject.transform.position + new Vector3(0,2,0),Quaternion.identity);
            Create.Charger(gameObject.transform.position,"Player", new string[]{ "Enemy" });
        }
    }
}
