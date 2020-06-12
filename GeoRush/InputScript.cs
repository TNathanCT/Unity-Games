using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputScript : MonoBehaviour {

    CharacterScript player;

    public GameObject Ball;
    public Image BlueButton;
    public Image RedButton;
    public Image YellowButton;
    public Image GreenButton;
    private Animator Anim;
    public GameObject BlueParticle;
    public GameObject RedParticle;
    public GameObject YellowParticle;
    public GameObject GreenParticle;
    private Rigidbody2D rb2D;






    SpeedRunScript SpeedRun;
    public Vector3 liftDir = new Vector3(0, 1, 0);
    public float raise= 20f;

    public AudioSource ButtonSound;

    void Start () {

        SpeedRun = FindObjectOfType<SpeedRunScript>();
        rb2D = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        player = FindObjectOfType<CharacterScript>();
        BlueParticle.SetActive(false);
        RedParticle.SetActive(false);
        YellowParticle.SetActive(false);
        GreenParticle.SetActive(false);
        ButtonSound = GetComponent<AudioSource>();


        
	
	}
	
	void Update () {

        if(Ball.transform.position.y <= -3.26)
        {
            Ball.transform.position = new Vector3(transform.position.x, -3.26f, transform.position.z);

        }
        
        if (player.PressYellow)
        {
            YellowButton.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            YellowParticle.SetActive(true);
            //   Anim.SetBool("Raise", true);
            //   transform.Translate(liftDir * raise * Time.deltaTime);



        }

        if (!player.PressYellow)
        {
            YellowButton.transform.localScale = new Vector3(1f, 1f, 1f);
            YellowParticle.SetActive(false);
            //   transform.Translate(liftDir * -raise * Time.deltaTime);
    


        }

        if (player.PressRed)
        {
            RedButton.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            RedParticle.SetActive(true);
            //  Anim.SetBool("Raise", false);



        }

        if (!player.PressRed)
        {
            RedButton.transform.localScale = new Vector3(1f, 1f, 1f);
            RedParticle.SetActive(false);



        }

        if (player.PressBlue)
        {
            BlueButton.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            BlueParticle.SetActive(true);
            //   Anim.SetBool("Raise", true);



        }

        if (!player.PressBlue)
        {
            BlueButton.transform.localScale = new Vector3(1f, 1f, 1f);
            BlueParticle.SetActive(false);
            // transform.Translate(liftDir * raise * Time.deltaTime);

        }

        if (player.PressGreen)
        {
            GreenButton.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            GreenParticle.SetActive(true);
            // Anim.SetBool("Raise", false);


        }

        if (!player.PressGreen)
        {
            GreenButton.transform.localScale = new Vector3(1f, 1f, 1f);
            GreenParticle.SetActive(false);



        }

    }

    public void pressRed ()
    {

        player.PressRed = true;
        ButtonSound.enabled = true;

    }

    public void UnpressRed()
    {

        player.PressRed = false;
        ButtonSound.enabled = false;

    }

    public void pressBlue()
    {

        player.PressBlue = true;
        ButtonSound.enabled = true;

    }

    public void UnpressBlue()
    {

        player.PressBlue = false;
        ButtonSound.enabled = false;

    }

    public void pressGreen()
    {

        player.PressGreen = true;
        ButtonSound.enabled = true;

    }

    public void UnpressGreen()
    {

        player.PressGreen = false;
        ButtonSound.enabled = false;

    }

    public void pressYellow()
    {

        player.PressYellow = true;
        ButtonSound.enabled = true;

    }

    public void UnpressYellow()
    {

        player.PressYellow = false;
        ButtonSound.enabled = false;

    }
}
