using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
   
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;// Reference to the UI's health bar.

    // The colour the damageImage is set to, to flash.

 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pick Up"))
        {
            int damage = Mathf.FloorToInt(Mathf.Pow(collision.relativeVelocity.magnitude, 2f)/2);
            collision.collider.gameObject.GetComponentInParent<Health>().TakeDamage(damage);
        }
    }
    void FixedUpdate()
    {
        var angle = Camera.main.transform.eulerAngles.y;
        Vector3 Direction = new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0f, Mathf.Cos(Mathf.Deg2Rad * angle));
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = Vector3.Normalize((new Vector3(Direction.z * (moveHorizontal), 0f, Direction.x * (-moveHorizontal)) + Vector3.Scale(Direction, new Vector3(moveVertical, 0f, moveVertical)))/2);
  
        rb.AddForce(movement * speed);
    }


    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 7)
        {
            winText.text = "You Win!";
        }
    }
}