using UnityEngine;

public class SwordController : MonoBehaviour
{



    public Transform lookAt;

    public GameObject Holder;
    public float distance = 3.5f;
    private float currentX = 1.0f;
    public float sensitivityX = 4.0f;
    public float sensitivityY = 1.0f;
    private Vector3 prevVelocity;
    private Vector3 enemyPrev;
    public float changeInX;
    void FixedUpdate()
    {
        //prevVelocity = Holder.GetComponent<Rigidbody>().velocity;
    }
    private void Update()
    {
        changeInX = Input.GetAxis("Mouse X") * sensitivityX;
        print(changeInX);
        currentX += changeInX;
    }
    void OnCollisionEnter(Collision collision)
    {
  
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //var controlscript : Control = player.GetComponent("Control");
            //enemyPrev = collision.collider.GetComponent<prevVelocity>();
            //print(prevVelocity);
            //print("negative- enemies");
            //print(enemyPrev);
            //int damage = Mathf.FloorToInt(Mathf.Pow((prevVelocity-enemyPrev).magnitude, 2f) / 2);
            int damage = Mathf.FloorToInt(Mathf.Abs(changeInX * 5));
            print("DAMAGE");
            print(damage);
            collision.collider.gameObject.GetComponentInParent<Health>().TakeDamage(damage);
        }
    }



    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, distance);
        Quaternion rotation = Quaternion.Euler(0, currentX, 0);
        gameObject.transform.position = lookAt.position + rotation * dir;

        gameObject.transform.LookAt(lookAt.position);
    }

}