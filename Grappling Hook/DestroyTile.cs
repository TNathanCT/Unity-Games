using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTile : MonoBehaviour
{

    public GameObject platformDestructionPoint;
    
    void Start()
    {
        platformDestructionPoint = GameObject.Find("DestroyTiles");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < platformDestructionPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
