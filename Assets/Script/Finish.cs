using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameMenu GameMenu;
    public Stage Stage;
    public int score;
    public GameObject Level;
   



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
            GameMenu.scoreLevel = score;
            GameMenu.GetScore();
            moving.speed = 0;
            moving.sensitivity = 0;
            Level.SetActive(!Level.activeSelf);
            //GameMenu.OnFinish();

        }
    }

   


}
