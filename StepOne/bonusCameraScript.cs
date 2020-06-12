using UnityEngine;
using System.Collections;

public class bonusCameraScript : MonoBehaviour {

	//2ème bonus qui permet à la caméra de suivre le joueur via camera_follow

	[SerializeField]
	Camera camera;
	[SerializeField]
	MovieTexture video;
	[SerializeField]
	AudioClip audio;

	public GameObject boundLeft, boundRight;
	public AudioSource source;
	public AudioClip sound;
	public GameObject objectVideoScript;

	private camera_follow script;

	void Start(){
		script = camera.GetComponent<camera_follow>();
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		source.clip = sound;
		source.Play();
		script.enabled = true;
		Destroy(boundLeft);
		Destroy(boundRight);
		objectVideoScript.GetComponent<videoScriptV2>().playVideo(video,audio);					
		Destroy(this.gameObject);
	}
}
