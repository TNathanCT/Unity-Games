using UnityEngine;
using System.Collections;

public class changeRightBounds : MonoBehaviour {

	//Ce script permet de changer les limites de la caméra à un moment donné au début du niveau
	
	[SerializeField]
	Camera camera;

	private camera_follow scriptCamera;

	void Start()
	{
		scriptCamera = camera.GetComponent<camera_follow>();
	}

	void OnTriggerEnter2D()
	{
		scriptCamera.maxBound = new Vector3(194.5f,scriptCamera.maxBound.y,scriptCamera.maxBound.z);
		Destroy(this.gameObject);
	}
}
