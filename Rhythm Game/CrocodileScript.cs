using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrocodileScript : MonoBehaviour
{

    public bool ScareThemAway;
    
    public float speed = Constants.Ripple_and_Crocodile_Speed;
    public Transform target;

    ObjectPath objPath;
    
    AudioSource audioSource;
    MicrophoneManager microphoneManager;
 


    void Awake(){
        microphoneManager = FindObjectOfType<MicrophoneManager>();
        audioSource = GetComponent<AudioSource>();
        objPath = GetComponentInParent<ObjectPath>();
        ScareThemAway = false;
    }
    public void CrocodilesRunAway()
    {
        float step = (speed * 3f)* Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);


        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            Destroy(transform.parent.gameObject);    
        }
    }
    
    public IEnumerator GameOver(){
      audioSource.Play();
      yield return new WaitWhile(()=> audioSource.isPlaying);
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);



    }




    void Update(){
        if(ScareThemAway == true){
             CrocodilesRunAway();
      
        }

      if(microphoneManager.isSpeaking == true  && objPath.pathNodeIndex > 3 && objPath.pathNodeIndex < 5){
        
        ScareThemAway = true;
      }

      if(ScareThemAway == false && this.gameObject.transform.position.y <= 1 && this.gameObject.transform.position.y > 0){
        
        StartCoroutine(GameOver());
      }

      if(this.gameObject.transform.position.y <= -1){
         this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, -5f, gameObject.transform.position.z);
      }



    }
}
