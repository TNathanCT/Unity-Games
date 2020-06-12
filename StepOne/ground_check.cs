using UnityEngine;
using System.Collections;

public class ground_check : MonoBehaviour {

	//Ce script permet de detecter quand le joueur est au sol ou non

	Collider2D collision,colliderGroundC;

	void Awake()
	{		
		colliderGroundC = this.GetComponent<Collider2D>();
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "plateforme" || coll.tag == "ground" || coll.tag == "movingPlatform")
		{
			move_player.grounded = true;
			collision = coll;
		}
	}
	void OnTriggerStay2D(Collider2D coll)
	{
		if(coll.tag == "plateforme" || coll.tag == "ground" || coll.tag == "movingPlatform")	
		{
			move_player.grounded = true;
			collision = coll;
		}
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		if( !colliderGroundC.IsTouching(collision) && (coll.tag == "plateforme" || coll.tag == "ground" || coll.tag == "movingPlatform"))	
			move_player.grounded = false;
	}
}
