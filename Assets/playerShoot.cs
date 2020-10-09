using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    
    [SerializeField]
    float bulletSpeed = 10;

    [SerializeField]
    Transform GunBarrel;

    [SerializeField]
    float ammo = 10;
    [SerializeField]
    float Maxammo = 10;

    [SerializeField]
    float health = 5;
    [SerializeField]
    float MaxHealth = 5;

    [SerializeField]
    Image Abar;

    [SerializeField]
    Image Hbar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (ammo > 0)
            {
                Vector3 bulletDirection = GunBarrel.forward * bulletSpeed;
                GameObject b = Instantiate(bullet, GunBarrel.position, GunBarrel.rotation);
                b.GetComponent<Rigidbody>().velocity = bulletDirection;
                ammo--;
                updateUI();
            }
        }

        if (health == 0)
            SceneManager.LoadScene(2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "pickup")
        {
            Destroy(collision.gameObject);
            if (ammo <= (Maxammo - 5))
                ammo += 5;
            else
                ammo = Maxammo;
            Debug.Log("Got Ammo");
            updateUI();
        }

        if (collision.gameObject.tag == "obstacle")
        {
            health--;
            updateUI();
        }








    }

    void updateUI()
    {
        Abar.fillAmount = ammo/Maxammo;
        Hbar.fillAmount = health / MaxHealth;
    
    
    }



}
