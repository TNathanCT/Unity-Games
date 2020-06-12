using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using eeGames.Widget;
using System;

public class LevelSelect : Widget {


	public string niveau1;
	public string niveau2;
	public string niveau3;
	public string niveau4;
	[SerializeField] private Button mainMenu;

	protected override void Awake()
	{
		mainMenu.onClick.AddListener (MyMainMenu);
	}

	void OnDestroy()
	{
		mainMenu.onClick.RemoveListener (MyMainMenu);
	}

	public void MyMainMenu()
	{
		WidgetManager.Instance.Pop (false);
	}

	public void Niveau1()
	{
		Application.LoadLevel (niveau1);
	}

	public void Niveau2()
	{
		Application.LoadLevel (niveau2);
	}

	public void Niveau3()
	{
		Application.LoadLevel (niveau3);
	}

	public void Niveau4()
	{
		Application.LoadLevel (niveau4);
	}
}
