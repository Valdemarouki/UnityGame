using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public GameObject sound;
    private bool canDamage = false;
    public GameObject effect;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 0)
        {
            Instantiate(sound, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

         
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if(collision.CompareTag("Bullet"))
        {
            health -= 5;
            Instantiate(effect, transform.position, Quaternion. identity);
        }
          
        // if(collision.CompareTag("Player"))
        // {
        //     Heartsystem.health -= 1;
            
        // }
    
    }



    //  private void OnTriggerStay2D(Collider2D collision)
    // {
          
    //     if(collision.CompareTag("Player") && canDamage)
    //     {
    //         Heartsystem.health -= 1;
    //         canDamage = false;
    //     }
    
    // }


    
    
}
