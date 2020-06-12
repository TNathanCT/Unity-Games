using UnityEngine;
using System.Collections;

public class bonusAnim : MonoBehaviour {

	//4ème bonus qui amène les animations

	[SerializeField]
	MovieTexture video;
	[SerializeField]
	AudioClip audio;

	public GameObject nity;
	public AudioSource source;
	public AudioClip sound;
	public GameObject objectVideoScript;

	private Animator anim;

	void Start(){
		anim = nity.GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		source.clip = sound;
		source.Play();

		anim.enabled = true;

		objectVideoScript.GetComponent<videoScriptV2>().playVideo(video,audio);
		Destroy(this.gameObject);
	}
}
