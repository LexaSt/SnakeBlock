using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameMenu GameMenu;
    public Stage Stage;
   
    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Moving moving))
        {
            //Stage.levelIndex += 1; 
            GameMenu.OnFinish();
 
        }
    }
    
}
