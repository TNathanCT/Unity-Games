using UnityEngine;
using System.Collections;

public class ForthePickups : MonoBehaviour {
    

	void OnCollisionEnter (Collision other) {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
	
	}
}
