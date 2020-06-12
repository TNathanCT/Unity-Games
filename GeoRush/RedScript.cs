﻿using UnityEngine;
using System.Collections;

public class RedScript : MonoBehaviour {

    CharacterScript player;
    public GameObject Shape;
    public GameObject Particles;

    void Start () {
        player = FindObjectOfType<CharacterScript>();
        Particles.SetActive(false);
    }
	
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Zone" && player.PressRed)
        {

            Particles.SetActive(true);
            Shape.transform.localScale = new Vector3(0f, 0f, 0f);

        }

    }
}
