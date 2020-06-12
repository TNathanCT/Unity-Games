using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {

	public GameObject[] tools;
	public bool istheshieldout;
	public bool isthechargerout;

	void Start(){
		istheshieldout = true;
		isthechargerout = false;
		ChangeWeapon (0);
	}

	void Update () {

		if (Input.GetMouseButtonDown(0) && isthechargerout == true && istheshieldout == false) {
			istheshieldout = true;
			isthechargerout = false;
			ChangeWeapon (0);


		}

		else if(Input.GetMouseButtonDown(0)  && isthechargerout == false && istheshieldout == true){
			istheshieldout = false;
			isthechargerout = true;
			ChangeWeapon (1);
		}



	}

	public void ChangeWeapon(int seq){

		disableALL ();
		tools [seq].SetActive (true);
	}

	public void disableALL(){
		foreach (GameObject tool in tools) {
			tool.SetActive (false);
		}
	}
}
