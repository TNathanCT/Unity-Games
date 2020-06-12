using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour {

    public int damageToGive;
	private HealthManager2 healthmanager;
	public bool knockback;
	//public Rigidbody2D playerRg;
	private CharacterControls player;


	// Use this for initialization
	void Start () 
	{
		healthmanager = GetComponent<HealthManager2> ();
		player = GetComponent<CharacterControls> ();
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.collider.tag == "Enemy") 
		{
			HealthManager2.HurtPlayer(damageToGive);
			player.rb.AddForce (Vector3.left * 475);
		}
	}
		
}
