using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameMenu GameMenu;
    public Stage Stage;
    public int score;

   
    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Moving moving))
        {
         
            score = Stage.score;
            GameMenu.scoreLevel = score;
            GameMenu.GetScore();
            GameMenu.OnFinish();
 
        }
    }
    
}
