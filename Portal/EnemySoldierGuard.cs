using UnityEngine;
using System.Collections;

public class EnemySoldierGuard : MonoBehaviour {


    //for shooting
    public Transform Player;
    private float PlayerDistance;
    public float RotationSpeed;
    public float LookDistance;
    public float ChaseDistance;
    public float StopChaseDistance;
    public static bool ThePlayerisAlive = true;
    public Rigidbody Bullet;
    public float BulletSpeed;
    public Transform Nozzle;
    public float TimeBetweenShots = 1f;
    public float TimeStamp = 1f;
    private float ShotCounter;


    //Healthithas
    public int StartHealth = 100;
    public int CurrentHealth;
    public bool isDead;


    Animator Anim;


	void Start () {
        Anim = GetComponent<Animator>();
        Anim.SetBool("CanbeSeen", false);
        Anim.SetBool("StartShooting", false);
        Anim.SetBool("isDead", false);

        CurrentHealth = StartHealth;

        ShotCounter = TimeBetweenShots;

     
	}
	
	// Update is called once per frame
	void Update () {

        if(ThePlayerisAlive)
        {
            PlayerDistance = Vector3.Distance(Player.position, transform.position);
        }

        if(PlayerDistance < ChaseDistance)
        {
            LookatPlayer();

            if(PlayerDistance > StopChaseDistance)
            {
                ShotCounter -= Time.deltaTime;
                if (ShotCounter <= 0)
                {
                    Shoot();
                    ShotCounter = TimeBetweenShots;
                }
            }
        }
 
	
	}

    void LookatPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(Player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * RotationSpeed);
        //Anim.SetBool("CanbeSeen", true);
        
    }


    void Shoot() {
        Rigidbody BulletClone = (Rigidbody)Instantiate(Bullet, Nozzle.position, Nozzle.rotation);
        BulletClone.AddForce (transform.forward * BulletSpeed);
        Anim.SetBool("StartShooting", true);

    
        
            }

    public void TakeDamage( int Amount, Vector3 hitPoint)
    {
        CurrentHealth -= Amount;

        if(CurrentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        Anim.SetTrigger("isDead");

        
    }
}
