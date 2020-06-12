using UnityEngine;
using System.Collections;

public class RotatePage : MonoBehaviour {

    Vector3 Rotation;


	void Update () {
        Rotation += Vector3.right * 60 * Time.deltaTime;
        transform.rotation = Quaternion.Euler(Rotation);
        Rotation += Vector3.up * 80 * Time.deltaTime;
    }
}
