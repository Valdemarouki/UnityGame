using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFolow : MonoBehaviour
{

   [SerializeField]
   Transform player;

   [SerializeField]
   float agroRange;

   [SerializeField]
   float moveSpeed;

   Rigidbody2D rb;
   Animator ani;
   private void Start() {
       rb = GetComponent<Rigidbody2D>();
       ani = GetComponent<Animator>();
   }

   private void Update() {
       float distToPlayer = Vector2.Distance(transform.position, player.position);

       if(distToPlayer < agroRange) {
           ChasePlayer();
       } else {
           StopChasePlayer();
       }
   }

   void ChasePlayer() {
       if(transform.position.x < player.position.x) {
             rb.velocity = new Vector2(moveSpeed, 0);
             GetComponent<SpriteRenderer>().flipX = false;
             ani.SetBool("walk",true);
             
       } else {
             rb.velocity = new Vector2(-moveSpeed, 0);
             GetComponent<SpriteRenderer>().flipX = true;
             ani.SetBool("walk",true);
       }
   }

   void StopChasePlayer() {
    rb.velocity = new Vector2(0, 0);
    ani.SetBool("walk",false);
   }
}
