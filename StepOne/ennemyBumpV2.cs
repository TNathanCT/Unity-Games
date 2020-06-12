using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ennemyBumpV2 : MonoBehaviour {

	public float xForce,yForce;
	[HideInInspector]
	public bool allowBeingHit = false;
	public AudioSource source;
	public List<GameObject> lifes;
	public GameObject checkpoint;
	[HideInInspector]
	public int lifesCount = 5;
	public jumpOnEnnemy killEnnemyScript;
	public VideoFade fadingScript;
	public GameObject gameOverImage;

	private float actualXForce;
	private Rigidbody2D rb2d;
	private float savedSpeed;
	private float savedScale;
	private bool travel = false;
	private bool hasFaded = false;

	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "ennemy")
		{
			float bumpDirection = coll.gameObject.transform.position.x - coll.contacts[0].point.x;	//on détermine le sens en x du vecteur (ennemi -> point de contact)
			if(bumpDirection > 0)
			{
				actualXForce = -xForce;																//on ajuste le sens de la force en fonction de cette direction
			}
			else
			{
				actualXForce = xForce;
			}
			rb2d.AddForce(new Vector2(actualXForce,yForce));
		}
	}		

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "ennemy")
		{
			float bumpDirection = coll.gameObject.transform.position.x - coll.contacts[0].point.x;	//on détermine le sens en x du vecteur (ennemi -> point de contact)
			if(bumpDirection > 0)
			{
				actualXForce = -xForce;																//on ajuste le sens de la force en fonction de cette direction
			}
			else
			{
				actualXForce = xForce;
			}
			rb2d.AddForce(new Vector2(actualXForce,yForce));
		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "ennemy")
		{
			source.Play();
			if(allowBeingHit)
			{
				lifes[lifesCount-1].gameObject.SetActive(false);						//sur une collision avec un ennemi, on perdu une vie/coeur
				lifesCount--;
			}
		}
	}

	void Update()
	{
		if(travel)																		//ce booléen permet de lancer une courte translation vers le point de respawn
		{
			float speed = Mathf.Abs(transform.position.x-checkpoint.transform.position.x);
			transform.position = Vector3.MoveTowards(transform.position,checkpoint.transform.position,speed*Time.deltaTime);
		}

		if(lifesCount == 0)																//si on perd toute nos vies
		{
			if(!hasFaded)																
			{
				fadingScript.StartFade(0.5f,1f,false);									//on lance le fondu
				gameOverImage.gameObject.SetActive(true);								//on affiche l'image de gameover
				hasFaded = true;
			}
			Time.timeScale = 0;
			if(Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Space))
			{
				GameOver();
				gameOverImage.gameObject.SetActive(false);								//on masque le gameover
			}
		}
	}

	void GameOver()
	{
		lifesCount = 5;																	//on reset le nombre de coeurs/vies
		Time.timeScale = 1;
		hasFaded = false;
		fadingScript.fade.color = new Color(0,0,0,0);									//on s'assure que le fondu est invisible
		killEnnemyScript.score = 0;														//on reset le score
		savedScale = transform.localScale.x;											//on sauvegarde le scale courant
		transform.localScale = new Vector3(0.001f,transform.localScale.y,transform.localScale.z);		//on met un scale très proche de 0 pour faire disparaitre le personnage
		transform.position = checkpoint.transform.position;
		travel = true;
		savedSpeed = GetComponent<move_player>().speed;
		GetComponent<move_player>().speed = 0;											//on empeche le joueur de bouger
		checkpoint.GetComponent<handleCheckpoint>().Spawn();							//on lance l'anim d'éclairs (qui dure 2 secondes)
		Invoke("Invoked",2f);
	}

	void Invoked()
	{
		transform.localScale = new Vector3(savedScale,transform.localScale.y,transform.localScale.z);	
		GetComponent<move_player>().speed = savedSpeed;								//on remet l'ancien scale/ancienne vitesse
		foreach(GameObject heart in lifes)											//on remet les coeurs/vies
		{
			heart.SetActive(true);
		}
		travel = false;
	}
}
