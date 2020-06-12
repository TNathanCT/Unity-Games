using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoints : MonoBehaviour
{
    GameManager gameManager;
    PlayerController playerController;

    void Start(){
        gameManager = FindObjectOfType<GameManager>();
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update(){
        if(playerController.MovedtheOars == true){
            if(Mathf.Abs(transform.position.y) > Constants.OK_HIT_POSITION){
                gameManager.currentScore += Constants.OK_SCORE;
                Destroy(this.gameObject);
            }
            else if(Mathf.Abs(transform.position.y) > Constants.GOOD_HIT_POSITION){
                gameManager.currentScore += Constants.GOOD_SCORE;
                Destroy(this.gameObject);

            }

            else if(Mathf.Abs(transform.position.y) == 0){
                gameManager.currentScore += Constants.PERFECT_SCORE;
                Destroy(this.gameObject);
            }
        }
    }
}
