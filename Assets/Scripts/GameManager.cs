using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region UPDATED CODE  



    public static GameManager gm;

    
    public int startBallsAmount = 0;

    public bool canBeatLevel = false;
    public int beatLevelBallsAmount = 0;

    // public float startTime = 5.0f;
   // public float ballsSize = 1.0f;

    public Text ballsAmountDisplay;
    //public Text mainTimerDisplay;

    public GameObject gameOverScoreOutline;

    public AudioSource musicAudioSource;

    public bool gameIsOver = false;

    public Button playAgainButtons;
    public string playAgainLevelToLoad;

    public Button nextLevelButtons;
    public string nextLevelToLoad;

    private int currentBallsAmount;

    
    void Start()
    {
        //initialize 
        currentBallsAmount = startBallsAmount;
        

        
        if (gm == null)
            gm = this.gameObject.GetComponent<GameManager>();

        //amount of current quantitity of balls
        ballsAmountDisplay.text = "";

        
        if (gameOverScoreOutline)
            gameOverScoreOutline.SetActive(false);

       
        if (playAgainButtons)
            playAgainButtons.enabled = false;

        
        if (nextLevelButtons)
            nextLevelButtons.enabled = false;
    }

    
    void Update()
    {
        if (!gameIsOver)
        {
            if (canBeatLevel && (currentBallsAmount <= beatLevelBallsAmount))
            {
                Debug.Log("next level to load");
                NextLevel();
                BeatLevel();
            }
            else if (currentBallsAmount < 0)
            {
                Debug.Log("End game");
                EndGame();
            }
            else
            { 
                 currentBallsAmount -= startBallsAmount;
                ballsAmountDisplay.text = currentBallsAmount.ToString("0");
            }
        }
    }

    void EndGame()
    {
        
        gameIsOver = true;


        ballsAmountDisplay.text = "0";

        
        if (gameOverScoreOutline)
            gameOverScoreOutline.SetActive(true);

        
        if (playAgainButtons)
            playAgainButtons.enabled = true;

         
        if (musicAudioSource)
            musicAudioSource.pitch = 0.5f; // slow down the music
    }

    void BeatLevel()
    {
       
        gameIsOver = true;

        // repurpose the timer to display a message to the player
        ballsAmountDisplay.text = "Beat Level";

        // activate the gameOverScoreOutline gameObject, if it is set 
        if (gameOverScoreOutline)
            gameOverScoreOutline.SetActive(true);

        // activate the nextLevelButtons gameObject, if it is set 
        if (nextLevelButtons)
            nextLevelButtons.enabled = true;

        // reduce the pitch of the background music, if it is set 
        if (musicAudioSource)
            musicAudioSource.pitch = 0.5f; // slow down the music
    } 

   
    public void targetHit(int ballsAmount, float currentballsSize)
    {

        Debug.Log("Target hit");
        startBallsAmount += ballsAmount;
        // mainScoreDisplay.text = score.ToString();

        // increase the time by the timeAmount
        // currentTime += timeAmount;
       // currentballsSize += ballsSize;
        // don't let it go negative
        // if (currentBallsAmount < 0)
        //     currentTime = 0.0f;

        // update the text UI
        ballsAmountDisplay.text = currentBallsAmount.ToString("0");
        // mainTimerDisplay.text = currentTime.ToString("0");
    }


    public void RestartGame()
    {

        SceneManager.LoadScene(playAgainLevelToLoad);
    }


    public void NextLevel()
    {
         
        SceneManager.LoadScene(nextLevelToLoad);
    }


    #endregion


    #region OLD CODE
    /*
    // make game manager public static so can access this from other scripts
    public static GameManager gm;

    // public variables
    public int score = 0;

    public bool canBeatLevel = false;
    public int beatLevelScore = 0;

    public float startTime = 5.0f;


    public Text mainScoreDisplay;
    public Text mainTimerDisplay;

    public GameObject gameOverScoreOutline;

    public AudioSource musicAudioSource;

    public bool gameIsOver = false;

    public GameObject playAgainButtons;
    public string playAgainLevelToLoad;

    public GameObject nextLevelButtons;
    public string nextLevelToLoad;

    private float currentTime;

    // setup the game
    void Start()
    {

        // set the current time to the startTime specified
        currentTime = startTime;

        // get a reference to the GameManager component for use by other scripts
        if (gm == null)
            gm = this.gameObject.GetComponent<GameManager>();

        // init scoreboard to 0
        mainScoreDisplay.text = "0";

        // inactivate the gameOverScoreOutline gameObject, if it is set
        if (gameOverScoreOutline)
            gameOverScoreOutline.SetActive(false);

        // inactivate the playAgainButtons gameObject, if it is set
        if (playAgainButtons)
            playAgainButtons.SetActive(false);

        // inactivate the nextLevelButtons gameObject, if it is set
        if (nextLevelButtons)
            nextLevelButtons.SetActive(false);
    }

    // this is the main game event loop
    void Update()
    {
        if (!gameIsOver)
        {
            if (canBeatLevel && (score >= beatLevelScore))
            {  // check to see if beat game
                BeatLevel();
            }
            else if (currentTime < 0)
            { // check to see if timer has run out
                EndGame();
            }
            else
            { // game playing state, so update the timer
                currentTime -= Time.deltaTime;
                mainTimerDisplay.text = currentTime.ToString("0.00");
            }
        }
    }

    void EndGame()
    {
        // game is over
        gameIsOver = true;

        // repurpose the timer to display a message to the player
        mainTimerDisplay.text = "GAME OVER";

        // activate the gameOverScoreOutline gameObject, if it is set 
        if (gameOverScoreOutline)
            gameOverScoreOutline.SetActive(true);

        // activate the playAgainButtons gameObject, if it is set 
        if (playAgainButtons)
            playAgainButtons.SetActive(true);

        // reduce the pitch of the background music, if it is set 
        if (musicAudioSource)
            musicAudioSource.pitch = 0.5f; // slow down the music
    }

    void BeatLevel()
    {
        // game is over
        gameIsOver = true;

        // repurpose the timer to display a message to the player
        mainTimerDisplay.text = "LEVEL COMPLETE";

        // activate the gameOverScoreOutline gameObject, if it is set 
        if (gameOverScoreOutline)
            gameOverScoreOutline.SetActive(true);

        // activate the nextLevelButtons gameObject, if it is set 
        if (nextLevelButtons)
            nextLevelButtons.SetActive(true);

        // reduce the pitch of the background music, if it is set 
        if (musicAudioSource)
            musicAudioSource.pitch = 0.5f; // slow down the music
    }

    // public function that can be called to update the score or time
    public void targetHit(int scoreAmount, float timeAmount)
    {
        // increase the score by the scoreAmount and update the text UI
        score += scoreAmount;
        //mainScoreDisplay.text = score.ToString();

        // increase the time by the timeAmount
        currentTime += timeAmount;

        // don't let it go negative
        if (currentTime < 0)
            currentTime = 0.0f;

        // update the text UI
       // mainTimerDisplay.text = currentTime.ToString("0.00");
    }

   
    public void RestartGame()
    {
        
        SceneManager.LoadScene(playAgainLevelToLoad);
    }

    
    public void NextLevel()
    {
        // 
        SceneManager.LoadScene(nextLevelToLoad);
    } */

    #endregion
}
