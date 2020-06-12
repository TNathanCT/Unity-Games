using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GliderController : MonoBehaviour
{
    //This will push the glider up
    public float upForce;

    //this will be used to check whether or not the player had collided with something (died)
    public bool struckSomething = false;    
 
    
    //The local rigidbody
    Rigidbody rb;

    AudioSource audio;

    CurrencyManager currencyManager;

    public List<GameObject> allCharacters = new List<GameObject>(); 

    int index;

    //We want everything to be prepared as soon as the project loads.
    void Awake()
    {
        index = PlayerPrefs.GetInt("equipped");

        for (int i = 0; i < allCharacters.Count; i++)
        {
            if(i == index)
            {
                allCharacters[i].SetActive(true);
            }
            else
            {
                Destroy(allCharacters[i]);
            }

        }

        upForce = Constants.pushGliderUp;
        rb = GetComponent<Rigidbody>();

        audio = GetComponent<AudioSource>();

       
        currencyManager = FindObjectOfType<CurrencyManager>();

       
       

    }

    public IEnumerator GliderUpdate()
     {

        Destroy(GameManager.instance.instructionsText);
        rb.useGravity = true;


         //First of all, we want to check whether or not the glider is flying.
         while (struckSomething == false)
         {
             //If it hasn't, then give the player the ability to play when they press on the screen
             //The advantage of GetMouseButton is that it also transitions to a tap on the screen when using the iOS or Android.
             if (Input.GetMouseButtonDown(0))
             {
                //Play the animation, set it's velocity to zero and then add a force that pushes the glider skyward.
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, upForce));



            }

            if (this.transform.position.y <= -4.5f)
            {
                struckSomething = true;
            }

            if (struckSomething == true)
            {
                StartCoroutine(GameManager.instance.PlayerDied());
                break;
            }
            
            yield return null;
        }


    }

  
    

    //We use OnCollisionEnter when bump into something.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pipes")
        {
            rb.velocity = Vector2.zero;
            struckSomething = true; 
            StartCoroutine(GameManager.instance.PlayerDied());
            audio.Play();
        }

        if(other.gameObject.tag == "Coin")
        {
            currencyManager.CollectCoin();
            other.gameObject.transform.position = new Vector3(1100, 1100, 1100);

        }

        
    }
}