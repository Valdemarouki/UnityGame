using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{

    public Animator anime;
    public Animator anime2;
    public Animator anime3;
    public Animator anime4;
    public Animator anime5;
    public GameObject sound;
    public GameObject sound2;
    public float delay = 5;
    float timer;
    private bool isDead = false;
    private bool hasDied;
    private bool isDeathAnimationFinished;
    private bool isFrozen;
    private player player;
    private Rigidbody2D rigidbody;
    public float damageInterval =20f;
    private bool canDamage = false;
    public float damageCooldown = 20f;
    private float lastDamageTime = 0f;
    private bool isColliding;
    private Coroutine damageCoroutine;
    


    private void Start()
    {
        anime = GetComponent<Animator>();
        player = GetComponent<player>();
        rigidbody = GetComponent<Rigidbody2D>();
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        isColliding = true;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(sound2, transform.position, Quaternion.identity);
            Die();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
          
        
        if (collision.gameObject.CompareTag("Enemy") && Time.time > lastDamageTime + damageCooldown && canDamage)
        {
            Instantiate(sound2, transform.position, Quaternion.identity);
            Die();
            canDamage = false;
            lastDamageTime = Time.time;
        }
    
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
            }
        }
    }
    IEnumerator EnableDamageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canDamage = true;
    }

    private void Update()
    {
        if (isDead)
        {
            player.DisableMovement();

            if(!isDeathAnimationFinished){
                if (!anime.GetCurrentAnimatorStateInfo(0).IsName("death"))
                {
                    // Play the death animation once
                    Instantiate(sound, transform.position, Quaternion.identity);
                    anime.SetTrigger("death");
                    anime2.SetTrigger("death");
                    anime3.SetTrigger("death");
                    anime4.SetTrigger("death");
                    anime5.SetTrigger("death");
                }
                else if (anime.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                {
                    // Animation has reached the end
                    //hasDied = true;
                    isDeathAnimationFinished = true;
                    anime.enabled = false;
                    Instantiate(sound2, transform.position, Quaternion.identity);
                    rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                    // Freeze rotation
                    transform.rotation = Quaternion.identity;
                    anime.speed = 0f;
                    rigidbody.freezeRotation = true;
                    //Time.timeScale = 0;
                }
                //Time.timeScale = 0;

            }
             
            // else{
            //     anime.speed = 0f;
            // }
        }
        else
        {
            player.EnableMovement();
            anime.speed = 1f;
        }


        // if (isFrozen)
        // {
        //     player.DisableMovement();
        // }
        // else
        // {
        //     player.EnableMovement();
        // }

        timer += Time.deltaTime;
        if (timer >= damageInterval)
        {
            canDamage = true;
            timer = 0f;
        }
    }

    private void Die()
    {
        // isDead = true;
        // timer += Time.deltaTime;
        Heartsystem.health -= 1;
         if(Heartsystem.health == 0 ){     
            isDead = true;
            // Instantiate(sound, transform.position, Quaternion.identity);
            // anime.SetTrigger("death");
            // anime2.SetTrigger("death");
            // anime3.SetTrigger("death");
            // anime4.SetTrigger("death");
            // anime5.SetTrigger("death");
            // anime.speed = 0f;
            // // anime.SetBool("stop", true);
            // // anime.SetBool("jump", false);
            // //nime.SetBool("death", true);
            // Time.timeScale = 0;
            //Time.timeScale = 1;
            
        }
         
    // if (timer > delay && health <= 0)
    // {
        
    //     //Time.timeScale = 1;
    //     Time.timeScale = 0;
    //     SceneManager.LoadScene(1);
    // }
        
    }


}
