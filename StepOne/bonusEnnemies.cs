using UnityEngine;
using System.Collections;

public class bonusEnnemies : MonoBehaviour {

	//6ème bonus qui permet la collision avec les ennemis

	private GameObject[] ennemies;

	[SerializeField]
	MovieTexture video;
	[SerializeField]
	AudioClip audio;

	public AudioSource source;
	public AudioClip sound;
	public GameObject objectVideoScript;

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "Player")
		{
			source.clip = sound;
			source.Play();
			foreach(GameObject ennemy in ennemies)
			{
				ennemy.GetComponent<BoxCollider2D>().isTrigger = false;
			}

			objectVideoScript.GetComponent<videoScriptV2>().playVideo(video,audio);
			Destroy(this.gameObject);
		}
	}

	void Start () {
		ennemies = GameObject.FindGameObjectsWithTag("ennemy");
	}
}
