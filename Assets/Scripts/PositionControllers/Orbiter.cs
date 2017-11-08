using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Unused
//Orbits an object about a point. Not currently used. Could be done for weird weapons that circle the player, etc etc whatever you want to orbit based on position.
//Unrealistic physics collisions beware.
//Was originally a test class.
public class Orbiter : MonoBehaviour {
    public Transform lookAt;
    public float distance = -1.5f;
    private float currentX = 0;

    private void LateUpdate()
    {
        currentX += 10;
        Vector3 dir = new Vector3(0, 0, distance);
        Quaternion rotation = Quaternion.Euler(0, currentX, 0);
        gameObject.transform.position = lookAt.position + (rotation * dir);

        gameObject.transform.LookAt(lookAt.position);


    }

}
