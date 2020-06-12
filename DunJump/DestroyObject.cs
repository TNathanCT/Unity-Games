using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

    public float Timer;

	void Start () {
        Destroy(gameObject, Timer);
	
	}

    
}
