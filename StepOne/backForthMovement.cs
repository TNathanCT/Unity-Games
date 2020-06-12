using UnityEngine;
using System.Collections;

public class backForthMovement : MonoBehaviour {

	public float speed = 1;
	public float rightBound,leftBound;
	public GameObject player;
	public float offset;

	private float pingP;
	//private Rigidbody2D rb2d;
	private bool groundedPlatform = false;
	private float previousX,travelled;
	private float velocityX;
	private bool isOnLimit;
	private move_player scriptMove;

	void Start()
	{
		//rb2d = player.GetComponent<Rigidbody2D>();
		scriptMove = player.GetComponent<move_player>();
	}

	void FixedUpdate()
	{
		pingP = Mathf.PingPong(Time.time*speed+offset, Mathf.Abs(rightBound-leftBound));					//la variable va faire des aller-retours entre 2 valeurs
		transform.position = new Vector3(leftBound + pingP, transform.position.y, transform.position.z);	//on l'applique au transform

		//velocityX = travelled/Time.deltaTime;																//on calcule la vitesse de la plateforme (v = d/t)
		travelled = this.transform.position.x - previousX;													//2ème version : travelled est la distance parcourue
		previousX = this.transform.position.x;

		if( Mathf.Abs(pingP) < 0.1f || Mathf.Abs(pingP - Mathf.Abs(rightBound-leftBound)) < 0.1f)			//a l'approche des extremes, on met le bool isOnLimit
			isOnLimit = true;
		else
			isOnLimit = false;

																					//le bool isOnLimit empeche le joueur de tomber de la plateforme quand 
		if(groundedPlatform && !isOnLimit)											// ->la vitesse de la plateforme change de signe
		{
			//rb2d.AddForce(new Vector2(11.3f*velocityX,0),ForceMode2D.Force);		//on ajoute au joueur la vitesse de la plateforme sous forme de force
			player.transform.Translate(new Vector3(travelled,0,0));					//2ème version : on ajoute la distance parcourue entre les 2 dernières frames
		}
	}

	void OnTriggerStay2D(Collider2D coll)
	{	
		if(coll.tag == "groundCheck")
		{
			groundedPlatform = true;
			scriptMove.groundedPlatform = true;
		}	
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.tag == "groundCheck")
		{
			groundedPlatform = false;
			scriptMove.groundedPlatform = false;
		}			
	}
}