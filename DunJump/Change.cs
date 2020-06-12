using UnityEngine;
using System.Collections;

public class Change : MonoBehaviour {

    public bool change;

    public GameObject Glitch;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (change)
        {
            Glitch.SetActive(true);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }

        if (!change)
        {
            Glitch.SetActive(false);
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
        }

    }
}
