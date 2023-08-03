using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gilza : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float fireRate = 0.5f;
   

    private float nextFireTime = 0f;

    void Start()
    {

    }

    void Update()
    {

        
        if (Input.GetKey(KeyCode.F) && Time.time > nextFireTime && BulletPlusText.BulletPlus > 0)
        {
            nextFireTime = Time.time + fireRate;
           
            // Create the bullet
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Add force to the bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * bulletSpeed, ForceMode2D.Impulse);


            

        }


    }
}
