using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//Player specific junk don't worry about this. It is pretty hacky.
public class RotationController : MonoBehaviour
{
    public float rotationAboutYAxis = 0;
    public float rotationAboutXAxis = 0;

    public bool keys = false;

    public float sensitivityX = 4.5f;

    public Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!keys)
        {
            rotationAboutYAxis = Input.GetAxis("Mouse X") * sensitivityX;

            //rotationAboutXAxis = Input.GetAxis("Mouse Y") * sensitivityX;
        }
        else
        {
            rotationAboutYAxis = Input.GetAxis("Horizontal") * sensitivityX;
            //rotationAboutXAxis = 0;
        }
        
        //transform.localEulerAngles += new Vector3(1, 0, 0) * sensitivityX * rotationAboutXAxis;
        rb.AddTorque(Vector3.up *sensitivityX * Input.GetAxis("Mouse X"));
        //rb.AddRelativeTorque(new Vector3(1,0,0) * sensitivityX * rotationAboutXAxis);
    }
}