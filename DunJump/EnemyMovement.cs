using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public float moveSpeed;
    public Transform[] PatrolPoints;
    private int CurrentPoint;
    Vector3 Rotation;

	void Start () {
        transform.position = PatrolPoints[0].position;
        CurrentPoint = 0;
	}
	
	
	void Update () {

        Rotation += Vector3.forward * 120 * Time.deltaTime;
        transform.rotation = Quaternion.Euler(Rotation);

        if (CurrentPoint >= PatrolPoints.Length)
        {
            CurrentPoint = 0;
        }

        if (transform.position == PatrolPoints[CurrentPoint].position)
        {
            CurrentPoint++;
        }

        transform.position = Vector3.MoveTowards(transform.position, PatrolPoints[CurrentPoint].position, moveSpeed * Time.deltaTime);
	
	}
}
