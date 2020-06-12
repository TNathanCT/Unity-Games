
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charged : MonoBehaviour {

    public float rotatespeed;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        Quaternion turnRotation = Quaternion.Euler(0f, 0f, rotatespeed);
        rb.MoveRotation(rb.rotation * turnRotation);

    }

}
