using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bonusGraph : MonoBehaviour {

	//3ème bonus : ce script change les placeholders pour les graph

	[SerializeField]
	MovieTexture video;
	[SerializeField]
	AudioClip audio;
	public GameObject parallax;
	public GameObject inactiveNity;
	public Sprite newBackground;
	public AudioSource source;
	public AudioClip sound;
	public GameObject objectVideoScript;

	private GameObject[] plateformes,grounds,backgrounds;

	void OnTriggerEnter2D()
	{
		source.clip = sound;
		source.Play();

		plateformes = GameObject.FindGameObjectsWithTag("plateforme");
		grounds = GameObject.FindGameObjectsWithTag("ground");
		backgrounds = GameObject.FindGameObjectsWithTag("background");

		objectVideoScript.GetComponent<videoScriptV2>().playVideo(video,audio);
		StartCoroutine(WaitVideo());
	}

	private IEnumerator WaitVideo()													//cette coroutine permet d'attendre que le fondu vidéo opère
	{
		yield return StartCoroutine(WaitForRealSeconds(2f));
		foreach(GameObject platform in plateformes)
		{
			platform.GetComponent<MeshRenderer>().enabled = false;
			platform.GetComponentInChildren<SpriteRenderer>().enabled = true;
		}
		foreach(GameObject ground in grounds)
		{
			ground.GetComponentInChildren<SpriteRenderer>().enabled = true;
		}
		GameObject.Find("Player").GetComponent<MeshRenderer>().enabled = false;

		inactiveNity.SetActive(true);
		foreach(GameObject background in backgrounds)
		{
			background.SetActive(false);
		}
		parallax.SetActive(true);

		Destroy(this.gameObject);
	}

	IEnumerator WaitForRealSeconds(float time)						//méthode qui permet d'attendre un certain temps meme si TimeScale est nul
	{
		float start = Time.realtimeSinceStartup;
		while(Time.realtimeSinceStartup < start + time)
		{
			yield return null;
		}
	}
}
