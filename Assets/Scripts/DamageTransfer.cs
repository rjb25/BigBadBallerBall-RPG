using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTransfer : MonoBehaviour {
    public Health hs;
    public float percentage = 1;
    public void Start()
    {
        hs = GetComponentInParent<Health>();
    }
    public void Transfer(int amount)
    {
        hs.TakeDamage(Mathf.FloorToInt(amount * percentage));
    }
}
