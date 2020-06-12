using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using eeGames.Widget;
using System;

public class MainMenu : Widget {

	public string startLevel;
	[SerializeField] private Button levelSelect;	
	//public string levelSelect;

	protected override void Awake()
	{
		levelSelect.onClick.AddListener (LevelSelect);
	}
		
	void OnDestroy()
	{
		levelSelect.onClick.RemoveListener (LevelSelect);
	}

	public void NewGame()
	{
		Application.LoadLevel (startLevel);
	}

	public void LevelSelect()
	{
		//Application.LoadLevel (levelSelect);
		WidgetManager.Instance.Push (WidgetName.LevelSelect, false, true);
	}

	public void QuitGame()
	{
		Debug.Log ("Game Quit");
		Application.Quit();
	}
}
