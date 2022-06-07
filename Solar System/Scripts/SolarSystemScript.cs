using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemScript : MonoBehaviour
{
   
    readonly float G = 100;
    public List<GameObject> celestrialObjs = new List<GameObject>();
    public bool startOrbiting;

    public Vector3 initialVel;


    void Awake(){

        startOrbiting = true;
        InitialVelocity();
        StartCoroutine(GenerateGravity());
    }



    public IEnumerator GenerateGravity(){
        while(startOrbiting == true){
            Gravity();

            yield return new WaitForEndOfFrame();
            if(startOrbiting == false){
                break;
            }
        }
    }


    public void Gravity(){
        foreach (GameObject obja in celestrialObjs)
        {
            foreach (GameObject objb in celestrialObjs)
            {
                if(!obja.Equals(objb)){
                    float m1 = obja.GetComponent<Rigidbody>().mass;
                    float m2 = objb.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(obja.transform.position, objb.transform.position);

                    obja.GetComponent<Rigidbody>().AddForce((objb.transform.position - obja.transform.position).normalized * (G * (m1*m2)/(r*r)));
                }
            }
        }
    }

    void InitialVelocity(){
         foreach (GameObject obja in celestrialObjs)
        {
            foreach (GameObject objb in celestrialObjs)
            {
                if(!obja.Equals(objb)){
                    float m2 = objb.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(obja.transform.position, objb.transform.position);
                    obja.transform.LookAt(objb.transform);
                    initialVel = obja.transform.right * Mathf.Sqrt((G*m2)/r);
                    obja.GetComponent<Rigidbody>().velocity += initialVel;
                }
            }
        }
    }



}
