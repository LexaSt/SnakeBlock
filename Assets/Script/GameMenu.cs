using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public Moving Moving;
    public Stage stage;
    public enum game
    {
        Playing,
        Loss,
        Win
    }

    public game gameCurrent { get; private set; }

    private void Start()
    {
       Moving = FindObjectOfType<Moving>();
        //Moving = GetComponent<Moving>();
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
        Debug.Log("Win");
        //stage.levelIndex+=1;
        LevelID++;
        ReloadLevel();
    }

    public int LevelID
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
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
