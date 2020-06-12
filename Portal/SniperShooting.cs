using UnityEngine;
using System.Collections;

public class SniperShooting : MonoBehaviour {

    public float AimFOV = 20;
    public float regFOV = 60;

    public Camera MainCamera;
    public Canvas Reticle;
    public Canvas SniperZoom;

    void Awake()
    {
        Aim(false);
    }

    public void Aim(bool isIn)
    {
        if (isIn)
        {
            MainCamera.fieldOfView = AimFOV;
        }
        else
        {
            MainCamera.fieldOfView = regFOV;
        } 
        

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Aim(true);
            Reticle.GetComponent<Canvas>().enabled = false;
            SniperZoom.GetComponent<Canvas>().enabled = true;

        }

        if (Input.GetMouseButtonUp(1))
        {
            Aim(false);
            Reticle.GetComponent<Canvas>().enabled = true;
            SniperZoom.GetComponent<Canvas>().enabled = false;
        }
    }

  
}
