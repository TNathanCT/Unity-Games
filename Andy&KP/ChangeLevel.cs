using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeLevel : MonoBehaviour {

	public string nextLevel;

	public void ChangeIsChanged()
	{
		StartCoroutine(ChangeLevelCo());
	}
		
	public IEnumerator ChangeLevelCo()
	{
		float fadeTime = GameObject.Find ("Game Manager").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel (nextLevel);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") 
		{
			Debug.Log ("change level");
			ChangeIsChanged ();
		}
	}
}
