using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float MoveSpeed;
    public float JumpHeight;
    public Image Heart1;
    public Image Heart2;
    public Image Heart3;
    public GameObject player;

    public float Betweenhits = 2f;
    public bool EnemyAttack;




    void Start()
    {

        Heart1.enabled = true;
        Heart2.enabled = true;
        Heart3.enabled = true;



    }


    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy")
        {

            if (Heart1.enabled == true && Heart2.enabled == true && Heart3.enabled == true && EnemyAttack == true)
            {
                
                Heart3.enabled = false;
                EnemyAttack = false;

            }

            if (Heart1.enabled == true && Heart2.enabled == true && Heart3.enabled == false && EnemyAttack == true)
            {
               
                Heart2.enabled = false;
                EnemyAttack = false;
            }

            if (Heart1.enabled == true && Heart2.enabled == false && Heart3.enabled == false && EnemyAttack == true)
            {
   
                Heart1.enabled = false;
                EnemyAttack = false;
            }
        }
    }

   


    void Update()
    {
        if(EnemyAttack == false)
        {
            Betweenhits -= Time.deltaTime;
        }

        if(Betweenhits <= 0)
        {
            EnemyAttack = true;
            Betweenhits = 2;
        }



        //Move the player to the left.
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            SpinLeft();
            transform.position += Vector3.left * MoveSpeed * Time.deltaTime;


        }


        //Move the player to the right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            SpinRight();
            transform.position += Vector3.right * MoveSpeed * Time.deltaTime;


        }



        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(0f, -1f, 0f);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.Translate(0f, 1f, 0f);
        }

        if (Heart1.enabled == false && Heart2.enabled == false && Heart3.enabled == false)
        {
            Debug.Log("You lost");
        }




    }

 
    void SpinLeft()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void SpinRight()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}




