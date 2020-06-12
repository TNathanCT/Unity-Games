using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    //In order to keep changing the variables simple, I created this script that will store all the ints  and floats that can be changed, so that we may be able to easily change them when testing our project

    public static int startingScore = 0;
    public static float pushGliderUp = 250;
    public static int poolSize = 5;
    public static float spawnPipesRateEasy = 2;
    public static float spawnPipesRateMid = 1f;
    public static float spawnpipesRateHard = 0.5f;
    public static float pipesMin = -2.36f;
    public static float pipesMax = 2.63f;
    public static float spawnXPos = 15f;
    public static float spawnZPos = 0f;
    public static float backgroundMovement = -3f;
    public static int currencyInRun = 0;
    public static int defaultCharacter = 1;

    public static bool startgame = false;
    public static bool inMarket = false;


}
