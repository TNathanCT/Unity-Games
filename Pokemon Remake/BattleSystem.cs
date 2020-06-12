using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

[System.Serializable]
public class BattleSystem : MonoBehaviour
{

	//This grabs the stats of the pokemon that are found at the bottom of the script
	LucarioStats lucarioData;
	EmpoleonStats empoleonData;

	//We make a list of the gameobjects that we wish to spawn
	public List<GameObject> ObjectstoSpawn;

	//The reason these aren't in a list, is because I am currently deactivating them. This will be cleaned up in the optimization phase.
	public GameObject playerTrainerPrefab;
	public GameObject enemyTrainerPrefab;
	public GameObject actionButtons;
	GameObject moves;

	//Simply sets the position for the player's and the AI's pokemon
	public Transform playerBattleStation;
	public Transform enemyBattleStation;
	private Transform thomasoutofSight;


	//references to each pokemon's characteristics
	Unit playerUnit;
	Unit enemyUnit;

	public Text dialogueText;

	//References to the HUDS.
	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

	public AudioSource bGM;

	//calling the palyer scripts in order to call various movement methods and animations
	NathanTrainerScript nathanscript;
	ThomasThrowsPokeball thomasscript;

	public bool moveNathanaside = false;

	//We can decide what state we want out game to have.
	public BattleState state;



	//This will set up the text for the moves as well as their pp
	private Text[]
		pokemonMovesName = new Text[4],
		pokemonMovesText = new Text[4],
		pokemonMovesPPText = new Text[4];
		

	public Image[]
		pokemonMovesType = new Image[4],
		pokemonMoves = new Image[4];



	private GameObject pokemonMoveButtons;
	public string[] empoleonMoveSet = new string[4];
	public string[] lucarioMoveSet = new string[4];
	public string[] pokemonMovesMaxPP = new string[4];
	public string[] pokemonMovesCurrentPP = new string[4];



	MovesDetails getMoves;

	//These will be set for the player animation to avoid having to constantly reuse animations
	public Sprite[] playerSprites = new Sprite[5];






	void Awake()
	{

		moveNathanaside = false;


		//We create a new class so that we may use the information stored within them.
		empoleonData = new EmpoleonStats();
		lucarioData = new LucarioStats();
		nathanscript = Object.FindObjectOfType<NathanTrainerScript>();
		thomasscript = Object.FindObjectOfType<ThomasThrowsPokeball>();
		getMoves = GetComponent<MovesDetails>();
		thomasoutofSight = GameObject.Find("ThomasOutofSight").transform;


		//we set the state of the match.
		state = BattleState.START;
		bGM.Play();

		actionButtons.SetActive(false);

		playerTrainerPrefab.transform.position = playerBattleStation.transform.position;
		playerTrainerPrefab.GetComponentInChildren<SpriteRenderer>().sprite = playerSprites[0];


		//Here, we set up empoleon's moves.
		
		for (int i = 0; i < 4; i++)
		{
			
			moves = GameObject.Find("Move"+(i));
			//We get the information of each attack.
			empoleonMoveSet[i] = getMoves.GetMove(i).GetName();
			pokemonMovesMaxPP[i] = getMoves.GetMove(i).GetMaxPP().ToString();




			//Grab where they will be displayed.
			pokemonMovesName[i] = moves.transform.Find("Name").GetComponent<Text>();
			pokemonMovesPPText[i] = moves.transform.Find("PP").GetComponent<Text>();


			//Display the current information
			pokemonMovesPPText[i].text = pokemonMovesCurrentPP[i]+"/"+pokemonMovesMaxPP[i];
			pokemonMovesName[i].text = empoleonMoveSet[i];



		}

		for (int j = 0; j < 9; j++)
		{
			lucarioMoveSet[j] = getMoves.GetMove(j + 4).GetName();
		}
	}


	//This coroutine sets up the battle for us
	public IEnumerator SetupBattle()
	{
		//This will set the AI's final position once it moves out of the screen. It will be removed in the future.
		Vector2 end = GameObject.Find("NathanOutofSight").transform.position;
		float speed = 13f;
		yield return new WaitForSeconds(2f);


		//We want to instantiate the pokeball from the List and play the audio with the animation assigned to it. 
		GameObject pokeballGo = Instantiate(ObjectstoSpawn[2], enemyBattleStation);
		Animator nathansPokeballAnimation = pokeballGo.GetComponentInChildren<Animator>();
		AudioSource nathanpokeballAudio = pokeballGo.GetComponentInChildren<AudioSource>();


		//So this is simply to move the AI sprite out of the screen when the fight begins.
		while (moveNathanaside == true && Vector2.Distance(enemyTrainerPrefab.transform.position, end) > speed * Time.deltaTime)
		{

			enemyTrainerPrefab.transform.position = Vector2.MoveTowards(enemyTrainerPrefab.transform.position, end, speed * Time.deltaTime);

			yield return 0;

		}

		//PLay the animation of the pokeball, and instatiate the prefab Lucario from the list, before destroying the pokeball (it is not needed anymore)
		nathansPokeballAnimation.SetBool("openTheBall", true);
		GameObject pokeballParticleSystem = Instantiate(ObjectstoSpawn[3], enemyBattleStation);
		nathanpokeballAudio.Play();
		yield return new WaitForSeconds(1f);
		Destroy(pokeballGo);



		//Run the function that will set up the stats and the AI for the Lucario. Then, update the HUD.
		InstantiateLucario();
		yield return new WaitForSeconds(2f);
		enemyHUD.SetHP(enemyUnit.currentHP);



		StartCoroutine(AnimatePlayerThrow());
		Destroy(pokeballParticleSystem);
		yield return new WaitForSeconds(1f);



		//We do the same for the Empoleon.
		GameObject newpokeballparticlesystem = Instantiate(ObjectstoSpawn[3], playerBattleStation.position, Quaternion.identity);
		yield return new WaitForSeconds(0.2f);
		InstantiateEmpoleon();
		yield return new WaitForSeconds(2f);
		playerHUD.SetHP(playerUnit.currentHP);
		yield return new WaitForSeconds(2f);


		//Once the fight has been set up, we move over to the playerr's turn.
		//This will be updated so that the pokemon move depending on the speed stat.
		state = BattleState.PLAYERTURN;

		PlayerTurn();

	}


