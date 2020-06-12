using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour {

	public GameObject Part1;
	public GameObject Part2;

	void Start () {
		Part1.SetActive (false);
		Part2.SetActive (false);
		
	}
	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Player") {
			Part1.SetActive (true);
			Part2.SetActive (true);
		}

	}

	void OnTriggerStay(Collider coll){
		if (coll.gameObject.tag == "Player") {
			Part1.SetActive (true);
			Part2.SetActive (true);
		}
	}

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag == "Player") {
			Part1.SetActive (true);
			Part2.SetActive (true);
		}

	}

	void OnCollisionStay(Collision coll){
		if (coll.gameObject.tag == "Player") {
			Part1.SetActive (true);
			Part2.SetActive (true);
		}
	}


}
