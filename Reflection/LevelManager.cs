using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject HiddenEnemy;
	public Transform SpawnHiddenEnemy;

	void Start () {
		Instantiate (HiddenEnemy, SpawnHiddenEnemy.position, SpawnHiddenEnemy.rotation);
	}
}
