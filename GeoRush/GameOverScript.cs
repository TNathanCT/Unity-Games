using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

    private bool GameOver;
    public  bool isdead;
    SpeedRunScript SRS;
    public float Timer;

    void Start () {
        isdead = false;
        GameOver = false;
        SRS = FindObjectOfType<SpeedRunScript>();
        Timer = 1;
	
	}
	
	// Update is called once per frame
	void Update () {

        if (GameOver)
        {
            SRS.direction = new Vector3(-1, 0, 0);
            Timer -= Time.deltaTime;
        }

        if (Timer <= 0)
        {
            GameOver = false;
            Timer = 1;
            SRS.direction = new Vector3(1, 0, 0);

        }
	
	}

    void OnCollisionEnter2D (Collision2D coll)
    {

        if (coll.gameObject.tag == "RedEnnemi" || coll.gameObject.tag == "YellowEnnemi" || coll.gameObject.tag == "BlueEnnemi" || coll.gameObject.tag == "GreenEnnemi")
        {
            GameOver = true;

        }

    }


}
