using UnityEngine;
using System.Collections;

public class videoScriptV2 : MonoBehaviour {


	//Ce script permet d'utiliser la fonction playVideo pour lire une vidéo en plein écran

	public bool isPlaying = false;

	private MovieTexture video;
	private AudioSource audioSource;
	private bool played = false;
	private bool allowStop;

	void Awake()
	{
		audioSource = this.GetComponent<AudioSource>();
	}

	public void playVideo(MovieTexture movie,AudioClip audio)
	{
		isPlaying = true;
		video = movie;
		audioSource.clip = audio;
		this.GetComponent<VideoFade>().StartFade(1f,2.1f,true);
		StartCoroutine(playVideoInvoked());
		Time.timeScale = 0;														//on stoppe le jeu le temps de la vidéo
	}

	void OnGUI () {
		if(played)
		{
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),video,ScaleMode.StretchToFill);
			if(video.isPlaying)
			{
				allowStop = true;
			}
			if((!video.isPlaying || Input.GetKeyDown(KeyCode.Space)) && allowStop)							//on quitte la vidéo avec espace si necessaire
			{
				audioSource.Stop();
				video.Stop();
				played = false;
				allowStop = false;
				isPlaying = false;
				Time.timeScale = 1;
			}
		}
	}

	private IEnumerator playVideoInvoked()
	{
		yield return StartCoroutine(WaitForRealSeconds(2f));				//on attend le temps du fondu
		video.Play();							//on joue la vidéo
		played = true;							//permet d'afficher la texture
		audioSource.Play();						//on joue l'audio
	}

	IEnumerator WaitForRealSeconds(float time)
	{
		float start = Time.realtimeSinceStartup;
		while(Time.realtimeSinceStartup < start + time)
		{
			yield return null;
		}
	}
}
