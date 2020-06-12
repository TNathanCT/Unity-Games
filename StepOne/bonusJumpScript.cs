using UnityEngine;
using System.Collections;

public class bonusJumpScript : MonoBehaviour {

	//Premier bonus qui ajout le script pour sauter

	[SerializeField]
	GameObject player;
	[SerializeField]
	MovieTexture video;
	[SerializeField]
	AudioClip audio;

	public AudioSource source;
	public AudioClip sound;
	public GameObject objectVideoScript;

	private Jump script;

	void Start(){
		script = player.GetComponent<Jump>();
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		source.clip = sound;
		source.Play();
		script.enabled = true;
		objectVideoScript.GetComponent<videoScriptV2>().playVideo(video,audio);
		Destroy(this.gameObject);
	}
}
