using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform lookAt;
    public GameObject projectile;
    public GameObject Holder;
    public float distance = 3.5f;
    private float currentX = 1.0f;
    public float sensitivityX = 4.0f;
    public float changeInX;
    void FixedUpdate()
    {
        //prevVelocity = Holder.GetComponent<Rigidbody>().velocity;
    }
    private void Update()
    {
        changeInX = Input.GetAxis("Mouse X") * sensitivityX;
        currentX += changeInX;
    }
    public void use()
    {
        var bullet = Instantiate(projectile, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), gameObject.transform.rotation);
       
        bullet.GetComponent<Rigidbody>().velocity = transform.forward*-6;
       
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, distance);
        Quaternion rotation = Quaternion.Euler(0, currentX, 0);
        gameObject.transform.position = lookAt.position + rotation * dir;

        gameObject.transform.LookAt(lookAt.position);
    }

}