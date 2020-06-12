using UnityEngine;
using System.Collections;

public class ennemyBump : MonoBehaviour {

	public float xForce,yForce;

	private float actualXForce;

	void OnCollisionStay2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			float bumpDirection = coll.gameObject.transform.position.x - coll.contacts[0].point.x;	//on détermine le sens en x du vecteur (point de contact -> joueur)
			if(bumpDirection < 0)
			{
				actualXForce = -xForce;																//on ajuste le sens de la force en fonction de cette direction
			}
			else
			{
				actualXForce = xForce;
			}
			coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(actualXForce,yForce));
		}
	}		

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			float bumpDirection = coll.gameObject.transform.position.x - coll.contacts[0].point.x;	//on détermine le sens en x du vecteur (point de contact -> joueur)
			if(bumpDirection < 0)
			{
				actualXForce = -xForce;																//on ajuste le sens de la force en fonction de cette direction
			}
			else
			{
				actualXForce = xForce;
			}
			coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(actualXForce,yForce));
		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			this.GetComponent<AudioSource>().Play();
		}
	}
}
