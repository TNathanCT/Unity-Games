using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovetotheNextScene : MonoBehaviour {

    private bool PlayertouchingSprite;
    public string LeveltoLoad;

	void Start () {
        PlayertouchingSprite = false;
	}
	
	void Update () {

        if (PlayertouchingSprite)
        {
            SceneManager.LoadScene(LeveltoLoad);
        }
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayertouchingSprite = true;
        }
    }
}
