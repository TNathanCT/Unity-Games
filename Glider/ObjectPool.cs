using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //It's important to use the objectPool, as  it helps optimize our project. Having to constantly Instantiate and Destory gameObjects is incredibly taxing for the CPU and the GPU, and it can cause the iOS and Android to crash. 
    //So we use this. Instead of instantiating, it's simply sent back to the pool to be used at a later date.

    //First of all, we setup the pipes and the size of the pool itself. We then set the spawn rate and the how high we would like our pipes to spawn (for variety's sake)/
    public GameObject pipesPrefab;
    public GameObject coin;
    public int pipesPoolSize = Constants.poolSize;
    public float spawnRate;
    public float pipesMinimum = Constants.pipesMin;
    public float pipesMaximum = Constants.pipesMax;
    private GameObject[] pipes;
    private GameObject[] allcoins;
    private int currentPipes = 0; 
    



    private Vector3 objectPoolPosition = new Vector3(-120, -700, 0);       
    private float spawnXPosition = Constants.spawnXPos;
    private float spawnZPosition = Constants.spawnZPos;

    private float timeSinceLastSpawned;

    GliderController gcontroller;
    GameManager gManager;

    void Awake()
    {
        spawnRate = Constants.spawnPipesRateEasy;
        gcontroller = FindObjectOfType<GliderController>();
        gManager = FindObjectOfType<GameManager>();
        timeSinceLastSpawned = 0f;

       

        //Initialize the columns collection.
        pipes = new GameObject[pipesPoolSize];
        allcoins = new GameObject[pipesPoolSize];
        //Loop through the collection to create the initial pipes that will be stored in the object pool.
        for (int i = 0; i < pipesPoolSize; i++)
        {

           pipes[i] = (GameObject)Instantiate(pipesPrefab, objectPoolPosition, Quaternion.identity);
            allcoins[i] = (GameObject)Instantiate(coin, objectPoolPosition, Quaternion.identity);
        }

        
        

        StartCoroutine(UpdatePool());
    }

    private void Update()
    {
       

            if (GameManager.instance.score > 10 && GameManager.instance.score < 20)
            {
                spawnRate = Constants.spawnPipesRateMid;
            }



            else if (GameManager.instance.score > 20)
            {
                spawnRate = Constants.spawnpipesRateHard;
            }

            foreach(GameObject obj in allcoins)
            {
           
                obj.transform.Rotate(Vector3.up * 100 * Time.deltaTime);
            }
            
        
    }


    IEnumerator UpdatePool()
    {
        while (gcontroller.struckSomething == false)
        {
            if (Constants.startgame == true)
            {
                timeSinceLastSpawned += Time.deltaTime;

                if (GameManager.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
                {
                    timeSinceLastSpawned = 0f;

                    float spawnYPosition = Random.Range(pipesMinimum, pipesMaximum);
                    pipes[currentPipes].transform.position = new Vector3(spawnXPosition, spawnYPosition, spawnZPosition);
                    if(Random.value <= 0.3)
                    {
                        allcoins[currentPipes].transform.position = pipes[currentPipes].GetComponent<PipesScript>().spawnCoinTransform.position;
                     
                    }
                    else{
                        allcoins[currentPipes].transform.position = new Vector3(1100, 1100, 1100);
                    }


                    
                    currentPipes++;

                    if (currentPipes >= pipesPoolSize)
                    {
                        currentPipes = 0;
                    }
                }

                if (gcontroller.struckSomething == true)
                {
                    break;
                }
            }
            else { 
            
            }

            yield return null;
        }


        
    }

   
}
