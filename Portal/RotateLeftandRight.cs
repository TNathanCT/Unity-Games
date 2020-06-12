using UnityEngine;
using System.Collections;

public class RotateLeftandRight : MonoBehaviour
{

    public int RotationSpeed = 1;
    public int MaxRotationAngle = 60;
    public float angle = 0;

    private Quaternion InitialRotation;

    void Start()
    {
        InitialRotation = transform.rotation;
        transform.RotateAround(Vector3.up, Mathf.Deg2Rad * MaxRotationAngle/2);
        StartCoroutine("RotateLeft");
    }


    IEnumerator RotateLeft()
    {
        while (angle < Mathf.Deg2Rad *MaxRotationAngle)
        {
            transform.RotateAround(Vector3.up, Mathf.Deg2Rad*RotationSpeed * Time.deltaTime);
            angle += Mathf.Deg2Rad * RotationSpeed * Time.deltaTime;
            yield return null;

        }
        StartCoroutine("RotateRight");
    }

    IEnumerator RotateRight()
    {
        while (angle > -Mathf.Deg2Rad * MaxRotationAngle * 2)
        {
            transform.RotateAround(Vector3.up, -Mathf.Deg2Rad *RotationSpeed * Time.deltaTime);
            angle -= Mathf.Deg2Rad * RotationSpeed * Time.deltaTime;
            yield return null;

        }
        StartCoroutine("RotateLeft");
    }

}

        
    
