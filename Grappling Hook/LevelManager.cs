using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject CurrentCheckPoint;
    private PlayerMovement PM;


	void Start () {
        PM = FindObjectOfType<PlayerMovement>();	
	}
	
    public void RespawnPlayer()
    {
        Debug.Log("I died");
        PM.transform.position = CurrentCheckPoint.transform.position;
        PM.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
