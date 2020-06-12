using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

    public GameObject Arrow;
    public Transform LaunchPoint;

    public float WaitBetweenShots;
    private float ShotCounter;

	void Start () {
        ShotCounter = WaitBetweenShots;
	
	}

    void Update()
    {
        ShotCounter -= Time.deltaTime;

        if (ShotCounter <= 0)
        {
            Instantiate(Arrow, LaunchPoint.position, LaunchPoint.rotation);
            ShotCounter = WaitBetweenShots;
        }
    }
}
