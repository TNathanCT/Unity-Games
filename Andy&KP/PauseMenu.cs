using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class PauseMenu : MonoBehaviour {

	public string levelSelect;
	public string mainMenu;
	public bool isPaused;
	public GameObject pauseCanvas;
	//private ChangeLevel fade;

	void Start()
	{
//		fade = GetComponent<ChangeLevel> ();
	}

	void Update()
	{
		if (isPaused) {
			pauseCanvas.SetActive (true);
			Time.timeScale = 0f;
		} else 
		{
			pauseCanvas.SetActive (false);
			Time.timeScale = 1f;
		}

		if (Input.GetKeyDown (KeyCode.P)) 
		{
			isPaused = !isPaused;
		}
	}

	public void Resume()
	{
		isPaused = false;	
	}

	public void LevelSelect()
	{
		Application.LoadLevel (levelSelect);
	}

	public void Quit()
	{
		Application.LoadLevel (mainMenu);
	}
}