	private IEnumerator SlidePlayerTrainer(Transform objectoMove, Vector3 a, Vector3 b, float speed)
	{
		float step = (speed / (a - b).magnitude) * Time.fixedDeltaTime;
		float t = 0;
		while (t <= 1.0f)
		{
			t += step;
			objectoMove.position = Vector3.Lerp(a, b, t);
			yield return new WaitForFixedUpdate();

		}
		objectoMove.transform.position = b;


	}

	private IEnumerator AnimatePlayerThrow()
	{
		for (int i = 0; i < 5; i++)
		{
			playerTrainerPrefab.GetComponentInChildren<SpriteRenderer>().sprite = playerSprites[i];
			yield return new WaitForSeconds(.1f);

			if (i == 1)
			{
				StartCoroutine(SlidePlayerTrainer(playerTrainerPrefab.transform, playerBattleStation.position, thomasoutofSight.position, 25f));		
			}

			if(i == 3)
			{
				thomasscript.SpawnPokeball();
				GameObject obj = GameObject.Find("ThomasPokeball(Clone)");
				yield return new WaitForSeconds(3f);
				Destroy(obj);
			}
		}


	}




	//this method focuses on setting up Empoleon's stats.
	void InstantiateEmpoleon()
	{

		//First, we assign the gameobject we wish to spawn from the prefab from our list
		GameObject playerGO = Instantiate(ObjectstoSpawn[1], playerBattleStation);
		playerUnit = playerGO.GetComponent<Unit>();

		//Since empoleon has two types, I cloned the array in the EmpoleonStats classed and assigned them in a new array.
		playerUnit.pokemonType = (string[])empoleonData.type.Clone();
		playerUnit.unitName = empoleonData.Name;


		playerUnit.maxHP = Mathf.FloorToInt((((empoleonData.HP + 7) * 2 * (9.21f / 4) * empoleonData.level) / 100) + playerUnit.unitLevel + 10);
		playerUnit.attack = Mathf.FloorToInt(((((2 * empoleonData.ATK + 8 + (empoleonData.EV / 4)) * empoleonData.level) / 100) + 5) * 1f);
		playerUnit.defense = Mathf.FloorToInt(((((2 * empoleonData.DEF + 13 + (empoleonData.EV / 4)) * empoleonData.level) / 100) + 5) * 1f);
		playerUnit.specialAttack = Mathf.FloorToInt(((((2 * empoleonData.SpeATK + 9 + (empoleonData.EV / 4)) * empoleonData.level) / 100) + 5) * 1.1f);
		playerUnit.specialDefense = Mathf.FloorToInt(((((2 * empoleonData.SpeDEF + 9 + (empoleonData.EV / 4)) * empoleonData.level) / 100) + 5) * 1f);
		playerUnit.speed = Mathf.FloorToInt(((((2 * empoleonData.SPD + 5 + (empoleonData.EV / 4)) * empoleonData.level) / 100) + 5) * 0.9f);

		playerUnit.pokemonCry.Play();
		playerHUD.SetHUD(playerUnit);

		dialogueText.text = "You're up " + playerUnit.unitName + "!";
	}

