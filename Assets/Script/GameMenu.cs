using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public Moving Moving;
    public Stage stage;
    public int scoreLevel;
    public int scoreAllLevel;
    public Finish Finish;
    public enum game
    {
        Playing,
        Loss,
        Win
    }

    public game gameCurrent { get; private set; }


    public int GetScore()
    {
        scoreAllLevel = scoreLevel;//=40
        scoreLevel = scoreAllLevel;//=40
        return scoreAllLevel;
        //print("scoreAllLevel " + scoreAllLevel);
    }
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
        GetScore();
        Moving.speed = 0;
        Moving.sensitivity = 0;
        Debug.Log("Win");
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
    private void ReloadLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

  
}
