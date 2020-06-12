using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //This is a reference to this script so that we can access it statically.
    public static GameManager instance;          

    //This will be used to show the player's score
    public Text scoreText;
    public Text highScore;
    //This will appear when player dies
    public GameObject gameOvertext;               


    //this will set the score, check whether we died or not, and the speed at which the background and ground move at.
    public int score;
    public int coins;
    
    public bool gameOver = false;               

    public GameObject instructionsText;
    public GameObject pauseMenu;
    public GameObject deathMenu;
    public Text deathUIText;

    GliderController gliderController;
    BackgroundMovement backgroundMovement;
    int frameRate = 60;
    CurrencyManager currencyM;

    public GameObject bannerAd;
   


    void Awake()
    {

        Application.targetFrameRate = frameRate;
        QualitySettings.vSyncCount = 0;

        bannerAd.SetActive(false);

        gliderController = FindObjectOfType<GliderController>();
        currencyM = GetComponent<CurrencyManager>();
        pauseMenu.SetActive(false);
        deathMenu.SetActive(false);

 
        score = Constants.startingScore;
        highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();

       

        if (instance == null)
        {
            instance = this;
        }


        else if (instance != this)
        {
            Destroy(gameObject);
        }

        scoreText.text = "Score: " + score.ToString();
        StartCoroutine(StartGame());

    }

   
    public void Score()
    {
        if (gameOver)
        {
            return;
        }

        score++;
        scoreText.text = "Score: " + score.ToString();

        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = "Highscore: " + score.ToString();
        }
    }

    public IEnumerator PlayerDied()
    {
        gameOvertext.SetActive(true);
        gameOver = true;
        // Instantiate(menuCanvas, new Vector3(0, 0, 0), Quaternion.identity);
        deathMenu.SetActive(true);

        deathUIText.text = "Score: " + score.ToString() + '$' + "Coins: " + currencyM.collectedduringRun;
        deathUIText.text = deathUIText.text.Replace('$', '\n');

        while (gameOver == true)
        {
          
            if (gameOver && Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            }

            yield return null;
        }
    }

    public IEnumerator StartGame()
    {
       
        while (Constants.startgame == false)
        {
            if (Constants.startgame == false && Input.GetMouseButtonDown(0))
            {

                Constants.startgame = true;
                StartCoroutine(gliderController.GliderUpdate());
                


            }
            yield return null;
        }
       
    }

    public void PauseGame()
    {
        if(Time.timeScale == 1 && Constants.startgame == true)
        {
            bannerAd.SetActive(false);
            pauseMenu.SetActive(true);
            Time.timeScale = 0;

        }
        else 
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOver = false;

    }

    private void Update()
    {
        if (frameRate != Application.targetFrameRate)
        {
            Application.targetFrameRate = frameRate;
        }
      
    }

}

