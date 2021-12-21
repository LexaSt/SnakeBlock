using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{

    private float speed;
    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Moving moving))
        {
            moving.speed = 0;
            print("WIIINNNNEEEER");
 
        }
    }
    
}
