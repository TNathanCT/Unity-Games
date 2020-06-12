using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookwithMouse : MonoBehaviour {

	public enum RotationAxes { MouseXandY = 0, MouseX = 1, MouseY = 2}
	public RotationAxes axes = RotationAxes.MouseXandY;
	public float sensitivityX = 15f;
	public float sensitivityY = 15f;

	public float minimumX = -60f;
	public float maximumX = 60f;

	public float minimumY = -60f;
	public float maximumY = 60f;

	float rotationY = 0f;

	void Update () {
		if (axes == RotationAxes.MouseXandY) {
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
				rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

				transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}


		else if(axes == RotationAxes.MouseX){
			transform.Rotate (0, Input.GetAxis ("Mouse X") * sensitivityX, 0);

		}					

		else{
					rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
					rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
					transform.localEulerAngles = new Vector3 (-rotationY, transform.localEulerAngles.y , 0);
		}


	}


	void Start(){
		if (GetComponent<Rigidbody> ())
			GetComponent<Rigidbody> ().freezeRotation = true;
	
	
	}
}
