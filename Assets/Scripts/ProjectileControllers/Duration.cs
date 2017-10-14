using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duration : MonoBehaviour {
    public float duration = 5;
    public bool useDuration = true;
    private float timeLeft;
    void Start()
    {
            timeLeft = duration;
    }

    void FixedUpdate()
    {
        if (useDuration)
        {
            if (timeLeft < 0)
            {
                Destroy(gameObject);
            }
            timeLeft -= Time.deltaTime;
        }
    }
}
