using UnityEngine;
using System.Collections;

public class MissileScript : MonoBehaviour {

 
    public float DestroyAfter = 2f;

	void Start () {
        Destroy(gameObject, DestroyAfter);
	
	}

}
