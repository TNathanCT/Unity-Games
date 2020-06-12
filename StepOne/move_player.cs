using UnityEngine;
using System.Collections;

public class move_player : MonoBehaviour {

	public AudioClip audioWalk;
	public bool allowSprint;
	public GameObject nity;
	public float speed;
	public float timerSprint;
	[Range(1,10)]
	public float gravityFalling;
	[Range(1,5)]
	public float sprintFactor;
	[Range(0,1)]
	public float airControlFactor;
	[Range(0,10)]
	public float antiSlippingFactor;
	[HideInInspector]
	public Vector2 posInit;
	[HideInInspector]
	public bool groundedPlatform = false;
	public bool collidingEnnemy = false;

	public static bool grounded = false;

	private float timerSP;
	private Rigidbody2D rb2d;
	private bool boost;
	private float initialSpeed;
	private float initialGrav;
	private Animator anim;
	//private AudioSource source;

	void Awake()
	{
		posInit = (Vector2) this.transform.position;
		anim = nity.GetComponent<Animator>();
		//source = this.GetComponent<AudioSource>();
	}
		
	void Start () {
		initialSpeed = speed;
		rb2d = this.GetComponent<Rigidbody2D> ();
		initialGrav = rb2d.gravityScale;
		timerSP = timerSprint;
	}

	void Update () {
		if(Input.GetAxis ("Horizontal") !=0 && grounded)	//le perso peut sprinter seulement si il touche le sol
		{
			timerSP -= Time.deltaTime;						//on décrémente le timer si on se déplace
		}
		else
		{
			timerSP = timerSprint;							//on réinitialise le timer si on ne se déplace plus
			//speed = initialSpeed;
		}

		if(timerSP <= 0)								//temps de course atteint, passe en sprint
		{
			boost = true;							
		}
		if(boost && allowSprint)
		{
			speed *= sprintFactor;						//augmentation de la vitesse
			boost = false;								//empeche de boucler
			timerSP = timerSprint;						//reset du timer
		}

		if(!grounded)
		{
			rb2d.gravityScale = gravityFalling;			//aide a faire tomber plus vite le perso
			if(speed != 0)
			{
				speed = initialSpeed*airControlFactor;					//on affaiblit le controle en l'air du joueur
			}
			if(anim.enabled == true)
				anim.SetBool("grounded",false);
		}		
		else
		{
			if(speed<initialSpeed && speed != 0)
				speed = initialSpeed;
			rb2d.gravityScale = initialGrav;
			if(anim.enabled == true)
				anim.SetBool("grounded",true);
		}
	}

	void FixedUpdate(){
		float h = Input.GetAxis ("Horizontal") + Input.GetAxisRaw ("HorizontalJ") ;			//on récupère les appuis sur l'axe horizontal
		rb2d.AddForce(h*speed*Vector2.right);			//addforce pour déplacer le perso

		if((h < 0 && this.transform.localScale.x >0) || (h > 0 && this.transform.localScale.x < 0))				//ces deux lignes determinent 
			this.transform.localScale = Vector3.Scale(new Vector3(-1,1,1),this.transform.localScale);			//le sens du joueur pour l'affichage

		if(!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("HorizontalJ") == 0)
		{		
			rb2d.AddForce(Vector2.Scale((-antiSlippingFactor)*rb2d.velocity,Vector2.right));			//cette ligne empeche l'effet "savon" quand on déplace le perso
		}
		else
		{
			/*if(grounded)
			{
					source.clip = audioWalk;
					source.loop = true;
					source.Play();
			}*/
		}
		if( (Mathf.Abs(rb2d.velocity.x) != 0 && grounded && !groundedPlatform) || (Input.GetAxisRaw("Horizontal") != 0 && groundedPlatform) || (Mathf.Abs(Input.GetAxisRaw("HorizontalJ")) > 0.1 && groundedPlatform))
		{
			if(anim.enabled == true)
				anim.SetBool("isRunning",true);					//on lance l'animation de course
		}
		else
		{
			if(anim.enabled == true)
				anim.SetBool("isRunning",false);				//on retourne en animation d'idle
		}
	}

	void OnCollisionStay2D(Collider2D coll)
	{
		if(coll.tag == "ennemy")
		{
			collidingEnnemy = true;
		}
	}

	void OnCollisionExit2D(Collider2D coll)
	{
		if(coll.tag == "ennemy")
		{
			collidingEnnemy = false;
		}
	}

	void OnGUI(){
		//GUI.Label(new Rect(0,0,50,50),rb2d.velocity.x.ToString());
		//GUI.Label(new Rect(0,30,50,50),Input.GetAxisRaw("Horizontal").ToString());
		//GUI.Label(new Rect(0,60,100,50),this.transform.position.ToString());
		//GUI.Label(new Rect(0,90,50,50),grounded.ToString());
		//GUI.Label(new Rect(0,90,100,50),posInit.ToString());
	}
}
