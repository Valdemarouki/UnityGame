using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class bubu : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that collided with the bullet is tagged as "Enemy"
        if (other.gameObject.tag == "Enemy")
        {
            // Destroy the bullet game object
            Destroy(gameObject);
        }
    }
}
