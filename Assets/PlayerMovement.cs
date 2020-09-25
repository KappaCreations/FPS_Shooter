using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 6;

    [SerializeField]
    float jumpSpeed = 8;
    
    [SerializeField]
    bool touchingFloor = false;

    
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray r = new Ray(transform.position, new Vector3(0,-.5f,0));
        Debug.DrawRay(r.origin, r.direction);
        //RaycastHit hit;
        
        if (Physics.Raycast(transform.position, Vector3.down, .6f))
                touchingFloor = true;

            else
                touchingFloor = false;


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

       rb.velocity = new Vector3(h * moveSpeed, rb.velocity.y, v * moveSpeed);

        if (Input.GetButtonDown("Jump"))
        {
            Jump(touchingFloor);

        }

        
        
    }

    void Jump(bool a)
    {
        if (a)
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
        else
            Debug.Log("Not touching ground");
    
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }
    }
}
