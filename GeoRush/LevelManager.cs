using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

 

	public void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit)){
            if (hit.transform.name == "Blue")
            {
                SceneManager.LoadScene("GameJam");
            }

            if (hit.transform.name == "Red")
            {
                Application.Quit();
            }

            if (hit.transform.name == "Arrow")
            {
                SceneManager.LoadScene("Main Menu");
            }

            if (hit.transform.name == "Green")
            {
                SceneManager.LoadScene("References");
            }

            if (hit.transform.name == "Yellow")
            {
                SceneManager.LoadScene("Developers");
            }

        }

        
	}
}
