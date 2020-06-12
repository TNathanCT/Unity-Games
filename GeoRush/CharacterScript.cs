using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour {

    public bool PressRed;
    public bool PressGreen;
    public bool PressYellow;
    public bool PressBlue;



    public Text ScoreText;
    public float Score;

	// Use this for initialization
	void Start () {

        ScoreText.text = "Score = 0";
	
	}
	
	// Update is called once per frame
	void Update () {

        Score += Time.deltaTime * 5f;

        ScoreText.text = "Score : " + (Mathf.Round(Score));

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            PressRed = true;

        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {

            PressRed = false;

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            PressYellow = true;

        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {

            PressYellow = false;

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            PressBlue = true;

        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {

            PressBlue = false;

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            PressGreen = true;

        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {

            PressGreen = false;

        }
    }



}
