using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
