using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThomasThrowsPokeball : MonoBehaviour
{
    public Transform handStart;
    public GameObject pokeballPrefab;
    Animator pokeballAnim;
    public float throwForce;


   public void SpawnPokeball()
    {
        GameObject obj = Instantiate(pokeballPrefab, handStart.transform.position, Quaternion.identity);

        pokeballAnim = obj.GetComponentInChildren<Animator>();
        pokeballAnim.SetBool("Toss", true);
        obj.GetComponentInChildren<Rigidbody2D>().velocity = (new Vector2(transform.localScale.x, 1) * throwForce);


    }

 

}
