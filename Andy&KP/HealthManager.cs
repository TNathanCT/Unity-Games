using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public int maxPlayerHealth;
	public static int playerHealth;
	public Slider healthBar;
	private LevelManager levelmanager;
	public bool isDead = false;

	public Sprite[] heartcontainer;
	public Image displayheart;
	public int currentplayerlife = 0;


	// Use this for initialization
	void Start () 
	{
		//healthBar = GetComponent<Slider> ();
		levelmanager = GetComponent<LevelManager> ();
		isDead = false;
		FullHealth ();

	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (playerHealth > maxPlayerHealth)
			FullHealth();

		if (playerHealth <= 0 && !isDead) 
		{
			playerHealth = 0;
			//levelmanager.RespawnPlayer ();
			isDead = true;
		}
			
		//currentplayerlife = playerHealth;

		if(currentplayerlife == heartcontainer.Length)
		{
			currentplayerlife = 0;
		}


	}

	public static void HurtPlayer(int damageToGive)
	{
		playerHealth -= damageToGive;
	}

	public void FullHealth()
	{
		playerHealth = maxPlayerHealth;
	}
}
