using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public Moving Moving;
    public Stage stage;
    public int scoreLevel;
    public Finish Finish;
    
    public enum game
    {
        Playing,
        Loss,
        Win
    }

    public game gameCurrent { get; private set; }


    public void Start()
    {
        
        Moving = FindObjectOfType<Moving>();
    }

      public void Over()
    {
        if (gameCurrent != game.Playing) return;
        gameCurrent = game.Loss;
        Moving.speed = 0;
        Moving.sensitivity = 0;
        Debug.Log("Game over");
        ReloadLevel();
    }

    public void OnFinish()
    {
        if (gameCurrent != game.Playing) return;
        gameCurrent = game.Win;
        Moving.speed = 0;
        Moving.sensitivity = 0;
       // Debug.Log("Win");
        scoreLevel = Finish.score;
        //Debug.Log("from gameMenu " + scoreLevel);
        AllLevelsScore += scoreLevel;
        LevelID++;
        ReloadLevel();
    }

    public int LevelID
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string LevelIndexKey = "LevelIndex";

    public int AllLevelsScore
    {
        get => PlayerPrefs.GetInt(LevelsScore, 0);
        set
        {
            PlayerPrefs.SetInt(LevelsScore, value);
            PlayerPrefs.Save();
        }
    }
    private const string LevelsScore = "LevelsScore";


    private void ReloadLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }





}
