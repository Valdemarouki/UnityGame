using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Heartsystem : MonoBehaviour
{
    public static int health;
    public GameObject Heart1, Heart2;
    public GameObject effect;

    void Start()
    {
        Heart1.SetActive(true);
        Heart2.SetActive(true);

        health = 2;
    }

    // Update is called once per frame
    void Update()
    {
        switch(health)
        {


            case 2:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
 
                break;

            case 1:
                Heart1.SetActive(true);
                Heart2.SetActive(false);
                Instantiate(effect, transform.position, Quaternion. identity);

                break;

            case 0:
                Heart1.SetActive(false);
                Heart2.SetActive(false);
                Instantiate(effect, transform.position, Quaternion. identity);

                break;
        }
        
   }
}
