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

    

    [SerializeField]
    Transform Cam;

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

        Vector3 camForward = Cam.forward;
        Vector3 camRight = Cam.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = (camForward * v * moveSpeed) + (camRight * h * moveSpeed);
        

        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

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
        if(other.gameObject.tag == "killZ")
        SceneManager.LoadScene(2);
    }

    
}
