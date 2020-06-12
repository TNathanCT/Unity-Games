using UnityEngine;
using System.Collections;

public class RotateSniper2 : MonoBehaviour {


    Vector3 rotationEuler;

    void Update()
    {
        rotationEuler += Vector3.forward * 40 * Time.deltaTime; //increment 30 degrees every second
        transform.rotation = Quaternion.Euler(rotationEuler);
    }
}
