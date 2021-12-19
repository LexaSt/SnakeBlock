using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{

    private int liveBlock;


    void Start()
    {
        
        liveBlock = Random.Range(1, 21);
        print("Жизней у блока в начале" + liveBlock);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (liveBlock > 0)
        {

            if (collision.collider.TryGetComponent(out Moving moving))
            {
                liveBlock = liveBlock - 1;
                print("Collision" + liveBlock);
                moving.Bounce();
            }
        }
        else if (liveBlock == 0)
        {
            Destroy(gameObject);
        }

    }

}
