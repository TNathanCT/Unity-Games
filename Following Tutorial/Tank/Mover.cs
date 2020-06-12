using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
    private Rigidbody RB;

	void Start() {
        RB = GetComponent<Rigidbody>();
		RB.velocity = transform.forward * speed;
	}
}
