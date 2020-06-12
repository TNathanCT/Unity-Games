using UnityEngine;
using System.Collections;

public class Pausing : MonoBehaviour {

    public GameObject PauseImage;
    public bool paused;

	void Start () {
        PauseImage.SetActive(false);
        paused = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            paused = true;
            PauseImage.SetActive(true);
        }
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = false;
			PauseImage.SetActive (false);
        }
	}


    void Pause()
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
