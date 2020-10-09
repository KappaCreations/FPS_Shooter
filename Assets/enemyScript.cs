using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    [SerializeField]
    Transform[] targets;
    int targetIndex = 0;
    Transform currentTarget;
    
    [SerializeField]
    float speed = 1;

    [SerializeField]
    float dist = 1;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = targets[targetIndex];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, currentTarget.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, currentTarget.position) < dist)
        {
            updateTarget();
        }
    }

    void updateTarget()
    {
        if (targetIndex == targets.Length - 1)
            targetIndex = 0;
        else
            targetIndex++;
            
        currentTarget = targets[targetIndex];
 
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

}
