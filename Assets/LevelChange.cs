using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    bool canProgress = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        GameObject[] Coins = GameObject.FindGameObjectsWithTag("Coin");
        if (Coins.Length == 0)
            canProgress = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (canProgress)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }


}
