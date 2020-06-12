using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

	public Transform[] patrolpoints;
	public float movespeed;
	private int Currentposition;


	void Start () {
		transform.position = patrolpoints [0].position;
		Currentposition = 0;
	}
	

	void Update () {
		if (Currentposition >= patrolpoints.Length) {
			Currentposition = 0;

		}

		if (transform.position == patrolpoints [Currentposition].position) {
			Currentposition++;
		}

		transform.position = Vector3.MoveTowards(transform.position, patrolpoints[Currentposition].position, movespeed * Time.deltaTime);
			
			
	}
}
