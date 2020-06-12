using UnityEngine;
using System.Collections;

public class StopFollowCamera : MonoBehaviour {



	private CameraSmooth cam;
	public GameObject camObj;
	// Use this for initialization
	void Start () 
	{
		cam = camObj.GetComponent<CameraSmooth> ();
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		print ("blabla");
		if (other.tag == "Player") 
		{
			cam.isFollowing = false;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{

		print ("blabla2");
		if (other.tag == "Player") 
		{
			cam.isFollowing = true;
		}
	}
}
