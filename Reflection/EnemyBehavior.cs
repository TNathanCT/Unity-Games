using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

	public Transform PlayerPosition;

	public float PlayerDistance;
	public float rotationDampling;
	public float movespeed;
	public float lookdistance;
	public float chasedistance;
	public float stopchasedistance;

	public Transform SpawnPoint;

	public Rigidbody Bullet;
	public Transform FiringPosition;
	public float bulletspeed;
	bool Startfiring;
	public float TimeBetweenShots;
	float TimeCounter;





	void Start () {
		this.transform.position = SpawnPoint.transform.position;
		Startfiring = false;
	}

	void Update () {
		PlayerDistance = Vector3.Distance (PlayerPosition.position, transform.position);

		if (PlayerDistance < lookdistance) {
			LookAtPlayer ();
			TimeCounter -= Time.deltaTime;
			Startfiring = true;
		

		}

		if (PlayerDistance < chasedistance) {
			ChasePlayer ();
			Startfiring = false;
			
		}



		if (Startfiring == true && TimeCounter <= 0) {
			Fire ();
			TimeCounter = TimeBetweenShots;
		
		} else {
		}
	}





	void LookAtPlayer(){
		Quaternion rotation = Quaternion.LookRotation (PlayerPosition.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDampling);
	}

	void ChasePlayer(){
		transform.Translate (Vector3.forward * movespeed * Time.deltaTime);
	}
    
	void Fire(){
		Rigidbody SummontheBullet = Instantiate (Bullet, FiringPosition.position, FiringPosition.rotation) as Rigidbody;
		SummontheBullet.velocity = (bulletspeed * FiringPosition.forward);



	}


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet") {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
