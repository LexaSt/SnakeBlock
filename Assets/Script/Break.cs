using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{

    private int liveBlock;
    public TextMesh TextMesh;
    public 

    void Start()
    {   
        liveBlock = Random.Range(5, 21);
        //print("Жизней у блока в начале " + liveBlock);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (liveBlock > 0)
        {
            if (collision.collider.TryGetComponent(out Moving moving))
            {
                liveBlock = liveBlock - 1;
               // print("Жизней у блока " + liveBlock);
                moving.Bounce();
            }

            if (collision.collider.TryGetComponent(out Snake Snake))
            {
                Snake.DelTails();
            }    
        }
        else if (liveBlock == 0)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        TextMesh.text = liveBlock.ToString();
    }
}
