using UnityEngine;
using System.Collections;

public class SetAspectRatio : MonoBehaviour {

    public float aspectRatio = 1.0f;


	void Start () {
      GetComponent<Camera>().aspect = aspectRatio;
	}
}
