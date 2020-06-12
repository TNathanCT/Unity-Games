using UnityEngine;
using System.Collections;

public class CheckGround : MonoBehaviour
{

    public bool onGround;


    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            onGround = true;
            Debug.Log("Stay");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            onGround = false;
            Debug.Log("Exit");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "Ground")
        {
            onGround = true;
            Debug.Log("Enter");
        }
    }
}
