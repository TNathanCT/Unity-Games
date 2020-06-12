using UnityEngine;
using System.Collections;

public class musicScript : MonoBehaviour {

	public GameObject blackSprite;
	public videoScriptV2 videoScript;
	public VideoFade fadeScript;
	[HideInInspector]
	public bool ready = false;
	[SerializeField]
	MovieTexture video;
	[SerializeField]
	AudioClip audio;

	private bool played = false;
	private bool introPlayed = false;

	void Update () {
		if(ready)
		{
			if(!video.isPlaying && !played)
			{
				GetComponent<AudioSource>().Play();
				played = true;
			}
		}

		if(!introPlayed)
		{
			videoScript.playVideo(video,audio);
			Invoke("Hide",0.1f);
			introPlayed = true;
		}
	}

	void Hide()
	{
		blackSprite.SetActive(false);
	}
}
