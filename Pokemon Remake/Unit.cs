using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Unit : MonoBehaviour
{

	public string unitName;
	public int unitLevel;
	public string[] pokemonType = new string[2];


	public int attack;
	public int defense;
	public int specialAttack;
	public int specialDefense;
	public int speed;
	public int maxHP;


	public int damage;
	public int currentHP;

	public AudioSource pokemonCry;

	Vector3 startingScale;
	Vector3 finalScale;
	float minLocalScaleMagnitude;
	float maxLocalScaleMagnitude;




	void Start()
    {

		startingScale.Set(0.1f, 0.1f, 0.1f);
		finalScale.Set(0.7f, 0.7f, 0.7f);
		minLocalScaleMagnitude = startingScale.magnitude;
		maxLocalScaleMagnitude = finalScale.magnitude;

		this.transform.localScale = new Vector3(0.1f, 0.1f, 0);

		pokemonCry = GetComponent<AudioSource>();

		currentHP = maxHP;
    }
	
	void IncreaseScale()
    {
		float currentlocalScaleMagnitude = this.transform.localScale.magnitude;
		if(currentlocalScaleMagnitude < maxLocalScaleMagnitude)
        {
			this.transform.localScale += new Vector3 (0.1f, 0.1f, 0) * (Time.deltaTime * 50f);
		}


    }


	void Update()
    {
		IncreaseScale();
    }


	public bool TakeDamage(int dmg)
	{
		currentHP -= dmg;

		if (currentHP <= 0)
			return true;
		else
			return false;
	}

	public void Heal(int amount)
	{
		currentHP += amount;
		if (currentHP > maxHP)
			currentHP = maxHP;
	}

}
