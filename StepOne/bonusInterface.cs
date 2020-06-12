using UnityEngine;
using System.Collections;

public class bonusInterface : MonoBehaviour {

	//7ème bonus : ici on affiche l'interface et on permet le joueur de tuer les ennemis en leur sautant dessus
	//on perd également des coeurs au contact des ennemis

	[SerializeField]
	MovieTexture video;
	[SerializeField]
	AudioClip audio;
	[SerializeField]
	GameObject[] ihm;

	public GameObject ennemyChecker;
	public AudioSource source;
	public AudioClip sound;
	public GameObject objectVideoScript;
	public ennemyBumpV2 scriptBump;


	void OnTriggerEnter2D(Collider2D coll)
	{
		source.clip = sound;
		source.Play();

		objectVideoScript.GetComponent<videoScriptV2>().playVideo(video,audio);
		StartCoroutine(WaitVideo());
	}

	private IEnumerator WaitVideo()											//cette coroutine permet d'attendre que le fondu vidéo opère
	{
		yield return StartCoroutine(WaitForRealSeconds(2f));
		foreach(GameObject gObject in ihm)
		{
			gObject.gameObject.SetActive(true);
		}
		ennemyChecker.GetComponent<jumpOnEnnemy>().canKill = true;			//permet au joueur d'éliminer les ennemis
		scriptBump.allowBeingHit = true;									//permet de prendre un coup au contact d'un ennemi
		Destroy(this.gameObject);
	}

	IEnumerator WaitForRealSeconds(float time)								//méthode qui permet d'attendre un certain temps meme si TimeScale est nul
	{
		float start = Time.realtimeSinceStartup;
		while(Time.realtimeSinceStartup < start + time)
		{
			yield return null;
		}
	}
}
