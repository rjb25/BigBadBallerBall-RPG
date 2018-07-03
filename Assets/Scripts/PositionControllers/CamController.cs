using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//DEPRECATED, Could still be useful. It allows for gear to move with an object. 
//It uses position, not velocity or acceleration. Hench the switch to joints.
public class CamController: MonoBehaviour {
    public Transform lookAt;
    public float height = 0;
    public float distance = 1.5f;
    public float xRotOff = 0;
    public float yRotOff = 0;
    public float xObjRotOff = 0;
    public float yObjRotOff = 0;
    public float lookAhead = 0;
    public bool fixForward = true;
    public bool lookAway = true;
    private float fixX = 0f;
    private float fixY = 0f;


    // Update is called once per frame

    private void LateUpdate()
        {
            Vector3 dir = new Vector3(0, 0, distance);
        float mouse = Input.GetAxis("Mouse X");
        yRotOff += mouse ;
        Quaternion updatedDirection =Quaternion.Euler(xRotOff, yRotOff, 0f);

        Vector3 camPos = (lookAt.position + (updatedDirection * dir));
            gameObject.transform.position = camPos;
        Vector3 difference = lookAhead * (lookAt.position - gameObject.transform.position);
        difference[1] = 0;

        gameObject.transform.LookAt(lookAt.position + difference);
        gameObject.transform.position = camPos + new Vector3(0, height, 0);
        if (fixForward)
        {
            fixX = -xRotOff;
            fixY = -yRotOff;
        }
        if (lookAway)
        {
            gameObject.transform.rotation *= Quaternion.Euler(-xObjRotOff + fixX, yObjRotOff + 180 + fixY, 0f);

        }
        else
        {

            gameObject.transform.rotation *= Quaternion.Euler(xObjRotOff + fixX, yObjRotOff + fixY, 0f);
        }


    }
 
}
