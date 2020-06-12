using UnityEngine;
using System.Collections;

public class videoScript : MonoBehaviour {

	//Ce script permet d'utiliser la fonction statique playVideo pour lire une vidéo en plein écran

	static MovieTexture video;
	static AudioSource audioSource;
	static bool played = false;

	private bool allowStop;

	void Awake()
	{
		audioSource = this.GetComponent<AudioSource>();
	}

	public static void playVideo(MovieTexture movie,AudioClip audio)
	{
		video = movie;
		audioSource.clip = audio;
		video.Play();							//on joue la vidéo
		played = true;							//permet d'afficher la texture
		audioSource.Play();						//on joue l'audio
		Time.timeScale = 0;						//on stoppe le jeu le temps de la vidéo
	}

	void OnGUI () {
		if(played)
		{
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),video,ScaleMode.StretchToFill);
			if(video.isPlaying)
				allowStop = true;
			if((!video.isPlaying || Input.GetKeyDown("space")) && allowStop)							//on quitte la vidéo avec espace si necessaire
			{
				audioSource.Stop();
				video.Stop();
				played = false;
				allowStop = false;
				Time.timeScale = 1;
			}
		}
	}
}
