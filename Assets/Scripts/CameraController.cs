using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float Y_ANGLE_MIN = -10.0f;
    private const float Y_ANGLE_MAX = 70.0f;

    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;

    public float distance = 20.0f;
    private float currentX = 0.0f;
    private float currentY = 10.0f;
    public float sensitivityX = 4.0f;
    public float sensitivityY = 1.0f;

    private void start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY += Input.GetAxis("Mouse Y") * sensitivityY;
        distance -= Input.GetAxis("Mouse ScrollWheel")*10;

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;

        camTransform.LookAt(lookAt.position);
    }

}
