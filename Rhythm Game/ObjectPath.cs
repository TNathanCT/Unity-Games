using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPath : MonoBehaviour
{
  public List<GameObject> CrocodilesList;
  float speed = Constants.Ripple_and_Crocodile_Speed;

  CrocodileScript Crocoscript;
  Vector3 maxScale;  
  Vector3  minScale;
  float maxLocalScaleMagnitude; 
  float minLocalScaleMagnitude;
  
  GameObject pathGO;
  Transform targetPathNode;
 public int pathNodeIndex = 0;

  void Start(){
      


      pathGO = GameObject.Find("Path");
      maxScale = Constants.MAX_SCALE;
      minScale = Constants.MIN_SCALE;
      minLocalScaleMagnitude = minScale.magnitude;
      maxLocalScaleMagnitude = maxScale.magnitude;


      if(transform.childCount > 0){
            Crocoscript = GetComponentInChildren<CrocodileScript>();
            foreach(GameObject obj in CrocodilesList){
                    obj.gameObject.transform.localScale = Constants.CROCODILE_STARTING_SCALE;
            }
      }

      else{
            gameObject.transform.localScale = Constants.RIPPLE_STARTING_SCALE;
      }

  }

  void GetNextPathNode(){
      if(pathNodeIndex < pathGO.transform.childCount) {
			  targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
              pathNodeIndex++;
              
             
         


		}
		else {
			targetPathNode = null;
			ReachedGoal();
		}
  }




  void IncreaseScale(){
      float currentLocalScaleMagnitude = transform.localScale.magnitude;
      if(currentLocalScaleMagnitude < maxLocalScaleMagnitude){

          if(transform.childCount > 0){
                foreach(GameObject obj in CrocodilesList){
                    obj.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0) * (Time.deltaTime * (speed*0.7f));
                }
          }
         
         gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0) * (Time.deltaTime * (speed * 2f));
          
      }
  }


  void DecreaseScale(){
    float currentLocalScaleMagnitude = transform.localScale.magnitude;
      if(currentLocalScaleMagnitude > minLocalScaleMagnitude){
                foreach(GameObject obj in CrocodilesList){
                    obj.gameObject.transform.localScale -= new Vector3(0.1f, 0.1f, 0) * (Time.deltaTime * (speed*4));
                }  
      }
  }
 

  void Update(){

      if(transform.childCount > 0){
            if(Crocoscript.ScareThemAway == true){
                DecreaseScale();
            }
        }
        IncreaseScale();


      if(targetPathNode == null) {
			GetNextPathNode();
        }

       if(targetPathNode.name == "FinalNode"){
           ReachedGoal();
       } 
        
        
		Vector3 dir = targetPathNode.position - this.transform.localPosition;

		float distThisFrame = speed * Time.deltaTime;

		if(dir.magnitude <= distThisFrame) {
			targetPathNode = null;
		}
        else{
            transform.Translate( dir.normalized * distThisFrame, Space.World );
        }
    }


  
     void ReachedGoal(){
      
      
      
  }

}
