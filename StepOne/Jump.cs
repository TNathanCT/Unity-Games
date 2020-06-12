using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	private Rigidbody2D rb2d;
	private Animator anim;
	private AudioSource source;

	public float strength;
	public GameObject nity;
	public AudioClip audioJump;

	// Use this for initialization
	void Start () {
		rb2d = this.GetComponent<Rigidbody2D> ();
		anim = nity.GetComponent<Animator>();
		source = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale != 0)
		{
			if (Input.GetKeyDown (KeyCode.UpArrow) && move_player.grounded) {
				source.clip = audioJump;
				source.loop = false;
				source.Play();
				rb2d.AddForce (strength*Vector2.up);
				anim.SetTrigger("jumping");
			}

			if(Input.GetKeyDown(KeyCode.Joystick1Button0) && move_player.grounded)
			{
				source.clip = audioJump;
				source.loop = false;
				source.Play();
				rb2d.AddForce (strength*Vector2.up);
				anim.SetTrigger("jumping");
			}
		}
	}
}
