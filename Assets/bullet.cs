using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{


    [SerializeField]
    float bulletLifespan;

    float duration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        duration += Time.deltaTime;

        if(duration>= bulletLifespan)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "target")
        {
            Destroy(collision.gameObject);
            Debug.Log("Hit");
        }

        Destroy(gameObject);



    }




}
