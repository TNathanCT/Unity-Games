using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public int PlayerSpeed;
	//public int TurnSpeed;
	Rigidbody rb;

	//private float MovementInputValue;

    Vector3 m_Movement;
    //private float TurnInputValue;

    private string MovementAxisName;
	//private string TurnAxisName;

	public bool RaiseShield;
	public GameObject Shield;
	public GameObject PlayerCamera;


	WeaponSwitch WS;


	void Start () {
		WS = GetComponent<WeaponSwitch> ();
		rb = GetComponent<Rigidbody> ();
		//MovementInputValue = 0f;
		//TurnInputValue = 0f;

		//MovementAxisName = "Vertical";
		//TurnAxisName = "Horizontal";
		RaiseShield = false;
		PlayerCamera.SetActive (true);
		Shield.SetActive (false);
		WS.enabled = true;
	}

	// Update is called once per frame
	void Update () {
        //MovementInputValue = Input.GetAxis (MovementAxisName);
        //TurnInputValue = Input.GetAxis (TurnAxisName);

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");



        Move(h, v);

        Vector3 newPosition = new Vector3(h, 0, v);
        rb.transform.LookAt(newPosition + transform.position);



//		Turn ();


		if (Input.GetMouseButton (1) && WS.istheshieldout == true) {
			PlayerCamera.SetActive (false);
			Shield.SetActive (true);
			PlayerSpeed = 0;
		//	TurnSpeed = 0;
			WS.enabled = false;
			rb.constraints = RigidbodyConstraints.FreezeRotationY;
			rb.constraints = RigidbodyConstraints.FreezeRotationX;
			rb.constraints = RigidbodyConstraints.FreezeRotationZ;
			rb.constraints = RigidbodyConstraints.FreezePositionZ;
			rb.constraints = RigidbodyConstraints.FreezePositionX;
			rb.constraints = RigidbodyConstraints.FreezePositionY;
		} else {
			
			PlayerCamera.SetActive (true);
			Shield.SetActive (false);
			PlayerSpeed = 10;
			//TurnSpeed = 100;
			WS.enabled = true;
			rb.constraints = RigidbodyConstraints.FreezeRotationX;
			rb.constraints = RigidbodyConstraints.FreezeRotationZ;
			rb.constraints = RigidbodyConstraints.FreezePositionY;
		}

	}
		
	void Move(float h, float v)
    {
        m_Movement.Set(h, 0f, v);
        m_Movement = m_Movement.normalized * PlayerSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + m_Movement);
        
        
        
        //Vector3 movement = transform.forward * MovementInputValue * PlayerSpeed * Time.deltaTime;
        //rb.MovePosition (rb.position + movement);
    }

	/*void Turn(){
		float turn = TurnInputValue * TurnSpeed * Time.deltaTime;
		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);
		rb.MoveRotation (rb.rotation * turnRotation);
	}*/
}
