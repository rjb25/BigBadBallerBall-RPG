using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour {

    public int worth = 1;
    public BalanceScript balanceScript;
    void Start()
    {
        if (!balanceScript)
        {
            balanceScript = GameObject.Find("PlayerBalance").GetComponent<BalanceScript>();
        }
    }

void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            balanceScript.AddMoney(worth);
            Destroy(gameObject);
        }
    }
}
