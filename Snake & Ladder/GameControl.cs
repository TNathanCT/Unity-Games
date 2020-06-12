using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class GameControl : MonoBehaviour {


    private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText;

    //our players. One for the player. The other for the AI.
    private static GameObject player1, player2;

    public static int nofPlayers;

   
    public static int diceSideThrown = 0;
    //Set up the Waypoints
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;


    public static bool gameOver = false;

    public UnityEvent winTextAppear;

    Dice diceScript;

    // Use this for initialization
    void Awake () {

        //Here we just setup the game and the variables. 
        //The GameObject.Find("") isn't the most optimized solution, but I chose to use it to show that I know that it exists.

        diceSideThrown = 0;
        player1StartWaypoint = 0;
        player2StartWaypoint = 0;
        player2StartWaypoint = 0;
        gameOver = false;

        diceScript = Object.FindObjectOfType<Dice>();

        whoWinsTextShadow = GameObject.Find("WhoWinsText");
        player1MoveText = GameObject.Find("P1Move");
        player2MoveText = GameObject.Find("P2Move");


        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        

        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;


        whoWinsTextShadow.gameObject.SetActive(false);
        player1MoveText.gameObject.SetActive(true);
        player2MoveText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        if(diceScript.turn == Dice.WhoseTurn.PLAYER)
        {
            player1MoveText.gameObject.SetActive(true);
            player2MoveText.gameObject.SetActive(false);

        }else if(diceScript.turn == Dice.WhoseTurn.AI)
        {
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(true);

        }
      
        //This will check if we land on a different a waypoint that has the ladder or the snake.
        //Using an event is possible here too, if you prefer it.
        if (player2.GetComponent<FollowThePath>().waypointIndex >
            player2StartWaypoint + diceSideThrown)
        {
            if(player2StartWaypoint+diceSideThrown == 2){
                player2.GetComponent<FollowThePath>().transform.position = player2.GetComponent<FollowThePath>().waypoints[8].transform.position;
                player2.GetComponent<FollowThePath>().waypointIndex = 8;
                player2.GetComponent<FollowThePath>().waypointIndex +=1;
                MovePlayer(2);
            }
            if(player2StartWaypoint+diceSideThrown == 14){
                player2.GetComponent<FollowThePath>().transform.position = player2.GetComponent<FollowThePath>().waypoints[20].transform.position;
                player2.GetComponent<FollowThePath>().waypointIndex = 20;
                player2.GetComponent<FollowThePath>().waypointIndex +=1;
                MovePlayer(2);
            }
            if(player2StartWaypoint+diceSideThrown == 13){
                player2.GetComponent<FollowThePath>().transform.position = player2.GetComponent<FollowThePath>().waypoints[0].transform.position;
                player2.GetComponent<FollowThePath>().waypointIndex = 0;
                player2.GetComponent<FollowThePath>().waypointIndex +=1;
                MovePlayer(2);
            
            }

            if (player2StartWaypoint + diceSideThrown == 26)
            {
                player2.GetComponent<FollowThePath>().transform.position = player2.GetComponent<FollowThePath>().waypoints[12].transform.position;
                player2.GetComponent<FollowThePath>().waypointIndex = 12;
                player2.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(2);

            }
            player2.GetComponent<FollowThePath>().moveAllowed = false;            
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
        }



        //Same, but for the other player
        if (player1.GetComponent<FollowThePath>().waypointIndex > 
            player1StartWaypoint + diceSideThrown)
        {
            if (player1StartWaypoint + diceSideThrown == 2)
            {
                player1.GetComponent<FollowThePath>().transform.position = player1.GetComponent<FollowThePath>().waypoints[8].transform.position;
                player1.GetComponent<FollowThePath>().waypointIndex = 8;
                player1.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(1);
            }
            if (player1StartWaypoint + diceSideThrown == 14)
            {
                player1.GetComponent<FollowThePath>().transform.position = player1.GetComponent<FollowThePath>().waypoints[20].transform.position;
                player1.GetComponent<FollowThePath>().waypointIndex = 20;
                player1.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(1);
            }
            if (player1StartWaypoint + diceSideThrown == 13)
            {
                player1.GetComponent<FollowThePath>().transform.position = player1.GetComponent<FollowThePath>().waypoints[0].transform.position;
                player1.GetComponent<FollowThePath>().waypointIndex = 0;
                player1.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(1);

            }

            if (player1StartWaypoint + diceSideThrown == 26)
            {
                player1.GetComponent<FollowThePath>().transform.position = player1.GetComponent<FollowThePath>().waypoints[12].transform.position;
                player1.GetComponent<FollowThePath>().waypointIndex = 12;
                player1.GetComponent<FollowThePath>().waypointIndex += 1;
                MovePlayer(1);

            }


            player1.GetComponent<FollowThePath>().moveAllowed = false;            
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;
        }


        //This was what I originally intended to use to check if we landed on the identified waypoints. But ultimately I changed my mind and didn't use it.
        //I'm leaving it here to show you that I know it exists and I know how to use it.
        winTextAppear.Invoke();



        if (player1.GetComponent<FollowThePath>().waypointIndex == 
            player1.GetComponent<FollowThePath>().waypoints.Count)
        {

            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "You win!";
            gameOver = true;

        }

        if (player2.GetComponent<FollowThePath>().waypointIndex ==
            player2.GetComponent<FollowThePath>().waypoints.Count)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Game Over, you lose!";
            gameOver = true;
        }
      
    }

    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove) { 
            case 1:
                player1.GetComponent<FollowThePath>().moveAllowed = true;
                break;

            case 2:
                player2.GetComponent<FollowThePath>().moveAllowed = true;
                break;
        }
    }



}
