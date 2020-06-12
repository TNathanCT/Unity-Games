using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{

    Rigidbody rb;
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
        StartCoroutine(StartScrolling());
    
    }


    public IEnumerator StartScrolling()
    {
        while( gameManager.gameOver == false)
        {
                //Start the object moving. I use Vector 2, because we don't need the Vector3.
                rb.velocity = new Vector2(Constants.backgroundMovement, 0);
              
                yield return null;
        }

    }



    void Update()
    {
        // If the game is over, stop scrolling.
        if (GameManager.instance.gameOver == true)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
