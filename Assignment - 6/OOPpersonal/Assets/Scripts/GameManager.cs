using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager> 
{
    //public static int score = 0; //globally accessable
    public int totalScore;
    
    public int score;

    public bool isTutorial = false;

    public GameObject pauseMenu;

    public bool gameOver = false;

    

    //variable to keep track of what level we are on
    private string CurrentLevelName = string.Empty;

    #region This code makes this class a Singleton
    //Done by Singleton Class
    /*
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            //Make sure this game manager persists across scenes\
            DontDestroyOnLoad(gameObject);
            
            
        }
        else
        {
            Destroy(gameObject);
            Debug.LogError("Trying to instatiate a second instance of singleton Game Manager");
        }


    }
    */
    #endregion

    //methods to load and unload scenes

    private void Start()
    {
        
    }
    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if(ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level " + levelName);
            return;
        }

        CurrentLevelName = levelName;
    }

    public void UnLoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + levelName);
            return;
        }
        gameOver = false;
        string testTutorial = CurrentLevelName;
        if (testTutorial == "Level 1")
        {
            score = 0;
        }
        else if (gameOver)
        {
            score = 0;
        }
        else
        {
            totalScore += score;
            score = 0;
        }
    }

    

    public void UnloadCurrentLevel()
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(CurrentLevelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + CurrentLevelName);
            return;
        }
    }

    //pausing and unpausing

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            totalScore = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        
        

    }

    

}
