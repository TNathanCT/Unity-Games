using UnityEngine;
using System.Collections;

public class respawn : MonoBehaviour {

	//Ce script, attaché a de larges trigger, permettent de faire respawn le joueur à l'endoir voulu

	public GameObject player;
	public GameObject respawnPoint;

	private Vector2 posReset;
	private Rigidbody2D rb2d;

	void Start()
	{
		//posReset = player.GetComponent<move_player>().posInit;
		rb2d = player.GetComponent<Rigidbody2D>();
	}

	void OnTriggerEnter2D()
	{
		//player.transform.position = posReset;
		player.transform.position = respawnPoint.transform.position;
		rb2d.velocity = Vector2.zero;
	}
}
