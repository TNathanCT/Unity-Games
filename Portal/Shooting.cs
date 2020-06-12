using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    public int Damage = 50;
    public Rigidbody Bullet;
    public Transform FireTransform;
    public int BulletSpeed = 150;

    public AudioSource ShootingAudio;

    public float TimeBetweenShots = 1f;
    private float TimeStamp;

    Animator Anim;
    public bool DidIfireyet;


    public int ammo = 10;
    public int ClipSize = 10;
    public int ClipCount = 5;
         



    void Start()
    {
        ShootingAudio = GetComponent<AudioSource>();
        Anim = GetComponent<Animator>();
    }

    void Update()
    {

        DidIfireyet = false;
        Anim.SetBool("IFired", DidIfireyet);

        if (Time.time >= TimeStamp && Input.GetMouseButtonDown(0))
        {
            Fire();
            TimeStamp = Time.time + TimeBetweenShots;

        }

        if (Input.GetKeyDown(KeyCode.R)){
            Reload();
        }
    }

    void Fire()
    {
        if (ammo >= 1)
        {
            Rigidbody bulletInstance = Instantiate(Bullet, FireTransform.position, FireTransform.rotation) as Rigidbody;
            bulletInstance.velocity = BulletSpeed * FireTransform.forward;
            ShootingAudio.Play();
            DidIfireyet = true;
            ammo = ammo - 1;

            Anim.SetBool("IFired", DidIfireyet);
        }
    }

   public void Reload()
    {

        if (ClipCount <= 1)
        {
            //Set the Animation to this point. Use the CrossFade 
            ammo = ClipSize;
            ClipCount = ClipCount - 1;
        }
    }


}