	//Same for Lucario
	void InstantiateLucario()
	{
		GameObject enemyGO = Instantiate(ObjectstoSpawn[0], enemyBattleStation);
		enemyUnit = enemyGO.GetComponent<Unit>();

		enemyUnit.pokemonType = (string[])lucarioData.type.Clone();
		enemyUnit.unitName = lucarioData.Name;


		enemyUnit.maxHP = Mathf.FloorToInt((((lucarioData.HP + 7) * 2 * (9.21f / 4) * lucarioData.level) / 100) + enemyUnit.unitLevel + 10);
		enemyUnit.attack = Mathf.FloorToInt(((((2 * lucarioData.ATK + 8 + (lucarioData.EV / 4)) * lucarioData.level) / 100) + 5) * 0.9f);
		enemyUnit.defense = Mathf.FloorToInt(((((2 * lucarioData.DEF + 13 + (lucarioData.EV / 4)) * lucarioData.level) / 100) + 5) * 1.1f);
		enemyUnit.specialAttack = Mathf.FloorToInt(((((2 * lucarioData.SpeATK + 9 + (lucarioData.EV / 4)) * lucarioData.level) / 100) + 5) * 1f);
		enemyUnit.specialDefense = Mathf.FloorToInt(((((2 * lucarioData.SpeDEF + 9 + (lucarioData.EV / 4)) * lucarioData.level) / 100) + 5) * 1f);
		enemyUnit.speed = Mathf.FloorToInt(((((2 * lucarioData.SPD + 5 + (lucarioData.EV / 4)) * lucarioData.level) / 100) + 5) * 1f);

		enemyUnit.pokemonCry.Play();
		enemyHUD.SetHUD(enemyUnit);
		dialogueText.text = "Nathan sent out " + enemyUnit.unitName + "!\n";
	}

	//This plays when the player chooses to attack. It is still in development, so this is just a temporary solution that will be modified.
	IEnumerator PlayerAttack()
	{
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

		//We update the enemyHud by removing the amount they lost from their current HP.
		enemyHUD.SetHP(enemyUnit.currentHP);
		dialogueText.text = "The attack is successful!";

		yield return new WaitForSeconds(2f);

		//Then we move over to the next state. Again, the 'Enemy Turn' may play after the player has acted, but this will be updated so that Speed will determine who goes first.
		if (isDead)
		{
			state = BattleState.WON;
			EndBattle();
		}
		else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}


	IEnumerator EnemyTurn()
	{
		//Disable the buttons to prevent the player from acting during the opponent's turn.
		actionButtons.SetActive(false);

		dialogueText.text = enemyUnit.unitName + " attacks!";

		yield return new WaitForSeconds(1f);

		bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

		playerHUD.SetHP(playerUnit.currentHP);

		yield return new WaitForSeconds(1f);

		if (isDead)
		{
			state = BattleState.LOST;
			EndBattle();
		}
		else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}

	}

	void EndBattle()
	{
		if (state == BattleState.WON)
		{
			dialogueText.text = "You won the battle!";
		}
		else if (state == BattleState.LOST)
		{
			dialogueText.text = "You were defeated.";
		}
	}

	void PlayerTurn()
	{

		dialogueText.text = "Choose an action:";
		actionButtons.SetActive(true);
	}

	IEnumerator PlayerHeal()
	{
		//If the player chooses to heal, then they will regain 5 HP. I plan on removing this and replacing it with an inventory in the future.
		playerUnit.Heal(5);

		playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "You feel renewed strength!";

		yield return new WaitForSeconds(2f);

		state = BattleState.ENEMYTURN;
		StartCoroutine(EnemyTurn());
	}

	public void OnAttackButton()
	{


		if (state != BattleState.PLAYERTURN)
			return;


		StartCoroutine(PlayerAttack());
	}

	public void OnHealButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerHeal());
	}

	private void Update()
	{
		playerHUD.SetHP(playerUnit.currentHP);
		enemyHUD.SetHP(enemyUnit.currentHP);

	}











}
/*
 


	
    private IEnumerator slidePokemonStats(int position, bool retract)
    {
        float distanceX = pokemonStatsDisplay[position].rectTransform.sizeDelta.x;
        float startX = (retract) ? 171f - (distanceX / 2) : 171f + (distanceX / 2);
        //flip values if opponent stats
        if (position > 2)
        {
            startX = -startX;
            distanceX = -distanceX;
        }
        //flip movement direction if retracting
        if (retract)
        {
            distanceX = -distanceX;
        }

        pokemonStatsDisplay[position].gameObject.SetActive(true);

        float speed = 0.3f;
        float increment = 0f;
        while (increment < 1)
        {
            increment += (1 / speed) * Time.deltaTime;
            if (increment > 1)
            {
                increment = 1f;
            }

            pokemonStatsDisplay[position].rectTransform.localPosition = new Vector3(startX - (distanceX * increment),
                pokemonStatsDisplay[position].rectTransform.localPosition.y, 0);

        
	yield return null;
        }
    }

	 */










[System.Serializable]
public class LucarioStats
{
	public string Name = "Lucky";
	public string Nature = "Bold";
	public string Ability = "Steadfast";
	public string[] type = new string[2] { "Steel", "Fighting" };
	public int level = 50;
	public int HP = 70;
	public int ATK = 110;
	public int DEF = 70;
	public int SpeATK = 115;
	public int SpeDEF = 70;
	public int SPD = 90;
	public float EV = 85f;



}

[System.Serializable]
public class EmpoleonStats
{
	public string Name = "Napoleon";
	public string Nature = "Quiet";
	public string Ability = "Torrent";
	public string[] type = new string[2] { "Steel", "Water" };
	public int level = 50;
	public int HP = 84;
	public int ATK = 86;
	public int DEF = 88;
	public int SpeATK = 111;
	public int SpeDEF = 101;
	public int SPD = 84;
	public float EV = 85f;
}