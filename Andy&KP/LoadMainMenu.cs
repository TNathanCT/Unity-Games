using UnityEngine;
using System.Collections;
using eeGames.Widget;

public class LoadMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		WidgetManager.Instance.Push (WidgetName.MyMainMenu);
	}
	

}
