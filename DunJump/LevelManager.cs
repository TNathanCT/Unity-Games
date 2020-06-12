using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject CurrentCheckPoint;
    private PlayerController Player;

    void Start () {
        Player = FindObjectOfType<PlayerController>();

	}

	void Update () {
	
	}

    public void RespawnPlayer()
    {
        Debug.Log("I died");
        Player.transform.position = CurrentCheckPoint.transform.position;
        Player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

    }
}
