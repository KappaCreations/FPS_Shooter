using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControls : MonoBehaviour
{
    [SerializeField]
    float rotSpeed = 1;
    [SerializeField]
    Transform lookUpDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float y = Input.GetAxis("Mouse Y");
        lookUpDown.Rotate(new Vector3(y * -rotSpeed, 0, 0));
        
        float x = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, x * rotSpeed, 0));

    }
}
