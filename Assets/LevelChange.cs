using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    [SerializeField]
    bool canProgress = false;
    [SerializeField]
    int length;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        GameObject[] targets = GameObject.FindGameObjectsWithTag("target");
        
        
        length = targets.Length;
        
        if (targets.Length == 0)
            canProgress = true;
        if (canProgress)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    private void OnCollisionEnter(Collision collision)
    {

 
    }


}
