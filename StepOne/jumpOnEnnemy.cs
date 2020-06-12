using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class jumpOnEnnemy : MonoBehaviour {
	
	private AudioSource source;
	private Rigidbody2D rb2d;
	private float counter = 2;
	private bool success = false;
	private move_player moveScript;

	[HideInInspector]
	public bool canKill = false;
	[HideInInspector]
	public int score = 0;
	public AudioClip audioKill;
	public float knockUpAtKill;
	public GameObject player;
	public Text scoreText;
	public VideoFade fadingScript;
	public GameObject succeededQuest;

	void Start () {
		source = this.GetComponent<AudioSource>();
		source.clip = audioKill;
		player = this.transform.parent.gameObject;
		moveScript = player.GetComponent<move_player>();
		rb2d = player.GetComponent<Rigidbody2D>();
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "ennemy" && canKill && !moveScript.collidingEnnemy)
		{
			coll.tag = "dead";
			rb2d.AddForce(knockUpAtKill*Vector2.up);									//On effectue un petit rebondi sur l'ennemi
			coll.gameObject.GetComponent<EnemyOne>().enabled = false;					//Desactive le script qui fait bouger l'ennemi
			coll.gameObject.GetComponent<Collider2D>().isTrigger = true;				//Desactive les collisions
			source.Play();																//Son quand on écrase un ennemi
			coll.gameObject.GetComponentInChildren<ParticleSystem>().Play();			//On lance les particules "pouf"
			coll.gameObject.GetComponentInChildren<SpriteRenderer>().gameObject.SetActive(false);	//On désactive les graph de l'ennemi
			score += 10;
			counter = 0;
			Destroy(coll.gameObject,2);													//Puis on détruit l'ennemi
		}
	}

	void Update()
	{
		if(counter < 1.5f)								//counter sert de timer personnalisé pour la méthode PingPong
		{
			scoreText.transform.parent.localScale = (1+Mathf.PingPong(counter*0.4f,0.3f))*Vector3.one;	//cette ligne permet l'effet de zoom quand on récupère du score
			counter += Time.deltaTime;
		}
		else
		{
			counter = 1.5f;
		}
		scoreText.text = "Score : "+ score;
		if(score == 50 && !success)
		{
			Time.timeScale = 0;
			fadingScript.StartFade(0.5f,1f,false);
			success = true;
			succeededQuest.gameObject.SetActive(true);
		}
		if(success)
		{
			if(Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Space))
			{
				Time.timeScale = 1;
				SceneManager.LoadScene("Menu principal");
			}
		}
	}

	void ShowEndQuest()
	{
		succeededQuest.gameObject.SetActive(true);
	}
}
