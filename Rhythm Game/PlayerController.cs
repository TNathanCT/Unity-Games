using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public class PlayerController : MonoBehaviour {
    public List<GameObject> Oars = new List<GameObject>();

    float speed;

    public GameObject WatertouchingOars;
    public GameObject Prop;

    public bool MovedtheOars;

    MicrophoneManager microphoneManager;
    void Update() {

        microphoneManager = FindObjectOfType<MicrophoneManager>();
        StartCoroutine(MoveOars());

        
    }

    IEnumerator MoveOars(){
       
        GameObject RightOar = Oars.Where(Oar => Oar.name == "RightOar").SingleOrDefault();
        GameObject LeftOar = Oars.Where(Oar => Oar.name == "LeftOar").SingleOrDefault();
        
        //yield return new WaitForSeconds(1f);
        RightOar.transform.rotation = Quaternion.Euler(0,0, 25);
        LeftOar.transform.rotation = Quaternion.Euler(0,0, -25);
        MovedtheOars = false;
        
      if(microphoneManager.isSpeaking == true){
        //var splash = Instantiate(WatertouchingOars, new Vector3(-0.1f, 4.03888f, 0f), Quaternion.identity); 
        //splash.transform.parent = Prop.transform;
    
        RightOar.transform.rotation = Quaternion.Euler(0,0,0);
        LeftOar.transform.rotation = Quaternion.Euler(0,0,0);
        MovedtheOars = true;
        
        }

        else{
            
        }
        

        yield return null;

      

    
    }   
}
