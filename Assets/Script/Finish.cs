using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public GameMenu GameMenu;
    public Stage Stage;
    public int score;
    public GameObject Level;
    public GameObject CanvasGameOver;
    public Text AllScore;




    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Snake Snake))
        {
            Snake.GoFirework();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Moving moving))
        {
            score = Stage.score;
            moving.speed = 0;
            moving.sensitivity = 0;
            if (Stage.levelIndex < 3)
            {
                Level.SetActive(!Level.activeSelf);
            }
            else
            {
                score = Stage.score + GameMenu.AllLevelsScore;
                AllScore.text = "Score: " + score.ToString();
                CanvasGameOver.SetActive(!CanvasGameOver.activeSelf); 
            }
        }
    }

   


}
