using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowThePath : MonoBehaviour {

    //public Transform[] waypoints;
    public List<GameObject> waypoints = new List<GameObject>();


    [SerializeField]
    private float moveSpeed = 1f;

    [HideInInspector]
    public int waypointIndex = 0;

    public bool moveAllowed = false;


	private void Start () {

        transform.position = waypoints[waypointIndex].transform.position;
	}

	private void Update () {
        
        if (moveAllowed){
            Move();
        }
        
	}

    private void Move()
    {
        
        if (waypointIndex <= waypoints.Count - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
            
        }
        

       }

        
}

