using UnityEngine;
using System.Collections;

public class isGrounded : MonoBehaviour {

	private bool grounded = false;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public bool Grounded()
	{
		return grounded;
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.CompareTag ("Ground"))
			grounded = true;
	}

	void OnCollisionExit2D (Collision2D other)
	{
		if (other.gameObject.CompareTag ("Ground"))
			grounded = false;
	}
}
