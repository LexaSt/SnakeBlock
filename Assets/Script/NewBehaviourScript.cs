using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject prefab;
    private List<Vector3> tails = new List<Vector3>();
    private List<Transform> snakeCircles = new List<Transform>();
    private Vector3 position;
    private Vector3 firstPositionTail;
    private GameObject tail;
    public float speed;
    public Transform HeadSnake;
    public float sensRotate;
    public float howMuchTailsX2;
   // public float diametr;


    void Start()
    {
        position = transform.position;
        tails.Add(position);
        
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
            snakeCircles.Add(tail.transform);
        }
    }

    void movingTails()
    {
        float distance = ((Vector3)HeadSnake.position - tails[0]).magnitude;
        if (distance > 0.5)
        {
            Vector3 direction = ((Vector3)HeadSnake.position - tails[0]).normalized;

            tails.Insert(0, tails[0] + direction*0.5f);
            //tails.Insert(0, HeadSnake.position);
            tails.RemoveAt(tails.Count - 1);
            distance = -1;

            for (int i = 0; i < snakeCircles.Count; i++)
            {
                snakeCircles[i].position = Vector3.Lerp(tails[i + 1], tails[i], distance);
            }
        }

    }



    

    private void control()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * sensRotate * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up *-1* sensRotate * Time.deltaTime);
        }
    }


    private void Update()
    {
        
        control();
        movingTails();
    }
}
 
