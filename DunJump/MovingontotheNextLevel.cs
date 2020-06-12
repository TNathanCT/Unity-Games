using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MovingontotheNextLevel : MonoBehaviour {

    private bool PlayerinthePortal;
    public string LeveltoLoad;


    void Start(){
        PlayerinthePortal = false;
    }


    void Update()
    {
        if (PlayerinthePortal)
        {
            SceneManager.LoadScene(LeveltoLoad);
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "Player")
        {
            PlayerinthePortal = true;
        }
    }
     


}
