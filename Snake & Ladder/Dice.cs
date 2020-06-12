using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour
{
    //This stores the amount of sides of the dice. We will rotate through them.
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private bool coroutineAllowed = true;

    //We set up a state in order to separate the times when the player can play and when they can't
    public enum WhoseTurn { PLAYER, AI};

    //Used for the event system.
    public WhoseTurn turn;

    private void Start()
    {
        //We want the player to start.
        turn = WhoseTurn.PLAYER;
        rend = GetComponent<SpriteRenderer>();
        //Where can we find the dice sprites?
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
    }

    private void OnMouseDown()
    {
        //Make sure that the player can only roll on their turn.
        if (turn != WhoseTurn.PLAYER)
        {
            return;
        }


        else if (turn == WhoseTurn.PLAYER)
        {
            if (!GameControl.gameOver && coroutineAllowed)
                StartCoroutine("RollTheDice");
                
      


        }
    }

    private void Update()
    {
        if(turn == WhoseTurn.AI)
        {
            AITurn();
        }
        
        Debug.Log(turn);
    }

    //Set up the AI for it's turn
    private void AITurn()
    {
        if(turn == WhoseTurn.AI)
        {
            if (!GameControl.gameOver && coroutineAllowed)
                StartCoroutine("RollTheDice");
               
   
      
        }
    }



    //Use a coroutine for the gameplay.
    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            //roll the dice twenty times and reveal a random side of the dice, while playing and audio.
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.01f);
            GetComponent<AudioSource>().Play();
        }

        GameControl.diceSideThrown = randomDiceSide + 1;


        //This will setup the turns after throwing. If it's not 6, change the turn, if it is 6, play again
        if (randomDiceSide == 5)
        {
            if (turn == WhoseTurn.PLAYER)
            {
                GameControl.MovePlayer(1);
                yield return new WaitForSeconds(3.5f);
                turn = WhoseTurn.PLAYER;
            }


            else if (turn == WhoseTurn.AI)
            {
                GameControl.MovePlayer(2);
                yield return new WaitForSeconds(3.5f);
                turn = WhoseTurn.AI;
            }
            coroutineAllowed = true;
        }
        else
        {
            if (turn == WhoseTurn.PLAYER)
            {
                GameControl.MovePlayer(1); 
                yield return new WaitForSeconds(3.5f);
                turn = WhoseTurn.AI;


            }
            else if (turn == WhoseTurn.AI)
            {
                GameControl.MovePlayer(2);
                yield return new WaitForSeconds(3.5f);
                turn = WhoseTurn.PLAYER;
            }

        }
           
        coroutineAllowed = true;

    }
}
