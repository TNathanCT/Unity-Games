using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeartUI : MonoBehaviour {

	public Sprite[] heartContainer;
	public Image heartLeft;
	public int currentLife = 0;
	private HealthManager hurtplayer;




	// Use this for initialization
	void Start () 
	{
		hurtplayer = GetComponent<HealthManager> ();
	}

	void LoseLife()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		heartLeft.sprite = heartContainer [currentLife];
	}
}
