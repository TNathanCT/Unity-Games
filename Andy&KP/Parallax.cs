using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	public Transform[] backgrounds;
	private float[] parralaxScales;
	public float smoothing;

	private Vector3 previousCameraPosition;

	// Use this for initialization
	void Start () 
	{
		previousCameraPosition = transform.position;
		parralaxScales = new float[backgrounds.Length];
		for (int i = 0; i < parralaxScales.Length; i++) 
		{
			parralaxScales [i] = backgrounds [i].position.z * -1;
		}
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		for (int i = 0; i < backgrounds.Length; i++) 
		{
			Vector3 parallax = (previousCameraPosition - transform.position) * (parralaxScales [i] / smoothing); //How much movement we need base in our parallaxScales

			backgrounds [i].position = new Vector3 (backgrounds [i].position.x + parallax.x, backgrounds [i].position.y + parallax.y, backgrounds [i].position.z);

		}

		previousCameraPosition = transform.position;
	}
}
