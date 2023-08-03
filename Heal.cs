using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public GameObject sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(Heartsystem.health<=1){
                Instantiate(sound, transform.position, Quaternion.identity);
                Heartsystem.health += 1;
                Destroy(gameObject);
            }
        }
    }
}
