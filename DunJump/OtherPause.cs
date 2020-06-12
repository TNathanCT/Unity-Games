using UnityEngine;
using System.Collections;

public class OtherPause : MonoBehaviour {

    public bool paused;
    public Canvas PauseMenu;



    // Use this for initialization
    void Start()
    {
        paused = false;
        PauseMenu.enabled = false; 
    }

    // Update is called once per frame
    public void Update()
    {

		if (Input.GetKeyDown(KeyCode.Tab))
        {
            paused = !paused;
            PauseMenu.enabled = true;
        }

		if (!paused && Input.GetKeyDown (KeyCode.Tab)) {
			PauseMenu.enabled = false;

		}

        if (paused)
        {
            Time.timeScale = 0;
        }

        if (!paused)
        {
            Time.timeScale = 1;
        }
    }

    public void pause()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0;
        }
        if (!paused)
        {
            Time.timeScale = 1;
        }
    }
}
