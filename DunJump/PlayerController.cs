using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float MoveSpeed;
    public float JumpHeight;

    public Transform groundCheck;
    public float GroundCheckRadius;
    public LayerMask WhatImGround;
    public bool onGround;

    public  bool canDoubleJump;
    public bool canTripleJump;
    public bool canQuadJump;
    public bool canPentaJump;
    public bool canSixJump;


    public bool paused;

	public int count = 0;



    private Rigidbody2D rb2d;
    public Animator anim;









  /*  //this sets the bools for multiple jumps
    public bool canDoubleJump = true;
    public bool canTripleJump = true;
    public bool canQuadJump = true;
    public bool canPentaJump = true;
    public bool canSixJump = true;

    //make sure to attach the gameobjects to set the jumps
    public GameObject FortheDoubleJump;
    public GameObject FortheTripleJump;
    public GameObject FortheQuadJump;
    public GameObject ForthePentaJump;
    public GameObject FortheSixJump;*/


    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();

        paused = false;
        anim = GetComponent<Animator>();

    }



    void Update()
    {

        //If the player is touching the ground or not, and set the animation accordingly.
        if (!onGround)
        {
            anim.SetBool("grounded", false);
        }
        else
        {
            if (anim.enabled == true)
            {
                anim.SetBool("grounded", true);
            }
        }

        //Move the player to the left.
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            SpinLeft();
            transform.position += Vector3.left * MoveSpeed * Time.deltaTime;

            anim.enabled = true;

            if (anim.enabled == true)
            {
                anim.SetBool("isWalking", true);
            }
        }


        //Move the player to the right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            SpinRight();
            transform.position += Vector3.right * MoveSpeed * Time.deltaTime;

            anim.enabled = true;
            if (anim.enabled == true)
            {
                anim.SetBool("isWalking", true);

            }

        }


        if (Input.GetKeyUp(KeyCode.RightArrow))


        {
            anim.SetBool("isWalking", false);
        }



        if (Input.GetKeyUp(KeyCode.LeftArrow))


        {
            anim.SetBool("isWalking", false);
        }


        //If the page is active, press escape to leave the page.
       


        //this pauses the game.
        if (paused)
        {
            Time.timeScale = 0;
        }
        if (!paused)
        {
            Time.timeScale = 1;
        }


    



        //For the First Jump
        if (Input.GetKeyDown(KeyCode.Space) && onGround && count>=0 )
        {
            rb2d.velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
            anim.SetTrigger("jumping");
            canDoubleJump = true;
            onGround = false;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump && !onGround)
        {

                canDoubleJump = false;
                rb2d.velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
                anim.SetTrigger("jumping");
                canTripleJump = true;
        }
    

         else if (Input.GetKeyDown(KeyCode.Space) && canTripleJump && !onGround)
            {

                canDoubleJump = false;
                canTripleJump = false;
                rb2d.velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
                anim.SetTrigger("jumping");
                canQuadJump = true;
            
            }

        else if (Input.GetKeyDown(KeyCode.Space) && canQuadJump && !onGround)
        {

            canDoubleJump = false;
            canTripleJump = false;
            canQuadJump = false;
            rb2d.velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
            anim.SetTrigger("jumping");
            canPentaJump = true;
            

        }
        else if (Input.GetKeyDown(KeyCode.Space) && canPentaJump && !onGround)
        {

            canDoubleJump = false;
            canTripleJump = false;
            canQuadJump = false;
            canPentaJump = false;
            rb2d.velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
            anim.SetTrigger("jumping");
            canSixJump = true;
            


        }
        else if (Input.GetKeyDown(KeyCode.Space) && canSixJump && !onGround)
        {

            canDoubleJump = false;
            canTripleJump = false;
            canQuadJump = false;
            canPentaJump = false;
            rb2d.velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
            anim.SetTrigger("jumping");
            canSixJump = false;



        }
    }

    



        void OnTriggerStay2D(Collider2D col)
    {
            if (col.gameObject.tag == "Ground")
            {
                onGround = true;
            Debug.Log("Stay");
            }
        }

        void OnTriggerExit2D(Collider2D col)
    {
            if (col.gameObject.tag == "Ground")
            {
                onGround = false;
            Debug.Log("Exit");
            }
        }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Page")
        {
    
            paused = true;
          


        }

        if (other.gameObject.tag == "Ground")
        {
            onGround = true;
            Debug.Log("Enter");
        }
    }



    void Pause()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0;
        }
        if (!paused)
        {
            Time.timeScale = 1;
        }
    }

    void SpinLeft()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void SpinRight()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}




