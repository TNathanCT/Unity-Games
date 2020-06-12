using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour
{

    public GameObject thePlatform;
    public Transform generatefromPoint;
    public float distanceBetween;
    float platformWidth;


    float distanceBetweenMin = 1f;
    float distanceBetweenMax = 20f;



    Rigidbody2D rb2D;
    public int movespeed;


    void Start()
    {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        rb2D = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        rb2D.velocity = new Vector2(movespeed, rb2D.velocity.y);

        if(transform.position.x < generatefromPoint.position.x)
        {

            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
            Instantiate(thePlatform, transform.position, transform.rotation);
     

        }        
    }
}
