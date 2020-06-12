using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;

	//permet de savoir si la caméra suit le joueur ou non !
	public bool isFollowing;

	public float xOffset;
	public float yOffset;
	public float zOffset;

	// Use this for initialization
	void Start () 
	{
		//player = FindObjectOfType<PlayerController> ();

		isFollowing = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isFollowing) 
		{
			transform.position = new Vector3 (player.transform.position.x + xOffset, player.transform.position.y + yOffset, player.transform.position.z + zOffset);
		}
	}
}
