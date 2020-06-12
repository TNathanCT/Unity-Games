using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NathanTrainerScript : MonoBehaviour
{
    BattleSystem battleManager;
    public float speed;
    public bool setupAI = false;

    public SpriteRenderer spriteRend;

    [SerializeField]
    Color[] myColors;
    float lerpTime = 5f;

    int colorIndex = 0;
    bool characterfadeIn = false;
    bool inposition = false;

    Coroutine co;
 

    void Start()
    {
        battleManager = Object.FindObjectOfType<BattleSystem>();

        spriteRend = GetComponentInChildren<SpriteRenderer>();

        this.transform.position = GameObject.Find("nNode1").transform.position;
        spriteRend.material.color = myColors[0];

        StartCoroutine("FadetoColor");

        
        co = StartCoroutine(MoveAIPlayer());

        battleManager.dialogueText.text = "Nathan wants to battle!";





    }


    IEnumerator FadetoColor()
    {

        yield return new WaitForSeconds(2f);
        characterfadeIn = true;
        StartCoroutine(battleManager.GetComponent<BattleSystem>().SetupBattle());
       
    }


    void Update()
    {
        if (characterfadeIn == true)
        {
            spriteRend.material.color = Color.Lerp(spriteRend.material.color, myColors[colorIndex], lerpTime * Time.deltaTime);
            colorIndex++;
            if (colorIndex > 1)
            {
                colorIndex = 1;
            }
        }

        if(this.transform.position.x > 5.85f)
        {
            //StopCoroutine(co);
            battleManager.moveNathanaside = true;
        }


    }

    private IEnumerator MoveAIPlayer()
    {
        while (battleManager.moveNathanaside == false && Vector2.Distance(battleManager.enemyTrainerPrefab.transform.position, battleManager.enemyBattleStation.transform.position) > speed * Time.deltaTime)
        {

            battleManager.enemyTrainerPrefab.transform.position = Vector2.MoveTowards(battleManager.enemyTrainerPrefab.transform.position, battleManager.enemyBattleStation.transform.position, speed * Time.deltaTime);

            yield return 0;
        }


        
    }

}


