using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFuncs : MonoBehaviour {

    public void Pressed()
    {
        print("button pressed");
    }
    public void OnCollisionEnter()
    {
        print("entered");
    }
}
