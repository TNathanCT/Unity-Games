using UnityEngine;
using System.Collections;

public class MeteorScript : MonoBehaviour {

    Rigidbody2D rb2D;

	// Use this for initialization
	void Start () {

        rb2D = GetComponent<Rigidbody2D>();

        rb2D.gravityScale = 0f;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D (Collider2D coll)
    {

        if (coll.gameObject.tag == "Fall")
        {

            rb2D.gravityScale = 3f;

        }

    }
}
