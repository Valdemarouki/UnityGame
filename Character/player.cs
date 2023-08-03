using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //Move

    public float speed;
    public Animator anime;
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;
    


   //Jump
    public float jumpForce;
    private bool isGround;
    public Transform groundchek;
    private int ExtraJump;
    public int extraJumpsValue;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool canMove = true;

    //Dash
    public float dashSpeed = 10f;  // Speed of the dash movement
    public float dashDuration = 0.3f;  // How long the dash lasts
    private bool isDashing = false;  // Flag to check if the player is currently dashing
    private float dashTime;  // Used to track the time passed during the dash
    private float dashTimeLeft;
    private int direction;
    public float startDashTime = 0.1f;
    public float lastDashTime = 0;  // Time when the last dash started
    public float dashCooldown = 2f;  // Cooldown time in seconds



    //public float speed;
    // public float dashSpeed;
    // public float startDashTime;
    // private float dashTime;
    // private int direction=0;

    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
         dashTime = startDashTime;
    }


    void Update()
    {

        if (moveInput != 0)
        {
            anime.SetBool("stop", false);
            anime.SetBool("jump", false);
        }
        else
        {
            anime.SetBool("stop", true);
            anime.SetBool("jump", false);
        }
        
    

        if (isGround == true)
        {
            ExtraJump = extraJumpsValue;
        }


        if (Input.GetKeyDown(KeyCode.Space) && ExtraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            ExtraJump--;
            
        
        }

        else if (Input.GetKeyDown(KeyCode.Space) && ExtraJump == 0 && isGround == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            
            
        }
        
        if(!isGround){
            anime.SetBool("jump", true);
        }
        else
        {
            anime.SetBool("jump", false);
          
        }

        // if(Heartsystem.health <= 0){
        //     rb.constraints = RigidbodyConstraints2D.FreezePosition;
        //     canMove = false;


        // }


        
    }

    void StopDash()
    {
        isDashing = false;
        // Reset the player's velocity to zero to stop the dash
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        anime.SetBool("dash",false);
    }

    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundchek.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");       
        // // rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        // // if(canMove){
        // //     rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        // // }



        // // If the dash key is pressed and the player is not currently dashing.
        // if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing  && isGround == true)
        // {
        //     StartDash();
        // }

        // if (isDashing)
        // {
        //     Dash(moveInput);
        // }
        // else
        // {
        //     Move(moveInput);
        // }


        if(direction == 0 && Time.time >= lastDashTime + dashCooldown)
        {
            if(Input.GetKey(KeyCode.LeftShift) && moveInput != 0)
            {
                direction = (moveInput > 0) ? 1 : -1;
                lastDashTime = Time.time;
                anime.SetBool("dash",true);
                //dashTime = 0;
            }
            else if(Input.GetKey(KeyCode.LeftShift) && moveInput == 0){
                if (facingRight)
                {
                    direction = 1;
                }
                else if (!facingRight)
                {
                    direction = -1;
                }
                lastDashTime = Time.time;
                anime.SetBool("dash",true);
                //dashTime = 0;

            }
            else
            {
                rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            }
        }
        else
        {
            if(dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
                anime.SetBool("dash",false);
                //anime.SetBool("stop", true);
                //anime.SetBool("jump", false);
            }
            else
            {
                dashTime -= Time.deltaTime;
                

                //Here, you can modify the Vector2 to change the dash direction (horizontal, vertical).
                rb.velocity = new Vector2(dashSpeed * direction, rb.velocity.y);
            }
        }

    
    

        if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
        else if (facingRight == false && moveInput > 0)
        {
            Flip();
        }

    }

     void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void DisableMovement()
    {
        canMove = false;
    }

    public void EnableMovement()
    {
        canMove = true;
    }





    private void Move(float moveX)
    {
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
         if(canMove){
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }

    }

    private void StartDash()
    {
        isDashing = true;
        dashTimeLeft = dashTime;
        anime.SetBool("dash",true);
    }

    private void Dash(float moveX)
    {
        if (dashTimeLeft > 0)
        {
            rb.velocity = new Vector2(moveX * dashSpeed*3, rb.velocity.y);
            rb.velocity = Vector2.up * jumpForce;
            dashTimeLeft -= Time.deltaTime;
        }
        else
        {
            isDashing = false;
        }
    }


}