using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    //This collider will store the ground collider
    private BoxCollider groundCollider;

    //Just use this to get the length of the ground.
    private float groundHorizontalLength;


    private void Awake()
    {

        groundCollider = GetComponent<BoxCollider>();
        groundHorizontalLength = groundCollider.size.x;
    }


    private void Update()
    {

        if (transform.position.x < -groundHorizontalLength)
        {
            //we move it forward to be re-used. NO INSTANTIATING A NEW PREFAB!! THIS KILLS THE PERFORMANCE, ESPECIALLY FOR iOS AND ANDROID GAMES
            MoveBackground();
        }
    }


    private void MoveBackground()
    {
        //Make sure that this is double the length so that it is far behind the player when we move it(aka, off screen)
        Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);

        //Move this object from it's current to position to the new position off-camera in front of the player.
        transform.position = (Vector2)transform.position + groundOffSet;
    }
}