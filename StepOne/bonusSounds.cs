using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bonusSounds : MonoBehaviour {

	//5ème bonus qui ajoute les sons et la musique

	[SerializeField]
	MovieTexture video;
	[SerializeField]
	AudioClip audio;

	public GameObject objectVideoScript;
	public List<AudioSource> sources;
	public musicScript musicST;

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "Player")
		{
			foreach(AudioSource source in sources)
			{
				source.mute = false;
			}
			objectVideoScript.GetComponent<videoScriptV2>().playVideo(video,audio);
			musicST.ready = true;
			Destroy(this.gameObject);
		}
	}
}
