using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShooting : MonoBehaviour

{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float fireRate = 0.5f;
    public int bulletNumber = 5;
    public GameObject sound;
   

    private Animator animator;
    private float nextFireTime = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        
        if (Input.GetKey(KeyCode.F) && Time.time > nextFireTime && BulletPlusText.BulletPlus > 0)
        {
            Instantiate(sound, transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
           
            // Create the bullet
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Add force to the bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * bulletSpeed, ForceMode2D.Impulse);

            // Play the shooting animation
            animator.SetBool("Shoot",true);
            BulletPlusText.BulletPlus -= 1;

            

        }

        else{
            animator.SetBool("Shoot",false);
            
        }
    }
}
