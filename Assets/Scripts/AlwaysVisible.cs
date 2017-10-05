using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlwaysVisible : MonoBehaviour
{

    void Update()
    {
         var fwd = Camera.main.transform.forward;
        transform.rotation = Quaternion.LookRotation(fwd);
       
    }

}
