using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Always : MonoBehaviour {
        public Actor action;
        public void  SetAlways(Actor doWhat)
        {//could put these out into functions if desired.
            action = doWhat;
        }
    private void Update()
    {
        action();
    }
}
