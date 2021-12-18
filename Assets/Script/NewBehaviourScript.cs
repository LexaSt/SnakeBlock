using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject prefab;
    private List<Vector3> tails = new List<Vector3>();
    private Vector3 position;
    private Vector3 firstPositionTail;
    private GameObject tail;
    public float speed;
    public Rigidbody HeadSnake;
    public float sens;
    public float howMuchTailsX2;


    void Start()
    {
        position = transform.position;
        firstPositionTail = new Vector3(position.x, position.y, position.z - 0.5f);
        //print(position);
        //print(firstPositionTail);
        GetNewPrefab();
    }


    void GetNewPrefab()
    {
        for (float i = 0; i < howMuchTailsX2; i = i + 0.5f)
        {
            tail = Instantiate(prefab);
            tail.transform.position = new Vector3(firstPositionTail.x, firstPositionTail.y, firstPositionTail.z - i);
            //print("Позиция префаба" + tail.transform.position);
            tails.Add(tail.transform.position);
        }
    }

    void movingTails()
    {
        Vector3 newPos = HeadSnake.position - position;
        print("Разница между двумя позициями " + newPos);
       
    
    }

    private void control()
    {
        if (Input.GetKey("a"))
        {
            HeadSnake.velocity = new Vector3(-speed, 0, 0);
        }

        else if (Input.GetKey("d"))
        {

            HeadSnake.velocity = new Vector3(speed, 0, 0);
        }
        else if (Input.GetKey("w"))
        {
            HeadSnake.velocity = new Vector3(0, 0, speed);
        }
        else if (Input.GetKey("s"))
        {
            HeadSnake.velocity = new Vector3(0, 0, -speed);
        }
    }


    private void Update()
    {
        
        control();
        movingTails();
    }
}
 
