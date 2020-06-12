using UnityEngine;
using System.Collections;

public class CameraSmooth : MonoBehaviour {

	public bool isFollowing;
	public Transform target;
	private Vector3 velocity = Vector3.zero;
	private float dampTime = 0.20f;
	public Camera camera;

	// Use this for initialization
	void Start () 
	{
		isFollowing = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (isFollowing) 
		{
			Vector3 point = camera.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
	}
}
