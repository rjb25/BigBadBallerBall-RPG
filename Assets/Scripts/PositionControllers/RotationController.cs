using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//Player specific junk don't worry about this. It is pretty hacky.
public class RotationController : MonoBehaviour
{
    public float rotationAboutYAxis = 0;
    public float rotationAboutXAxis = 0;

    public bool keys = false;

    public float sensitivityX = 9;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!keys)
        {
            rotationAboutYAxis = Input.GetAxis("Mouse X") * sensitivityX;
        }
        else
        {
            rotationAboutYAxis = Input.GetAxis("Horizontal") * sensitivityX;
        }
   
        rb.AddTorque(new Vector3(0f,rotationAboutYAxis,0f)*sensitivityX);
        //print(string.Format("{0} angular ball",rb.angularVelocity));
        //gameObject.transform.eulerAngles = new Vector3(0, rotationAboutYAxis, 0);
    }
}