using UnityEngine;
using System.Collections;

public class GreenScript : MonoBehaviour {

    CharacterScript player;
    public GameObject Shape;
    public GameObject Particles;

    
    void Start () {
        player = FindObjectOfType<CharacterScript>();
        Particles.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Zone" && player.PressGreen)
        {

            Particles.SetActive(true);
            Shape.transform.localScale = new Vector3(0f, 0f, 0f);
                

        }

    }
}
