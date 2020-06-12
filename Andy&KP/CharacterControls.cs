using UnityEngine;
using System.Collections;

public class CharacterControls : MonoBehaviour {

	private float moveSpeed = 3.75f;
	private float moveVelocity;
	private float jumpHeight = 10.15f;
	public Rigidbody2D rb;
	private isGrounded ground;
	private BoxCollider2D collid;
	public GameObject player;
	private Animator anim;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

    public bool isCrouching;


	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		ground = GetComponent<isGrounded> ();
		collid = GetComponent<BoxCollider2D> ();
		anim = GetComponent<Animator> ();


	}

	// Update is called once per frame
	void FixedUpdate () 
	{

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		//moveVelocity = 0.5f;
//		rb.velocity = 3.0f;

		if (Input.GetKey (KeyCode.D)) 
		{
			MoveRight ();
			transform.localScale = new Vector3 (0.3f, 0.3f, 0.3f);

		}
			
		

		if (Input.GetKey (KeyCode.A)) 
		{
			MoveLeft ();
			transform.localScale = new Vector3 (-0.3f, 0.3f, 0.3f);
		}



		anim.SetFloat ("Speed", Mathf.Abs(rb.velocity.x));
		anim.SetBool ("Grounded", ground.Grounded ());

        /*if(isCrouching == true)
        {
            anim.SetFloat("MovewhileCrawling", Mathf.Abs(rb.velocity.x));
        }*/
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space) && /*ground.Grounded()*/ grounded) 
		{
			Jump ();
		}

		//moveVelocity = 0f;
			
		if (Input.GetKeyDown (KeyCode.S)) 
		{
			GetDownP ();
		}
		if (Input.GetKeyDown (KeyCode.W))
			GetUpP ();
		
	}

	void MoveRight()
	{
		rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
		//moveVelocity = moveSpeed;
	}

	void MoveLeft()
	{
		rb.velocity = new Vector2 (-moveSpeed, rb.velocity.y);
		//moveVelocity = -moveSpeed;
	}

	void Jump()
	{
		rb.velocity = new Vector2 (rb.velocity.x, jumpHeight);
	}

	void GetDownP()
	{
		
		collid.size = new Vector3 (8.65f, 3.38f, 1.0f);
        isCrouching = true;
        anim.SetBool("Crawling", true);
	}

	void GetUpP()
	{
		collid.size = new Vector3 (2.35f, 8.65f, 1.0f);
        isCrouching = false;
		anim.SetBool("Crawling", false);
		anim.SetTrigger ("GetUp");
    }
		
}
