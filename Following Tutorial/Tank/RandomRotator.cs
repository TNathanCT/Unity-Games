using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {
	public float tumble;
    private Rigidbody RB;


	void Start() {
        RB = GetComponent<Rigidbody>();
		RB.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
