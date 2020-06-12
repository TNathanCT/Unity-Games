using UnityEngine;
using System.Collections;

public class PlayerMOvement : MonoBehaviour {

    public float m_Speed = 10f;
    public float JumpStrength = 3500f;
    public bool onGround = false;
    public bool canDoubleJump = true;
     public bool TripleJump = true;

    private string MovementAxisName;
    private float MovementInputValue;

    public GameObject ExtraJump1;
    public GameObject ExtraJump2;

    private Rigidbody Rigidbody;





	void Start () {
        MovementAxisName = "Vertical";
        Rigidbody = GetComponent<Rigidbody>();	
	}
	
	void Update () {

        RaycastHit hit;
        Vector3 physicsCenter = this.transform.position + this.GetComponent<BoxCollider>().center;



        if (Physics.Raycast(physicsCenter, Vector3.down, out hit, 1))
        {
            if (hit.transform.gameObject.tag != "Player")
            {
                onGround = true;
            }
        }



        else 
        {
            onGround = false;
        }





        //For the double Jumps
        if (Input.GetKeyDown(KeyCode.Space) && !onGround && canDoubleJump)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpStrength, 0));
            canDoubleJump = false;


            if (ExtraJump2.activeInHierarchy == false && !canDoubleJump)
            {
                TripleJump = true;
            }
        }



        //For the Triple Jumps
        else if ((Input.GetKeyDown(KeyCode.Space) && !onGround && !canDoubleJump && TripleJump))
        {

            GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpStrength, 0));
            TripleJump = false;
        }




        else if ((Input.GetKeyDown(KeyCode.Space) && onGround == true))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpStrength, 0));
            if (ExtraJump1.activeInHierarchy == false && !TripleJump) { 
                canDoubleJump = true;
        }
            TripleJump = false;
        }








        MovementInputValue = Input.GetAxis(MovementAxisName);

	}

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "ExtraJump1")
        {
            ExtraJump1.SetActive(false);
  
        }

        if(other.gameObject.tag == "ExtraJump2")
        {
            ExtraJump2.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 Movement = transform.forward * m_Speed * MovementInputValue * Time.deltaTime;
        Rigidbody.MovePosition(Rigidbody.position + Movement);
    }

}
